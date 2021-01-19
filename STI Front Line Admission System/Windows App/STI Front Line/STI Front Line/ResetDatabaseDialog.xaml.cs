using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Interaction logic for ResetDatabaseDialog.xaml
    /// </summary>
    public partial class ResetDatabaseDialog : Window
    {
        public ResetDatabaseDialog()
        {
            InitializeComponent();
            CenterWindow();
            resetDate();
        }

        String rst = ";";

        private void resetDate()
        {
            DateTime currentTime = DateTime.Now;

            String Reset_Date = currentTime.ToString("MM - dd - yyyy");

            rst = "Database was reset on " + Reset_Date;
        }

        private void CenterWindow()
        {
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            this.Left = (workArea.Width - this.Width) / 2 + workArea.Left;
            this.Top = (workArea.Height - this.Height) / 2 + workArea.Top;
        }

        public string ResponseText
        {
            get { return rst; }
            set { rst = value; }
        }

        private void OKButton_Click(object sender,
            System.Windows.RoutedEventArgs e)
        {
            CheckPassword();
        }

        private void CheckPassword()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            String getMasterPassword = rspnsPSSWRDBXNM.Password;

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM tblMasterPassword WHERE MasterPassword=@MasterPassword";

                SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
                sqlCMD.CommandType = CommandType.Text;
                sqlCMD.Parameters.AddWithValue("@MasterPassword", getMasterPassword);
                int count = Convert.ToInt32(sqlCMD.ExecuteScalar());

                if (rspnsPSSWRDBXNM.Password.Length == 0)
                {
                    MessageBox.Show("Don't leave the field empty!");
                }
                else if (count == 1)
                {
                    string sqlTrunc = "TRUNCATE TABLE tblSTIEnrollees";
                    SqlCommand cmd = new SqlCommand(sqlTrunc, sqlCon);
                    cmd.ExecuteNonQuery();
                    ResetLog();
                    ResetPHPDatabase();
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                sqlCon.Close();
            }

        }

        private void ResetPHPDatabase()
        {
            MySql.Data.MySqlClient.MySqlConnection connection;
            string server = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\WebConfig.txt"); ;
            string database = "dbfrontline";
            string uid = "root";
            string password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; SslMode = none;";
            connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    String trunCMD = "TRUNCATE TABLE tblenrollees";

                    MySqlCommand lookcmd = new MySqlCommand(trunCMD, connection);
                    MySqlDataReader rdr = lookcmd.ExecuteReader();

                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Database connection failed.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            connection.Close();
        }

        private void ResetLog()
        {
            string host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");

            string path = @"" + host + "\\ResetLog.txt";
            
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.Write("" + rst);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
