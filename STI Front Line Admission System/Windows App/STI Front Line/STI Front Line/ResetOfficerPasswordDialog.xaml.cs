using System;
using System.Collections.Generic;
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
    /// Interaction logic for ResetOfficerPasswordDialog.xaml
    /// </summary>
    public partial class ResetOfficerPasswordDialog : Window
    {
        String UserToResetPassword;
        public ResetOfficerPasswordDialog(String UserNameValue)
        {
            InitializeComponent();

            CenterWindow();

            UserToResetPassword = UserNameValue;
        }
        private void CenterWindow()
        {
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            this.Left = (workArea.Width - this.Width) / 2 + workArea.Left;
            this.Top = (workArea.Height - this.Height) / 2 + workArea.Top;
        }
        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (rspnsPSSWRDBXNM.Password.Length < 8)
            {
                MessageBox.Show("Password must be atleast 8 characters.");
            }
            else
            {
                ResetOfficerPassword();
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public string ResponseText
        {
            get { return rspnsPSSWRDBXNM.Password; }
            set { rspnsPSSWRDBXNM.Password = value; }
        }

        private void ResetOfficerPassword()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            string cs = @"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;";

            string searchUser = UserToResetPassword;

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand("UPDATE tblAdmissionOfficers SET Password=@Password WHERE UserName='" + searchUser + "'", con))
            {
                cmd.Parameters.AddWithValue("@Password", rspnsPSSWRDBXNM.Password);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Password changed");

                DialogResult = true;
            }
        }
    }
}
