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
    /// Interaction logic for SchoolYearDialog.xaml
    /// </summary>
    public partial class SchoolYearDialog : Window
    {
        public SchoolYearDialog()
        {
            InitializeComponent();
            CenterWindow();
            SetTextBoxValue();
        }

        private void SetTextBoxValue()
        {
            string host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");
            rspnsTXTBXNM.Text = System.IO.File.ReadAllText(@"" + host + "\\SchoolYear.txt");
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
            validateSY();
        }

        private void validateSY()
        {
            DateTime tempDate;

            if (rspnsTXTBXNM.Text.Length == 0)
            {
                MessageBox.Show("Don't leave the field empty!");
            }
            else if ((rspnsTXTBXNM.Text.Replace(" ", "").Replace("-", "")).All(char.IsDigit) == false)
            {
                MessageBox.Show("Not a valid date");
            }
            else if ((rspnsTXTBXNM.Text.Replace(" ", "").Replace("-", "")).Length != 8)
            {
                MessageBox.Show("Not a valid school year.");
            }
            else
            {
                string sy1 = (rspnsTXTBXNM.Text.Replace(" ", "").Replace("-", "")).Substring(0, 4);
                string sy2 = ""+ Convert.ToInt32((rspnsTXTBXNM.Text.Replace(" ", "").Replace("-", "")));
                sy2 = sy2.Substring(sy2.Length - 4);
                DateTime currentTime = DateTime.Now;

                string currentYear = currentTime.ToString("yyyy");


                if ((Convert.ToInt32(sy2) - Convert.ToInt32(sy1) != 1))
                {
                    MessageBox.Show("Not a valid school year.");
                }
                else if (Convert.ToInt32(sy2) <= Convert.ToInt32(currentYear))
                {
                    MessageBox.Show("Enrollment for that school year ends.");
                }
                else
                {
                    schoolyearCHANGE();
                    DialogResult = true;
                }
            }
        }

        private void schoolyearCHANGE()
        {
            string host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");
            string path = @"" + host + "\\SchoolYear.txt";

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.Write("" + rspnsTXTBXNM.Text);
            }
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
