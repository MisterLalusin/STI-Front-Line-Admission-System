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
    /// Interaction logic for ChangeUserLevelDialog.xaml
    /// </summary>
    public partial class ChangeUserLevelDialog : Window
    {
        String UserIDToChangeUserLevel;
        public ChangeUserLevelDialog(String UserID)
        {
            InitializeComponent();
            CenterWindow();

            UserIDToChangeUserLevel = UserID;
        }
        public string ResponseText
        {
            get { return chngsrlvlCMBBXNM.Text; }
            set { chngsrlvlCMBBXNM.Text = value; }
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
        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            updateAccountData();
        }
        public void updateAccountData()
        {

            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            String UserID = UserIDToChangeUserLevel;
            String UserLevel = chngsrlvlCMBBXNM.Text;

            string cs = @"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand("UPDATE tblAdmissionOfficers SET UserLevel=@UserLevel WHERE UserID=@UserID ", con))
            {
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@UserLevel", UserLevel);
                con.Open();
                cmd.ExecuteNonQuery();
                
                DialogResult = true;

                //this.Close();
            }
        }
    }
}
