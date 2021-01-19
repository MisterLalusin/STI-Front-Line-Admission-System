using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STI_Front_Line
{
    /// <summary>
    /// Interaction logic for OfficersDialog.xaml
    /// </summary>
    public partial class OfficersDialog : Window
    {
        public string strSettingsPageText_User { get; set; }

        String strOfficersProfileDialogText_User;

        String UserIDValue;

        public OfficersDialog(String strSettingsPageText_User)
        {
            InitializeComponent();

            CenterWindow();

            optionCHK();

            retrieveData();

            strOfficersProfileDialogText_User = strSettingsPageText_User;

            try
            {
                currentlyloggedIn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void currentlyloggedIn()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = "server";
            csb.InitialCatalog = "database";
            csb.IntegratedSecurity = true;

            string connString = csb.ToString();
            
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            string queryString = "select top 1 UserID from tblAdmissionOfficers Where UserName='" + strOfficersProfileDialogText_User + "'";

            using (SqlConnection connection = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;"))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserIDValue = reader["UserID"].ToString();
                    }
                }
            }
        }

        private void CenterWindow()
        {
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            this.Left = (workArea.Width - this.Width) / 2 + workArea.Left;
            this.Top = (workArea.Height - this.Height) / 2 + workArea.Top;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void optionCHK()
        {
            smlrCHCKBXNM.IsChecked = true;
        }

        private void retrieveData()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            DataTable dt = new DataTable();
            using (sqlCon)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                if (srchTXTBXNM.Text.Length == 0)
                {
                    adapter.SelectCommand = new SqlCommand("Select UserID, FullName, UserLevel from dbo.tblAdmissionOfficers", sqlCon);
                }
                else
                {
                    String searchQuery;
                    String searchBoxValue = (srchTXTBXNM.Text).Replace("'", "\"").Replace("%", "\\%").Replace("=", "\\=").Replace("\"", "\\");//SQL Injection
                    string frstWRD = "";
                    string scndWRD = "";
                    string thrdWRD = "";
                    string frthWRD = "";
                    string ffthWRD = "";

                    try
                    {
                        string input = searchBoxValue;
                        if ((input + "*").IndexOf(" *") > 0)
                        {
                            input = ((input + "*").Replace(" *", ""));
                        }
                        string[] output = input.Split(' ');
                        try
                        {
                            frstWRD = output[0];
                        }
                        catch (Exception ex)
                        {
                            frstWRD = "▀*▀*▀*▀";//para walang match
                        }
                        try
                        {
                            scndWRD = output[1];
                        }
                        catch (Exception ex)
                        {
                            scndWRD = "▀*▀*▀*▀";//para walang match
                        }
                        try
                        {
                            thrdWRD = output[2];
                        }
                        catch (Exception ex)
                        {
                            thrdWRD = "▀*▀*▀*▀";//para walang match
                        }
                        try
                        {
                            frthWRD = output[3];
                        }
                        catch (Exception ex)
                        {
                            frthWRD = "▀*▀*▀*▀";//para walang match
                        }
                        try
                        {
                            ffthWRD = output[4];
                        }
                        catch (Exception ex)
                        {
                            ffthWRD = "▀*▀*▀*▀";//para walang match
                        }
                    }
                    catch (Exception ex)
                    {
                        frstWRD = "" + searchBoxValue;
                    }
                    if (smlrCHCKBXNM.IsChecked == true)
                    {
                        searchQuery = " Where (UserID LIKE '%" + searchBoxValue + "%'" + " OR UserName LIKE '%" + searchBoxValue + "%'" + " OR FullName LIKE '%" + searchBoxValue + "%'" + " OR UserLevel LIKE '%" + searchBoxValue + "%'" + " OR FullName LIKE '%" + frstWRD + "%'" + " OR FullName LIKE '%" + scndWRD + "%'" + " OR FullName LIKE '%" + thrdWRD + "%'" + " OR FullName LIKE '%" + frthWRD + "%'" + " OR FullName LIKE '%" + ffthWRD + "%')";
                    }
                    else
                    {
                        searchQuery = " Where (UserID LIKE '%" + searchBoxValue + "%'" + " OR UserName LIKE '%" + searchBoxValue + "%'" + " OR FullName LIKE '%" + searchBoxValue + "%'" + " OR UserLevel LIKE '%" + searchBoxValue + "%')";
                    }

                    adapter.SelectCommand = new SqlCommand("Select UserID, FullName, UserLevel from dbo.tblAdmissionOfficers" + searchQuery, sqlCon);
                }
                try
                {
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            DTV = dt.DefaultView;
            dtgrdNM.ItemsSource = DTV;

        }

        public DataView DTV { get; private set; }

        private void dtgrdNM_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dtgrdNM.SelectedItem;
                string USERID_PASS = (dtgrdNM.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                if (UserIDValue.Equals(USERID_PASS))
                {
                    MessageBox.Show("It's your account");
                }
                else
                {
                    var dialog = new OfficersProfileDialog(USERID_PASS);
                    if (dialog.ShowDialog() == true)
                    {
                        retrieveData();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void srchBTNNM_Click(object sender, RoutedEventArgs e)
        {
            if (srchTXTBXNM.Text.Length == 0)
            {
                MessageBox.Show("Don't leave search box empty");
            }
            else
            {
                retrieveData();
            }
        }

        private void srchTXTBXNM_TextChanged(object sender, TextChangedEventArgs e)
        {
            retrieveData();
        }

        private void ddccnt_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddAccountDialog();
            if (dialog.ShowDialog() == true)
            {
                retrieveData();
            }
        }
    }
}