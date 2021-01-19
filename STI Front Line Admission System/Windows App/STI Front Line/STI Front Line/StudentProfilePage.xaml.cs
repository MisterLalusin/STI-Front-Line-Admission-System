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
    /// Interaction logic for StudentProfilePage.xaml
    /// </summary>
    public partial class StudentProfilePage : Page
    {
        public StudentProfilePage()
        {
            InitializeComponent();

            retrieveData();

            optionCHK();
        }

        private void optionCHK()
        {
            smlrCHCKBXNM.IsChecked = true;
            crrntschlyrCHCKBXNM.IsChecked = true;
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
                    adapter.SelectCommand = new SqlCommand("Select TRANSACTION_ID, STUDENT_NAME, COURSE, YEAR_OR_GRADE, SCHOOL_YEAR from dbo.tblSTIEnrollees", sqlCon);
                }
                else
                {
                    String searchQuery;
                    String searchBoxValue = (srchTXTBXNM.Text).Replace("'", "\"").Replace("%", "\\%").Replace("=", "\\=").Replace("\"", "\\");//SQL Injection
                    string frstWRD = "";
                    string scndWRD = "";
                    string thrdWRD = "";
                    string frthWRD = "";
                    string fthWRD = "";

                    try
                    {
                        string input = searchBoxValue;
                        if ((input+"*").IndexOf(" *") > 0)
                        {
                            input = ((input + "*").Replace(" *",""));
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
                            fthWRD = output[4];
                        }
                        catch (Exception ex)
                        {
                            fthWRD = "▀*▀*▀*▀";//para walang match
                        }
                    }
                    catch (Exception ex)
                    {
                        frstWRD = ""+searchBoxValue;
                    }
                    if (smlrCHCKBXNM.IsChecked == true)
                    {
                        searchQuery = " Where (STUDENT_NAME LIKE '%" + searchBoxValue + "%'" + " OR STUDENT_ID LIKE '%" + searchBoxValue + "%'" + " OR COURSE LIKE '%" + searchBoxValue + "%'" + " OR YEAR_OR_GRADE LIKE '%" + searchBoxValue + "%'" + " OR STUDENT_NAME LIKE '%" + frstWRD + "%'" + " OR STUDENT_NAME LIKE '%" + scndWRD+ "%'" + " OR STUDENT_NAME LIKE '%" + thrdWRD + "%'" + " OR STUDENT_NAME LIKE '%" + frthWRD + "%'" + " OR STUDENT_NAME LIKE '%" + fthWRD + "%')";
                    }
                    else
                    {
                        searchQuery = " Where (STUDENT_NAME LIKE '%" + searchBoxValue + "%'" + " OR STUDENT_ID LIKE '%" + searchBoxValue + "%'" + " OR COURSE LIKE '%" + searchBoxValue + "%'" + " OR YEAR_OR_GRADE LIKE '%" + searchBoxValue + "%')";
                    }

                    if (crrntschlyrCHCKBXNM.IsChecked == true)
                    {
                        String host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");
                        String School_Year = System.IO.File.ReadAllText(@"" + host + "\\SchoolYear.txt");
                        searchQuery = searchQuery + " AND (SCHOOL_YEAR='" + School_Year + "')";
                    }
                    if (mlCHCKBXNM.IsChecked == true)
                    {
                        String gender = "Male";
                        searchQuery = searchQuery + " AND (GENDER='" + gender + "')";
                    }
                    if (fmlCHCKBXNM.IsChecked == true)
                    {
                        String gender = "Female";
                        searchQuery = searchQuery + " AND (GENDER='" + gender + "')";
                    }
                    adapter.SelectCommand = new SqlCommand("Select TRANSACTION_ID, STUDENT_NAME, COURSE, YEAR_OR_GRADE, SCHOOL_YEAR from dbo.tblSTIEnrollees" + searchQuery, sqlCon);
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
                string TRANSACTION_ID_PASS = (dtgrdNM.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                StudentProfileDialog stdntprfldlg = new StudentProfileDialog(TRANSACTION_ID_PASS);
                stdntprfldlg.ShowDialog();
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

        private void mlCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            fmlCHCKBXNM.IsChecked = false;
        }

        private void fmlCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            mlCHCKBXNM.IsChecked = false;
        }

        private void srchTXTBXNM_TextChanged(object sender, TextChangedEventArgs e)
        {
            retrieveData();
        }
    }
}


