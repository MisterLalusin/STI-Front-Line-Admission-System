using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace STI_Front_Line
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public string strAdmissionWorkspaceText_User { get; set; }

        public string strSettingsPageText_User;

        string UserLevelValue;

        public SettingsPage(string strAdmissionWorkspaceText_User)
        {
            InitializeComponent();

            strSettingsPageText_User = strAdmissionWorkspaceText_User;

            setDefault();

            retrieveUserLevel();
        }

        private void setDefault()
        {
            string host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");

            srvrcnfgrtnTBNM.Text = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");
            lgcnfgrtnTBNM.Text = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\LogConfig.txt");
            schlyrTBNM.Text = System.IO.File.ReadAllText(@"" + host + "\\SchoolYear.txt");
            rstdtbsTBNM.Text = System.IO.File.ReadAllText(@"" + host + "\\ResetLog.txt");
            xprtdttxclTBNM.Text = System.IO.File.ReadAllText(@"" + host + "\\ExcelLog.txt");
            ccntTBNM.Text = strSettingsPageText_User;
            if (System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt").Substring(1,1).Equals(":"))
            {
                hstcnfgrtnTBNM.Text = "This is the host PC";
            }
            else
            {
                hstcnfgrtnTBNM.Text = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");
            }
            pdtmstrpsswrdTBNM.Text = System.IO.File.ReadAllText(@"" + host + "\\PasswordLog.txt");
            ffcrsTBNM.Text = "Manage User Accounts";
            if (System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\WebConfig.txt").ToLower().Equals("localhost"))
            {
                wbcnfgrtnTBNM.Text = "Local XAMPP Server";
            }
            else
            {
                wbcnfgrtnTBNM.Text = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\WebConfig.txt");
            }
            stdrctryTBNM.Text = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\SiteDirectory.txt");
        }

        private void lgcnfgrtnBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                var dialog = new LogConfigurationDialog();
                if (dialog.ShowDialog() == true)
                {
                    lgcnfgrtnTBNM.Text = dialog.ResponseText;
                }
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }

        }

        private void srvrcnfgrtnBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                var dialog = new ServerConfigurationDialog();
                if (dialog.ShowDialog() == true)
                {
                    srvrcnfgrtnTBNM.Text = dialog.ResponseText;
                }
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }
        
        private void schlyrBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                var dialog = new SchoolYearDialog();
                if (dialog.ShowDialog() == true)
                {
                    schlyrTBNM.Text = dialog.ResponseText;
                }
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }

        private void rstdtbsBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                string sMessageBoxText = "Reset Database";
                string host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");
                string sCaption = System.IO.File.ReadAllText(@"" + host + "\\ResetLog.txt");

                if (sCaption.Equals("Never"))
                {
                    sCaption = "Database was never reset.";
                }

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:

                        var dialog = new ResetDatabaseDialog();
                        if (dialog.ShowDialog() == true)
                        {
                            rstdtbsTBNM.Text = dialog.ResponseText;
                        }

                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }

        private void xprtdttxclBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                generateExcel();
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }

        private void pdtmstrpsswrdBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                var dialog = new UpdateMasterPasswordDialog();
                if (dialog.ShowDialog() == true)
                {
                    //hstcnfgrtnTBNM.Text = dialog.ResponseText;
                }
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }

        private void ccntBTTN_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("ccnt");

            AccountDialog cctndlg = new AccountDialog(strSettingsPageText_User);
            cctndlg.Show();
        }

        private void generateExcel()
        {
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            connectionString = @"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT * FROM tblSTIEnrollees";

            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 1, j + 1] = data;
                }
            }

            string filename = string.Empty;
            Microsoft.Win32.SaveFileDialog dlg = new
            Microsoft.Win32.SaveFileDialog();
            DateTime currentTime = DateTime.Now;
            String Time_And_Date_Exported = currentTime.ToString("MM-dd-yyyy");
            dlg.FileName = "STI Front Line Export "+ Time_And_Date_Exported;
            dlg.DefaultExt = ".xls";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                try
                {
                    xlWorkBook.SaveAs(dlg.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    Process.Start(dlg.FileName);

                    ExcelLog();
                }
                catch (Exception ex){ }
            }
            //MessageBox.Show("The file was saved at " + dlg.FileName);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void ExcelLog()
        {
            string host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");

            string path = @"" + host + "\\ExcelLog.txt";

            using (TextWriter tw = new StreamWriter(path))
            {
                DateTime currentTime = DateTime.Now;

                String Export_Date = currentTime.ToString("MM - dd - yyyy");

                String xprt = "Data was export on " + Export_Date;

                tw.Write("" + xprt);

                xprtdttxclTBNM.Text = xprt;
            }
        }

        private void hstcnfgrtnBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                var dialog = new HostConfigurationDialog();
                if (dialog.ShowDialog() == true)
                {
                    if (!dialog.ResponseText.Substring(1, 1).Equals(":"))
                    {
                        hstcnfgrtnTBNM.Text = dialog.ResponseText;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }

        private void ffcrsBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                OfficersDialog ffcrsdlg = new OfficersDialog(strSettingsPageText_User);
                ffcrsdlg.Show();
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }

        private void retrieveUserLevel()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = "server";
            csb.InitialCatalog = "database";
            csb.IntegratedSecurity = true;

            string connString = csb.ToString();

            string searchUser = strSettingsPageText_User;

            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            string queryString = "select top 1 UserLevel from tblAdmissionOfficers Where UserName='" + searchUser + "'";

            using (SqlConnection connection = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;"))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserLevelValue = reader["UserLevel"].ToString();
                    }
                }
            }
        }

        private void wbcnfgrtnBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                var dialog = new WebConfigurationDialog();
                if (dialog.ShowDialog() == true)
                {
                    if (dialog.ResponseText.ToLower().Equals("localhost") == false)
                    {
                        wbcnfgrtnTBNM.Text = dialog.ResponseText;
                    }
                    else
                    {
                        wbcnfgrtnTBNM.Text = "Local XAMPP Server";
                    }
                }
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }

        private void stdrctryBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (UserLevelValue.Equals("Admin"))
            {
                var dialog = new StudentDirectoryDialog();
                if (dialog.ShowDialog() == true)
                {
                    stdrctryTBNM.Text = dialog.ResponseText;
                }
            }
            else
            {
                MessageBox.Show("You must logged in as admin.");
            }
        }
    }
}