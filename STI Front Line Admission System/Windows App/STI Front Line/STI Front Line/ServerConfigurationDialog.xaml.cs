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
    /// Interaction logic for ServerConfigurationDialog.xaml
    /// </summary>
    public partial class ServerConfigurationDialog : Window
    {
        public ServerConfigurationDialog()
        {
            InitializeComponent();
            CenterWindow();
            SetTextBoxValue();

        }
        private void SetTextBoxValue()
        {
            rspnsTXTBXNM.Text = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");
        }
        private void CenterWindow()
        {
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            this.Left = (workArea.Width - this.Width) / 2 + workArea.Left;
            this.Top = (workArea.Height - this.Height) / 2 + workArea.Top;
        }

        public string ResponseText
        {
            get { return rspnsTXTBXNM.Text; }
            set { rspnsTXTBXNM.Text = value; }
        }

        private void OKButton_Click(object sender,
            System.Windows.RoutedEventArgs e)
        {
            LookForServer();
        }

        private void LookForServer()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + rspnsTXTBXNM.Text+ ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            try
            {
                if (rspnsTXTBXNM.Text.Length == 0)
                {
                    MessageBox.Show("Don't leave the field empty!");
                }
                else if (sqlCon.State == ConnectionState.Closed) { 
                    sqlCon.Open();
                    DialogResult = true;
                    sqlCon.Close();
                    serverconfigCHANGE();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Connect to the server.");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void serverconfigCHANGE()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt";

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.Write("" + rspnsTXTBXNM.Text);
            }
        }

    }
}
