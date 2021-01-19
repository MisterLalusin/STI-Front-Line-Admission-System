using System;
using System.Collections.Generic;
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
    /// Interaction logic for StudentDirectoryDialog.xaml
    /// </summary>
    public partial class StudentDirectoryDialog : Window
    {
        public StudentDirectoryDialog()
        {
            InitializeComponent();
            CenterWindow();
            SetTextBoxValue();
        }
        private void SetTextBoxValue()
        {
            rspnsTXTBXNM.Text = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\SiteDirectory.txt");
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
            if (rspnsTXTBXNM.Text.Length == 0)
            {
                MessageBox.Show("Don't leave the field empty!");
            }
            else
            {
                LookForFolder();
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LookForFolder()
        {
            string path = @"" + rspnsTXTBXNM.Text;

            try
            {
                if (rspnsTXTBXNM.Text.Length == 0)
                {
                    MessageBox.Show("Don't leave the field empty!");
                }
                else if (!Directory.Exists(path))
                {
                    MessageBox.Show("Path does't exist.");
                }
                else
                {
                    sitedirectoryCHANGE();
                    DialogResult = true;
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("" + ioex);
            }
        }

        private void sitedirectoryCHANGE()
        {
            string path = @"C:\ProgramData\STI Front Line\System Files\Local\SiteDirectory.txt";

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.Write("" + rspnsTXTBXNM.Text);
            }
        }
    }
}
