using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for WebConfigurationDialog.xaml
    /// </summary>
    public partial class WebConfigurationDialog : Window
    {
        public WebConfigurationDialog()
        {
            InitializeComponent();
            CenterWindow();
            SetTextBoxValue();
        }

        private void SetTextBoxValue()
        {
            rspnsTXTBXNM.Text = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\WebConfig.txt");
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
            MySql.Data.MySqlClient.MySqlConnection connection;
            string server = rspnsTXTBXNM.Text;
            string database = "dbstistudents";
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
                    DialogResult = true;
                    webconfigCHANGE();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Connect to the server.");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void webconfigCHANGE()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local\WebConfig.txt";

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.Write("" + rspnsTXTBXNM.Text);
            }
        }

    }
}
