using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdmissionWorkspace.xaml
    /// </summary>
    public partial class AdmissionWorkspace : Window
    {

        public string strMainWindowText_User { get; set; }

        public string strAdmissionWorkspaceText_User;

        public AdmissionWorkspace(string strMainWindowText_User)
        {
            InitializeComponent();

            CenterWindow();

            DisplayEnrollmentForm();

            SetOnProcess();

            strAdmissionWorkspaceText_User = strMainWindowText_User;
        }

        public void SetOnProcess() {
            String onprcssdflt = "Enrollment Form";
            onprocessNM.SetValue(TextBlock.TextProperty, onprcssdflt);
            onprocessNM.SetValue(ContentControl.ContentProperty, onprcssdflt);
            workframeNM.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void DisplayEnrollmentForm()
        {
            RegistrationFormPage rgstrtnfrmPG = new RegistrationFormPage();
            workframeNM.NavigationService.Navigate(rgstrtnfrmPG);
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

        private void Work_Click(object sender, RoutedEventArgs e)
        {
            RegistrationFormPage rgstrtnfrmPG = new RegistrationFormPage();
            workframeNM.NavigationService.Navigate(rgstrtnfrmPG);
            String onprcssdflt = "Enrollment Form";
            onprocessNM.SetValue(TextBlock.TextProperty, onprcssdflt);
            onprocessNM.SetValue(ContentControl.ContentProperty, onprcssdflt);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsPage sttngsPG = new SettingsPage(strAdmissionWorkspaceText_User);
            workframeNM.NavigationService.Navigate(sttngsPG);
            String onprcssdflt = "Settings";
            onprocessNM.SetValue(TextBlock.TextProperty, onprcssdflt);
            onprocessNM.SetValue(ContentControl.ContentProperty, onprcssdflt);
        }

        private void Student_Profile_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Profile");

            StudentProfilePage stdntprflpg = new StudentProfilePage();
            workframeNM.NavigationService.Navigate(stdntprflpg);
            String onprcssdflt = "Data";
            onprocessNM.SetValue(TextBlock.TextProperty, onprcssdflt);
            onprocessNM.SetValue(ContentControl.ContentProperty, onprcssdflt);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Log Out");

            string sMessageBoxText = "Log Out?";
            string sCaption = "";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:

                    MainWindow mnwndw = new MainWindow();
                    mnwndw.Show();
                    this.Close();

                    break;

                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
