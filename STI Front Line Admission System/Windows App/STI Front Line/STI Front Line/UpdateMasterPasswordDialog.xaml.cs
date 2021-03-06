﻿using System;
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
    /// Interaction logic for UpdateMasterPasswordDialog.xaml
    /// </summary>
    public partial class UpdateMasterPasswordDialog : Window
    {
        public UpdateMasterPasswordDialog()
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
        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (crrntpsswrdPSSWRDBXNM.Password.Length == 0 || crrntpsswrdPSSWRDBXNM.Password.Length == 0 || cnfrmnwpsswrdPSSWRDBXNM.Password.Length == 0)
            {
                MessageBox.Show("Don't leave the fields empty!");
            }
            else if (!nwpsswrdPSSWRDBXNM.Password.Equals(cnfrmnwpsswrdPSSWRDBXNM.Password))
            {
                MessageBox.Show("New password didn't match");
            }
            else if (nwpsswrdPSSWRDBXNM.Password.Length < 8)
            {
                MessageBox.Show("Password must be atleast 8 characters.");
            }
            else if (crrntpsswrdPSSWRDBXNM.Password.Equals(nwpsswrdPSSWRDBXNM.Password))
            {
                MessageBox.Show("Password is just the same.");
            }
            else
            {
                chkpass();
            }
        }

        private void chkpass()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM tblMasterPassword WHERE PasswordID=1 AND MasterPassword=@MasterPassword";

                SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
                sqlCMD.CommandType = CommandType.Text;
                sqlCMD.Parameters.AddWithValue("@MasterPassword", crrntpsswrdPSSWRDBXNM.Password);
                int count = Convert.ToInt32(sqlCMD.ExecuteScalar());

                if (count == 1)
                {
                    UpdateMasterPassword();
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

        private void UpdateMasterPassword()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            string cs = @"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand("UPDATE tblMasterPassword SET MasterPassword=@MasterPassword WHERE PasswordID=1", con))
            {
                cmd.Parameters.AddWithValue("@MasterPassword", nwpsswrdPSSWRDBXNM.Password);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Password updated");
                DialogResult = true;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
