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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STI_Front_Line
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CenterWindow();

            CreateSYSFolder();

            CreateLogFolder();

            //Pansamantala
            /*AdmissionWorkspace admsnWRKSPC = new AdmissionWorkspace();
            admsnWRKSPC.Show();
            this.Close();*/
            //Pansamantala
        }

        private void CreateLogFolder()
        {
            string path = @"C:\ProgramData\STI Front Line\Log Files";

            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
                else
                {
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("" + ioex);
            }
        }

        private void CreateSYSFolder()
        {
            local();
            network();
        }

        private void network()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Network";

            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);

                    GenSchoolYR();
                    ResetLog();
                    ExcelLog();
                    PasswordLog();
                }
                else
                {
                    GenSchoolYR();
                    ResetLog();
                    ExcelLog();
                    PasswordLog();
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("" + ioex);
            }
        }

        private void PasswordLog()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Network\PasswordLog.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("Never");
                }

            }
        }

        private void local()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local";

            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);

                    GenDBConfig();
                    GenLogConfig();
                    GenHostConfig();
                    GenWebConfig();
                    GenSiteDirectory();

                }
                else
                {
                    GenDBConfig();
                    GenLogConfig();
                    GenHostConfig();
                    GenWebConfig();
                    GenSiteDirectory();
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("" + ioex);
            }
        }

        private void GenSiteDirectory()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local\SiteDirectory.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("C:\\xampp\\htdocs");
                }

            }
        }

        private void GenWebConfig() {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local\WebConfig.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("localhost");
                }

            }
        }

        private void GenHostConfig()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("C:\\ProgramData\\STI Front Line\\System Files\\Network");
                }

            }
        }

        private void GenDBConfig()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("localhost\\WINDOWSSERVERPC");
                }

            }
        }

        private void GenLogConfig()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local\LogConfig.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("C:\\ProgramData\\STI Front Line\\Log Files");
                }

            }
        }
        private void GenSchoolYR()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Network\SchoolYear.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    DateTime currentTime = DateTime.Now;

                    String Current_Mont = currentTime.ToString("MM");
                    String Current_Year = currentTime.ToString("yyyy");

                    String School_Year;

                    if (!Current_Mont.Equals("03")|| !Current_Mont.Equals("04")||!Current_Mont.Equals("05")||!Current_Mont.Equals("06")||!Current_Mont.Equals("07")||!Current_Mont.Equals("08"))
                    {
                        School_Year = Current_Year + " - " + (Convert.ToInt32(Current_Year) + 1);
                    }
                    else
                    {
                        School_Year = (Convert.ToInt32(Current_Year) - 1) + " - " + Current_Year;
                    }

                    tw.Write(School_Year);
                }

            }
        }
        private void ResetLog()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Network\ResetLog.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("Never");
                }

            }
        }
        private void ExcelLog()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Network\ExcelLog.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("Never");
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

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {

            var logACC = accNM.Text;
            var logPASS = passNM.Password;

            if (logACC.Length == 0 || logPASS.Length == 0)
            {
                if ((logACC.Length == 0 && logPASS.Length == 0))
                    MessageBox.Show($"Don't leave it blank.");
                else if ((logACC.Length == 0))
                    MessageBox.Show($"Type your ID.");
                else if ((logPASS.Length == 0))
                    MessageBox.Show($"Type your password.");
            }

            else
            {

                string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

                SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

                String getAccount = accNM.Text;
                String getPassword = passNM.Password;

                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM tblAdmissionOfficers WHERE Username=@Username AND Password=@Password";

                    SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
                    sqlCMD.CommandType = CommandType.Text;
                    sqlCMD.Parameters.AddWithValue("@Username", getAccount);
                    sqlCMD.Parameters.AddWithValue("@Password", getPassword);
                    int count = Convert.ToInt32(sqlCMD.ExecuteScalar());



                    if (count == 1)
                    {
                        string strMainWindowText_User = accNM.Text;

                        AdmissionWorkspace admsnWRKSPC = new AdmissionWorkspace(strMainWindowText_User);
                        admsnWRKSPC.Show();
                        this.Close();

                        //MessageBox.Show("Log In Succesfull");
                    }
                    else
                    {
                        MessageBox.Show("Log In Failed!");
                    }
                }
                catch (Exception ex)
                {
                    srvrcnfgrtnMethod();
                    MessageBox.Show(""+ex);
                }
                finally
                {
                    sqlCon.Close();
                }

            }
            
        }

        private void srvrcnfgrtnMethod()
        {
            var dialog = new ServerConfigurationDialog();
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show("Connected to " + dialog.ResponseText);
            }
        }
    }
}
