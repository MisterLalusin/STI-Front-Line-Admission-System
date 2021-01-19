using System;
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
using System.Windows.Shapes;

namespace STI_Front_Line
{
    /// <summary>
    /// Interaction logic for AddAccountDialog.xaml
    /// </summary>
    public partial class AddAccountDialog : Window
    {
        public AddAccountDialog()
        {
            InitializeComponent();

            CenterWindow();
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
            srnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            dmnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            psswrdPSSWRDBXNM.ClearValue(TextBox.BorderBrushProperty);
            cnfrmpsswrdPSSWRDBXNM.ClearValue(TextBox.BorderBrushProperty);

            if (fllnmTXTBXNM.Text.Length < 1 || gTXTBXNM.Text.Length < 1 || ddrssTXTBXNM.Text.Length < 1 || cntctnmbrTXTBXNM.Text.Length < 1 || srnmTXTBXNM.Text.Length < 1 || psswrdPSSWRDBXNM.Password.Length < 1 || cnfrmpsswrdPSSWRDBXNM.Password.Length < 1)
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
                if (srnmTXTBXNM.Text.Length < 1)
                {
                    srnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    dmnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                if (psswrdPSSWRDBXNM.Password.Length < 1)
                {
                    psswrdPSSWRDBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                if (cnfrmpsswrdPSSWRDBXNM.Password.Length < 1)
                {
                    cnfrmpsswrdPSSWRDBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                MessageBox.Show("Don't leave any fields empty.");
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
            else if (
                (
                srnmTXTBXNM.Text
                .Replace("_", "")
                .Replace("A", "")
                .Replace("B", "")
                .Replace("C", "")
                .Replace("D", "")
                .Replace("E", "")
                .Replace("F", "")
                .Replace("G", "")
                .Replace("H", "")
                .Replace("I", "")
                .Replace("J", "")
                .Replace("K", "")
                .Replace("L", "")
                .Replace("M", "")
                .Replace("N", "")
                .Replace("O", "")
                .Replace("P", "")
                .Replace("Q", "")
                .Replace("R", "")
                .Replace("S", "")
                .Replace("T", "")
                .Replace("U", "")
                .Replace("V", "")
                .Replace("W", "")
                .Replace("X", "")
                .Replace("Y", "")
                .Replace("Z", "")
                .Replace("a", "")
                .Replace("b", "")
                .Replace("c", "")
                .Replace("d", "")
                .Replace("e", "")
                .Replace("f", "")
                .Replace("g", "")
                .Replace("h", "")
                .Replace("i", "")
                .Replace("j", "")
                .Replace("k", "")
                .Replace("l", "")
                .Replace("m", "")
                .Replace("n", "")
                .Replace("o", "")
                .Replace("p", "")
                .Replace("q", "")
                .Replace("r", "")
                .Replace("s", "")
                .Replace("t", "")
                .Replace("u", "")
                .Replace("v", "")
                .Replace("w", "")
                .Replace("x", "")
                .Replace("y", "")
                .Replace("z", "")
                .Replace("0", "")
                .Replace("1", "")
                .Replace("2", "")
                .Replace("3", "")
                .Replace("4", "")
                .Replace("5", "")
                .Replace("6", "")
                .Replace("7", "")
                .Replace("8", "")
                .Replace("9", "")
                ).Length != 0
                )
            {
                MessageBox.Show("Username isn't valid");
                srnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (("_"+srnmTXTBXNM.Text+"_").IndexOf("__") >= 0)
            {
                MessageBox.Show("Username isn't valid");
                srnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (!psswrdPSSWRDBXNM.Password.Equals(cnfrmpsswrdPSSWRDBXNM.Password))
            {
                MessageBox.Show("New password didn't match");
            }
            else if (psswrdPSSWRDBXNM.Password.Length < 8)
            {
                MessageBox.Show("Password must be atleast 8 characters.");
            }
            else
            {
                addAccountData();
            }
        }

        private void addAccountData()
        {
            searchSimilarUserName();
        }

        private void searchSimilarUserName()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM tblAdmissionOfficers WHERE UserName=@UserName";
                SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
                sqlCMD.CommandType = CommandType.Text;
                sqlCMD.Parameters.AddWithValue("@UserName", srnmTXTBXNM.Text + dmnTXTBXNM.Text);
                int count = Convert.ToInt32(sqlCMD.ExecuteScalar());
                if (count >= 1)
                {
                    MessageBox.Show("User name is already used by another user.");
                }
                else
                {
                    insertUserToServer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void insertUserToServer()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            String colCount = "SELECT COUNT(UserID) FROM tblAdmissionOfficers;";

            int count = 1;
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand countCMD = new SqlCommand(colCount, sqlCon);
                countCMD.CommandType = CommandType.Text;
                count = count + Convert.ToInt32(countCMD.ExecuteScalar());
                sqlCon.Close();
            }
            catch (Exception ex) { }

            int UserID = count;

            String UserName = srnmTXTBXNM.Text + dmnTXTBXNM.Text;
            String Password = psswrdPSSWRDBXNM.Password;
            String FullName = fllnmTXTBXNM.Text;
            String Age = gTXTBXNM.Text;
            String Address = ddrssTXTBXNM.Text;
            String ContactNumber = cntctnmbrTXTBXNM.Text;
            String UserLevel = chngsrlvlCMBBXNM.Text;

            String insertQUERY = "INSERT into tblAdmissionOfficers(UserID, UserName, Password, FullName, Age, Address, ContactNumber, UserLevel) values " +
                "('" + UserID + "','" + UserName + "','" + Password + "','" + FullName + "','" + Age + "','" + Address + "','" + ContactNumber + "','"  + UserLevel + "')";
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCMD = new SqlCommand(insertQUERY, sqlCon);
                sqlCMD.ExecuteNonQuery();
                sqlCMD.Dispose();
                sqlCon.Close();
                MessageBox.Show("Account was created successfully.");

                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
