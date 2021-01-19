using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace STI_Front_Line
{
    /// <summary>
    /// Interaction logic for OfficersProfileDialog.xaml
    /// </summary>
    public partial class OfficersProfileDialog : Window
    {
        String UserID;
        String UserIDValue;
        String UserNameValue;
        String PasswordValue;
        String FullNameValue;
        String AgeValue;
        String AddressValue;
        String ContactNumberValue;
        String UserLevelValue;
        public OfficersProfileDialog(String USERID_PASS)
        {
            InitializeComponent();

            CenterWindow();

            UserID = USERID_PASS;

            retrieveOfficerData();

            setDefault();
        }

        private void setDefault()
        {
            string PassDisp = "";
            do
            {
                PassDisp = PassDisp + "*";
            } while (PassDisp.Length != PasswordValue.Length);

            string passAsterisk = PassDisp;

            hdrTXTBLCKNM.Text = UserNameValue + " [" + UserLevelValue + "]";
            fllnmTXTBXNM.Text = FullNameValue;
            gTXTBXNM.Text = AgeValue;
            ddrssTXTBXNM.Text = AddressValue;
            cntctnmbrTXTBXNM.Text = ContactNumberValue;
            srnmTXTBXNM.Text = UserNameValue;
            psswrdTXTBXNM.Text = passAsterisk;
            srlvlTXTBXNM.Text = UserLevelValue;
        }

        private void CenterWindow()
        {
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            this.Left = (workArea.Width - this.Width) / 2 + workArea.Left;
            this.Top = (workArea.Height - this.Height) / 2 + workArea.Top;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            //this.Close();
        }
        private void retrieveOfficerData()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = "server";
            csb.InitialCatalog = "database";
            csb.IntegratedSecurity = true;

            string connString = csb.ToString();

            int searchID = Convert.ToInt32(UserID);

            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            string queryString = "select top 1 UserID, UserName, Password, FullName, Age, Address, ContactNumber, UserLevel from tblAdmissionOfficers Where UserID=" + searchID;

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
                        UserNameValue = reader["UserName"].ToString();
                        PasswordValue = reader["Password"].ToString();
                        FullNameValue = reader["FullName"].ToString();
                        AgeValue = reader["Age"].ToString();
                        AddressValue = reader["Address"].ToString();
                        ContactNumberValue = reader["ContactNumber"].ToString();
                        UserLevelValue = reader["UserLevel"].ToString();
                    }
                }
            }
        }

        private void dtBTTNNM_Click(object sender, RoutedEventArgs e)
        {
            fllnmTXTBXNM.IsReadOnly = false;
            fllnmTXTBXNM.BorderThickness = new Thickness(0, 0, 0, 1);
            gTXTBXNM.IsReadOnly = false;
            gTXTBXNM.BorderThickness = new Thickness(0, 0, 0, 1);
            ddrssTXTBXNM.IsReadOnly = false;
            ddrssTXTBXNM.BorderThickness = new Thickness(0, 0, 0, 1);
            cntctnmbrTXTBXNM.IsReadOnly = false;
            cntctnmbrTXTBXNM.BorderThickness = new Thickness(0, 0, 0, 1);
            dtBTTNNM.Visibility = Visibility.Hidden;
            svBTTNNM.Visibility = Visibility.Visible;
        }

        public void updateAccountData()
        {

            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            String UserName = UserNameValue;
            String FullName = fllnmTXTBXNM.Text;
            String Age = gTXTBXNM.Text;
            String Address = ddrssTXTBXNM.Text;
            String ContactNumber = cntctnmbrTXTBXNM.Text;

            string cs = @"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand("UPDATE tblAdmissionOfficers SET FullName=@FullName, Age=@Age, Address=@Address, ContactNumber=@ContactNumber WHERE UserName=@UserName ", con))
            {
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Personal Information Updated");

                DialogResult = true;

                //this.Close();
            }
        }

        public string ResponseText
        {
            get { return fllnmTXTBXNM.Text; }
            set { fllnmTXTBXNM.Text = value; }
        }

        private void svBTTNNM_Click(object sender, RoutedEventArgs e)
        {
            validateAccountData();
        }

        private void validateAccountData()
        {
            fllnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            gTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            ddrssTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            cntctnmbrTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            if (fllnmTXTBXNM.Text.Length < 1 || gTXTBXNM.Text.Length < 1 || ddrssTXTBXNM.Text.Length < 1 || cntctnmbrTXTBXNM.Text.Length < 1)
            {
                if (fllnmTXTBXNM.Text.Length < 1)
                {
                    fllnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                if (gTXTBXNM.Text.Length < 1)
                {
                    gTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                if (ddrssTXTBXNM.Text.Length < 1)
                {
                    ddrssTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                if (cntctnmbrTXTBXNM.Text.Length < 1)
                {
                    cntctnmbrTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                MessageBox.Show("Don't leave any fields empty.");
            }
            else if (fllnmTXTBXNM.Text.Equals(FullNameValue) && gTXTBXNM.Text.Equals(AgeValue) && ddrssTXTBXNM.Text.Equals(AddressValue) && cntctnmbrTXTBXNM.Text.Equals(ContactNumberValue))
            {
                MessageBox.Show("Information Isn't Change");
            }
            else if (gTXTBXNM.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show("Age isn't valid");
                gTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (cntctnmbrTXTBXNM.Text.Length != 11)
            {
                MessageBox.Show("Contact isn't valid");
                cntctnmbrTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (cntctnmbrTXTBXNM.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show("Contact isn't valid");
                cntctnmbrTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                updateAccountData();
            }
        }

        private void rstpsswrdBTTNNM_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new ResetOfficerPasswordDialog(UserNameValue);
            if (dialog.ShowDialog() == true)
            {
                string PassDisp = "";
                do
                {
                    PassDisp = PassDisp + "*";
                } while (PassDisp.Length != dialog.ResponseText.Length);
                
                psswrdTXTBXNM.Text = PassDisp;
            }
        }

        private void srlvlBTTNNM_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ChangeUserLevelDialog(UserID);
            if (dialog.ShowDialog() == true)
            {
                hdrTXTBLCKNM.Text = UserNameValue + " [" + dialog.ResponseText + "]";
                srlvlTXTBXNM.Text = dialog.ResponseText;
            }
        }
    }
}
