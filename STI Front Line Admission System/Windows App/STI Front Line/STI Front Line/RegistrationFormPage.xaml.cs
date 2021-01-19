using MySql.Data.MySqlClient;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
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
    /// Interaction logic for RegistrationFormPage.xaml
    /// </summary>
    public partial class RegistrationFormPage : Page
    {
        int Transaction_ID;//insert
        string TRANSACTION_ID;//retrieve
        string transaction_idValue;
        string school_levelValue;
        string student_idValue;
        string courseValue;
        string year_or_gradeValue;
        string lrn_or_escValue;
        string student_nameValue;
        string birth_dateValue;
        string birth_placeValue;
        string citizenshipValue;
        string civil_statusValue;
        string genderValue;
        string current_addressValue;
        string permanent_addressValue;
        string landlineValue;
        string mobileValue;
        string emailValue;
        string previous_school_levelValue;
        string graduationValue;
        string last_school_attendedValue;
        string previous_levelValue;
        string previous_school_year_attendedValue;
        string previous_year_or_gradeValue;
        string termValue;
        string father_nameValue;
        string father_contact_noValue;
        string father_occupationValue;
        string father_emailValue;
        string mother_nameValue;
        string mother_contact_noValue;
        string mother_occupationValue;
        string mother_emailValue;
        string guardian_nameValue;
        string guardian_contact_noValue;
        string guardian_occupationValue;
        string guardian_emailValue;
        string time_and_date_enrolledValue;
        string school_yearValue;
        string convert;

        public RegistrationFormPage()
        {
            InitializeComponent();
        }

        private void snrhghschlCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            snrhghschlCHCKBXNM.IsChecked = true;
            cllgCHCKBXNM.IsChecked = false;
            nwstdntCHCKBXNM.IsChecked = false;
            trnsfrCHCKBXNM.IsChecked = false;
        }

        private void cllgCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            snrhghschlCHCKBXNM.IsChecked = false;
            cllgCHCKBXNM.IsChecked = true;
            nwstdntCHCKBXNM.IsChecked = false;
            trnsfrCHCKBXNM.IsChecked = false;
        }

        private void nwstdntCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            snrhghschlCHCKBXNM.IsChecked = false;
            cllgCHCKBXNM.IsChecked = false;
            nwstdntCHCKBXNM.IsChecked = true;
            trnsfrCHCKBXNM.IsChecked = false;
        }

        private void trnsfrCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            snrhghschlCHCKBXNM.IsChecked = false;
            cllgCHCKBXNM.IsChecked = false;
            nwstdntCHCKBXNM.IsChecked = false;
            trnsfrCHCKBXNM.IsChecked = true;
        }

        private void snglCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            snglCHCKBXNM.IsChecked = true;
            mrrdCHCKBXNM.IsChecked = false;
        }

        private void mrrdCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            snglCHCKBXNM.IsChecked = false;
            mrrdCHCKBXNM.IsChecked = true;
        }

        private void mCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            mCHCKBXNM.IsChecked = true;
            fCHCKBXNM.IsChecked = false;
        }

        private void fCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            mCHCKBXNM.IsChecked = false;
            fCHCKBXNM.IsChecked = true;
        }

        private void lstschlattnddhghschlCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            lstschlattnddhghschlCHCKBXNM.IsChecked = true;
            //lstschlattnddjnrhghschlCHCKBXNM.IsChecked = false;
            //lstschlattnddsnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddcllgCHCKBXNM.IsChecked = false;
            lstschlattnddllspptCHCKBXNM.IsChecked = false;
        }

        private void lstschlattnddjnrhghschlCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            lstschlattnddhghschlCHCKBXNM.IsChecked = true;
            lstschlattnddjnrhghschlCHCKBXNM.IsChecked = true;
            lstschlattnddsnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddcllgCHCKBXNM.IsChecked = false;
            lstschlattnddllspptCHCKBXNM.IsChecked = false;
        }

        private void lstschlattnddsnrhghschlCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            lstschlattnddhghschlCHCKBXNM.IsChecked = true;
            lstschlattnddjnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddsnrhghschlCHCKBXNM.IsChecked = true;
            lstschlattnddcllgCHCKBXNM.IsChecked = false;
            lstschlattnddllspptCHCKBXNM.IsChecked = false;
        }
        private void lstschlattnddcllgCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            lstschlattnddhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddjnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddsnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddcllgCHCKBXNM.IsChecked = true;
            lstschlattnddllspptCHCKBXNM.IsChecked = false;
        }

        private void lstschlattnddllspptCHCKBXNM_Checked(object sender, RoutedEventArgs e)
        {
            lstschlattnddhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddjnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddsnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddcllgCHCKBXNM.IsChecked = false;
            lstschlattnddllspptCHCKBXNM.IsChecked = true;
        }

        private void lstschlattnddhghschlCHCKBXNM_Unchecked(object sender, RoutedEventArgs e)
        {
            lstschlattnddhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddjnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddsnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddcllgCHCKBXNM.IsChecked = false;
            lstschlattnddllspptCHCKBXNM.IsChecked = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D && Keyboard.IsKeyDown(Key.LeftCtrl) || e.Key == Key.D && Keyboard.IsKeyDown(Key.RightCtrl))
            {
                Demo();
            }

            if (e.Key == Key.R && Keyboard.IsKeyDown(Key.LeftCtrl) || e.Key == Key.R && Keyboard.IsKeyDown(Key.RightCtrl))
            {
                Reset();
            }

            if (e.Key == Key.E && Keyboard.IsKeyDown(Key.LeftCtrl) || e.Key == Key.E && Keyboard.IsKeyDown(Key.RightCtrl))
            {
                demoEdit();
            }
            if (e.Key == Key.S && Keyboard.IsKeyDown(Key.LeftCtrl) || e.Key == Key.S && Keyboard.IsKeyDown(Key.RightCtrl))
            {
                Submit();
            }
            if (e.Key == Key.V && Keyboard.IsKeyDown(Key.LeftCtrl) || e.Key == Key.V && Keyboard.IsKeyDown(Key.RightCtrl))
            {
                ValidationSample();
            }
        }

        private void ValidationSample()
        {
            demomode = false;
            DemoReadOnlyOff();
            revertBorderDefault();
            snrhghschlCHCKBXNM.IsChecked = true;
            cllgCHCKBXNM.IsChecked = false;
            nwstdntCHCKBXNM.IsChecked = false;
            trnsfrCHCKBXNM.IsChecked = false;
            dnmbrTXTBXNM.SetValue(TextBox.TextProperty, "2000000001");
            chsnprgrmtrckstrndspclztnTXTBXNM.SetValue(TextBox.TextProperty, "I.T. In Mobile App And Web Development");
            yrgrdTXTBXNM.SetValue(TextBox.TextProperty, "Grade 11");
            lrnscnTXTBXNM.SetValue(TextBox.TextProperty, "400000000001");
            frstnmTXTBXNM.SetValue(TextBox.TextProperty, "Sheena Lyn");
            mddlnmTXTBXNM.SetValue(TextBox.TextProperty, "Turalba");
            lstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            sffxTXTBXNM.SetValue(TextBox.TextProperty, "");
            dtfbrthTXTBXNM.SetValue(TextBox.TextProperty, "02-29-2003");
            brtplcTXTBXNM.SetValue(TextBox.TextProperty, "Cebu City");
            ctznshpTXTBXNM.SetValue(TextBox.TextProperty, "");
            snglCHCKBXNM.IsChecked = true;
            mrrdCHCKBXNM.IsChecked = false;
            mCHCKBXNM.IsChecked = false;
            fCHCKBXNM.IsChecked = true;
            crrntddrsshsltuntnTXTBXNM.SetValue(TextBox.TextProperty, "102P. Torres");
            crrntddrssstrtTXTBXNM.SetValue(TextBox.TextProperty, "");
            crrntddrssbldngsbdvsnbrngyTXTBXNM.SetValue(TextBox.TextProperty, "Poblacion Barangay 5");
            crrntddrssctymncpltTXTBXNM.SetValue(TextBox.TextProperty, "Lipa City");
            crrntddrssprvncTXTBXNM.SetValue(TextBox.TextProperty, "Batangas");
            crrntddrsszpcdTXTBXNM.SetValue(TextBox.TextProperty, "4217");
            prmnntddrsshsltuntnTXTBXNM.SetValue(TextBox.TextProperty, "202");
            prmnntddrssstrtTXTBXNM.SetValue(TextBox.TextProperty, "M. L Tagarao Street");
            prmnntddrssbldngsbdvsnbrngyTXTBXNM.SetValue(TextBox.TextProperty, "Barangay 5");
            prmnntddrssctymncpltTXTBXNM.SetValue(TextBox.TextProperty, "Lucena City");
            prmnntddrssprvncTXTBXNM.SetValue(TextBox.TextProperty, "Quezon");
            prmnntddrsszpcdTXTBXNM.SetValue(TextBox.TextProperty, "4301`");
            lndlnTXTBXNM.SetValue(TextBox.TextProperty, "040 000-0000 z");
            mblTXTBXNM.SetValue(TextBox.TextProperty, "09000000000");
            mlTXTBXNM.SetValue(TextBox.TextProperty, "sheena g mail.com");
            lstschlattnddhghschlCHCKBXNM.IsChecked = true;
            lstschlattnddjnrhghschlCHCKBXNM.IsChecked = true;
            lstschlattnddsnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddllspptCHCKBXNM.IsChecked = false;
            lstschlattnddcllgCHCKBXNM.IsChecked = false;
            lstschlattndddtfgrdtnmTXTBXNM.SetValue(TextBox.TextProperty, "0");
            lstschlattndddtfgrdtnmmTXTBXNM.SetValue(TextBox.TextProperty, "4");
            lstschlattndddtfgrdtnmmdTXTBXNM.SetValue(TextBox.TextProperty, "5");
            lstschlattndddtfgrdtnmmddTXTBXNM.SetValue(TextBox.TextProperty, "9");
            lstschlattndddtfgrdtnmmddyTXTBXNM.SetValue(TextBox.TextProperty, "2");
            lstschlattndddtfgrdtnmmddyyTXTBXNM.SetValue(TextBox.TextProperty, "0");
            lstschlattndddtfgrdtnmmddyyyTXTBXNM.SetValue(TextBox.TextProperty, "1");
            lstschlattndddtfgrdtnmmddyyyyTXTBXNM.SetValue(TextBox.TextProperty, "8");
            lstschllttnddnmfschlTXTBXNM.SetValue(TextBox.TextProperty, "Lipa City National High School");
            lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.SetValue(TextBox.TextProperty, "Junior High School");
            lstschllttnddsy1TXTBXNM.SetValue(TextBox.TextProperty, "2016z");
            lstschllttnddsy2TXTBXNM.SetValue(TextBox.TextProperty, "2017");
            lstschllttnddyrgrdTXTBXNM.SetValue(TextBox.TextProperty, "Grade 10");
            lstschllttnddtrmTXTBXNM.SetValue(TextBox.TextProperty, "1");
            fthrsfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "Sergio");
            fthrsmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "T.");
            fthrslstnmTXTBXNM.SetValue(TextBox.TextProperty, "Infante");
            fthrssffxTXTBXNM.SetValue(TextBox.TextProperty, "Sr.");
            fthrsmblTXTBXNM.SetValue(TextBox.TextProperty, "09090000000");
            fthrsccptnTXTBXNM.SetValue(TextBox.TextProperty, "Computer Engineer");
            fthrsmlTXTBXNM.SetValue(TextBox.TextProperty, "sergio@gmail.com");
            mthrsfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "Samantha Marie");
            mthrsmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "T.");
            mthrslstnmTXTBXNM.SetValue(TextBox.TextProperty, "Infante");
            mthrssffxTXTBXNM.SetValue(TextBox.TextProperty, "I");
            mthrsmblTXTBXNM.SetValue(TextBox.TextProperty, "09090900000");
            mthrsccptnTXTBXNM.SetValue(TextBox.TextProperty, "Computer Scientist");
            mthrsmlTXTBXNM.SetValue(TextBox.TextProperty, "marie@gmail.com");
            dsgntdgrdnfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "Samantha Mae");
            dsgntdgrdnmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "T.");
            dsgntdgrdnlstnmTXTBXNM.SetValue(TextBox.TextProperty, "Infante");
            dsgntdgrdnsffxTXTBXNM.SetValue(TextBox.TextProperty, "II");
            dsgntdgrdnmblTXTBXNM.SetValue(TextBox.TextProperty, "");
            dsgntdgrdnccptnTXTBXNM.SetValue(TextBox.TextProperty, "IT Professional");
            dsgntdgrdnmlTXTBXNM.SetValue(TextBox.TextProperty, "");
            MessageBox.Show("Sample data for validation was set.");
        }

        private void demoEdit()
        {
            if (demomode == true)
            {
                demoSet();
                DemoReadOnlyOff();
                MessageBox.Show("Editing Allowed");
            }

        }

        bool demomode = false;

        private void Demo()
        {
            if (demomode == false)
            {
                demomode = true;
                demoSet();
                revertBorderDefault();
                MessageBox.Show("Demo Mode Activated");
                DemoReadOnlyOn();
            }
            else
            {
                MessageBox.Show("Demo mode is currect active");
            }

        }

        private void demoSet()
        {
            snrhghschlCHCKBXNM.IsChecked = true;
            cllgCHCKBXNM.IsChecked = false;
            nwstdntCHCKBXNM.IsChecked = false;
            trnsfrCHCKBXNM.IsChecked = false;
            dnmbrTXTBXNM.SetValue(TextBox.TextProperty, "02000000000");
            chsnprgrmtrckstrndspclztnTXTBXNM.SetValue(TextBox.TextProperty, "I.T. In Mobile App And Web Development");
            yrgrdTXTBXNM.SetValue(TextBox.TextProperty, "Grade 11");
            lrnscnTXTBXNM.SetValue(TextBox.TextProperty, "400000000000");
            frstnmTXTBXNM.SetValue(TextBox.TextProperty, "Sergio");
            mddlnmTXTBXNM.SetValue(TextBox.TextProperty, "Turalba");
            lstnmTXTBXNM.SetValue(TextBox.TextProperty, "Infante");
            sffxTXTBXNM.SetValue(TextBox.TextProperty, "Jr.");
            dtfbrthTXTBXNM.SetValue(TextBox.TextProperty, "08-30-2001");
            brtplcTXTBXNM.SetValue(TextBox.TextProperty, "Cebu City");
            ctznshpTXTBXNM.SetValue(TextBox.TextProperty, "Filipino");
            snglCHCKBXNM.IsChecked = true;
            mrrdCHCKBXNM.IsChecked = false;
            mCHCKBXNM.IsChecked = true;
            fCHCKBXNM.IsChecked = false;
            crrntddrsshsltuntnTXTBXNM.SetValue(TextBox.TextProperty, "102");
            crrntddrssstrtTXTBXNM.SetValue(TextBox.TextProperty, "P. Torres");
            crrntddrssbldngsbdvsnbrngyTXTBXNM.SetValue(TextBox.TextProperty, "Poblacion Barangay 5");
            crrntddrssctymncpltTXTBXNM.SetValue(TextBox.TextProperty, "Lipa City");
            crrntddrssprvncTXTBXNM.SetValue(TextBox.TextProperty, "Batangas");
            crrntddrsszpcdTXTBXNM.SetValue(TextBox.TextProperty, "4217");
            prmnntddrsshsltuntnTXTBXNM.SetValue(TextBox.TextProperty, "202");
            prmnntddrssstrtTXTBXNM.SetValue(TextBox.TextProperty, "M. L Tagarao Street");
            prmnntddrssbldngsbdvsnbrngyTXTBXNM.SetValue(TextBox.TextProperty, "Barangay 5");
            prmnntddrssctymncpltTXTBXNM.SetValue(TextBox.TextProperty, "Lucena City");
            prmnntddrssprvncTXTBXNM.SetValue(TextBox.TextProperty, "Quezon");
            prmnntddrsszpcdTXTBXNM.SetValue(TextBox.TextProperty, "4301");
            lndlnTXTBXNM.SetValue(TextBox.TextProperty, "040 000-0000");
            mblTXTBXNM.SetValue(TextBox.TextProperty, "09000000000");
            mlTXTBXNM.SetValue(TextBox.TextProperty, "serge@gmail.com");
            lstschlattnddhghschlCHCKBXNM.IsChecked = true;
            lstschlattnddjnrhghschlCHCKBXNM.IsChecked = true;
            lstschlattnddsnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddllspptCHCKBXNM.IsChecked = false;
            lstschlattnddcllgCHCKBXNM.IsChecked = false;
            lstschlattndddtfgrdtnmTXTBXNM.SetValue(TextBox.TextProperty, "0");
            lstschlattndddtfgrdtnmmTXTBXNM.SetValue(TextBox.TextProperty, "4");
            lstschlattndddtfgrdtnmmdTXTBXNM.SetValue(TextBox.TextProperty, "0");
            lstschlattndddtfgrdtnmmddTXTBXNM.SetValue(TextBox.TextProperty, "9");
            lstschlattndddtfgrdtnmmddyTXTBXNM.SetValue(TextBox.TextProperty, "2");
            lstschlattndddtfgrdtnmmddyyTXTBXNM.SetValue(TextBox.TextProperty, "0");
            lstschlattndddtfgrdtnmmddyyyTXTBXNM.SetValue(TextBox.TextProperty, "1");
            lstschlattndddtfgrdtnmmddyyyyTXTBXNM.SetValue(TextBox.TextProperty, "8");
            lstschllttnddnmfschlTXTBXNM.SetValue(TextBox.TextProperty, "Lipa City National High School");
            lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.SetValue(TextBox.TextProperty, "Junior High School");
            lstschllttnddsy1TXTBXNM.SetValue(TextBox.TextProperty, "2016");
            lstschllttnddsy2TXTBXNM.SetValue(TextBox.TextProperty, "2017");
            lstschllttnddyrgrdTXTBXNM.SetValue(TextBox.TextProperty, "Grade 10");
            lstschllttnddtrmTXTBXNM.SetValue(TextBox.TextProperty, "1");
            fthrsfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "Sergio");
            fthrsmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "T.");
            fthrslstnmTXTBXNM.SetValue(TextBox.TextProperty, "Infante");
            fthrssffxTXTBXNM.SetValue(TextBox.TextProperty, "Sr.");
            fthrsmblTXTBXNM.SetValue(TextBox.TextProperty, "09090000000");
            fthrsccptnTXTBXNM.SetValue(TextBox.TextProperty, "Computer Engineer");
            fthrsmlTXTBXNM.SetValue(TextBox.TextProperty, "sergio@gmail.com");
            mthrsfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "Samantha Marie");
            mthrsmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "T.");
            mthrslstnmTXTBXNM.SetValue(TextBox.TextProperty, "Infante");
            mthrssffxTXTBXNM.SetValue(TextBox.TextProperty, "I");
            mthrsmblTXTBXNM.SetValue(TextBox.TextProperty, "09090900000");
            mthrsccptnTXTBXNM.SetValue(TextBox.TextProperty, "Computer Scientist");
            mthrsmlTXTBXNM.SetValue(TextBox.TextProperty, "marie@gmail.com");
            dsgntdgrdnfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "Samantha Mae");
            dsgntdgrdnmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "T.");
            dsgntdgrdnlstnmTXTBXNM.SetValue(TextBox.TextProperty, "Infante");
            dsgntdgrdnsffxTXTBXNM.SetValue(TextBox.TextProperty, "II");
            dsgntdgrdnmblTXTBXNM.SetValue(TextBox.TextProperty, "09090909000");
            dsgntdgrdnccptnTXTBXNM.SetValue(TextBox.TextProperty, "IT Professional");
            dsgntdgrdnmlTXTBXNM.SetValue(TextBox.TextProperty, "mae@gmail.com");
        }

        private void DemoReadOnlyOn()
        {
            snrhghschlCHCKBXNM.IsHitTestVisible = false;
            cllgCHCKBXNM.IsHitTestVisible = false;
            nwstdntCHCKBXNM.IsHitTestVisible = false;
            trnsfrCHCKBXNM.IsHitTestVisible = false;
            dnmbrTXTBXNM.IsHitTestVisible = false;
            chsnprgrmtrckstrndspclztnTXTBXNM.IsHitTestVisible = false;
            yrgrdTXTBXNM.IsHitTestVisible = false;
            lrnscnTXTBXNM.IsHitTestVisible = false;
            frstnmTXTBXNM.IsHitTestVisible = false;
            mddlnmTXTBXNM.IsHitTestVisible = false;
            lstnmTXTBXNM.IsHitTestVisible = false;
            sffxTXTBXNM.IsHitTestVisible = false;
            dtfbrthTXTBXNM.IsHitTestVisible = false;
            brtplcTXTBXNM.IsHitTestVisible = false;
            ctznshpTXTBXNM.IsHitTestVisible = false;
            snglCHCKBXNM.IsHitTestVisible = false;
            mrrdCHCKBXNM.IsHitTestVisible = false;
            mCHCKBXNM.IsHitTestVisible = false;
            fCHCKBXNM.IsHitTestVisible = false;
            crrntddrsshsltuntnTXTBXNM.IsHitTestVisible = false;
            crrntddrssstrtTXTBXNM.IsHitTestVisible = false;
            crrntddrssbldngsbdvsnbrngyTXTBXNM.IsHitTestVisible = false;
            crrntddrssctymncpltTXTBXNM.IsHitTestVisible = false;
            crrntddrssprvncTXTBXNM.IsHitTestVisible = false;
            crrntddrsszpcdTXTBXNM.IsHitTestVisible = false;
            prmnntddrsshsltuntnTXTBXNM.IsHitTestVisible = false;
            prmnntddrssstrtTXTBXNM.IsHitTestVisible = false;
            prmnntddrssbldngsbdvsnbrngyTXTBXNM.IsHitTestVisible = false;
            prmnntddrssctymncpltTXTBXNM.IsHitTestVisible = false;
            prmnntddrssprvncTXTBXNM.IsHitTestVisible = false;
            prmnntddrsszpcdTXTBXNM.IsHitTestVisible = false;
            lndlnTXTBXNM.IsHitTestVisible = false;
            mblTXTBXNM.IsHitTestVisible = false;
            mlTXTBXNM.IsHitTestVisible = false;
            lstschlattnddhghschlCHCKBXNM.IsHitTestVisible = false;
            lstschlattnddjnrhghschlCHCKBXNM.IsHitTestVisible = false;
            lstschlattnddsnrhghschlCHCKBXNM.IsHitTestVisible = false;
            lstschlattnddllspptCHCKBXNM.IsHitTestVisible = false;
            lstschlattnddcllgCHCKBXNM.IsHitTestVisible = false;
            lstschlattndddtfgrdtnmTXTBXNM.IsHitTestVisible = false;
            lstschlattndddtfgrdtnmmTXTBXNM.IsHitTestVisible = false;
            lstschlattndddtfgrdtnmmdTXTBXNM.IsHitTestVisible = false;
            lstschlattndddtfgrdtnmmddTXTBXNM.IsHitTestVisible = false;
            lstschlattndddtfgrdtnmmddyTXTBXNM.IsHitTestVisible = false;
            lstschlattndddtfgrdtnmmddyyTXTBXNM.IsHitTestVisible = false;
            lstschlattndddtfgrdtnmmddyyyTXTBXNM.IsHitTestVisible = false;
            lstschlattndddtfgrdtnmmddyyyyTXTBXNM.IsHitTestVisible = false;
            lstschllttnddnmfschlTXTBXNM.IsHitTestVisible = false;
            lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.IsHitTestVisible = false;
            lstschllttnddsy1TXTBXNM.IsHitTestVisible = false;
            lstschllttnddsy2TXTBXNM.IsHitTestVisible = false;
            lstschllttnddyrgrdTXTBXNM.IsHitTestVisible = false;
            lstschllttnddtrmTXTBXNM.IsHitTestVisible = false;
            fthrsfrstnmTXTBXNM.IsHitTestVisible = false;
            fthrsmddlntlTXTBXNM.IsHitTestVisible = false;
            fthrslstnmTXTBXNM.IsHitTestVisible = false;
            fthrssffxTXTBXNM.IsHitTestVisible = false;
            fthrsmblTXTBXNM.IsHitTestVisible = false;
            fthrsccptnTXTBXNM.IsHitTestVisible = false;
            fthrsmlTXTBXNM.IsHitTestVisible = false;
            mthrsfrstnmTXTBXNM.IsHitTestVisible = false;
            mthrsmddlntlTXTBXNM.IsHitTestVisible = false;
            mthrslstnmTXTBXNM.IsHitTestVisible = false;
            mthrssffxTXTBXNM.IsHitTestVisible = false;
            mthrsmblTXTBXNM.IsHitTestVisible = false;
            mthrsccptnTXTBXNM.IsHitTestVisible = false;
            mthrsmlTXTBXNM.IsHitTestVisible = false;
            dsgntdgrdnfrstnmTXTBXNM.IsHitTestVisible = false;
            dsgntdgrdnmddlntlTXTBXNM.IsHitTestVisible = false;
            dsgntdgrdnlstnmTXTBXNM.IsHitTestVisible = false;
            dsgntdgrdnsffxTXTBXNM.IsHitTestVisible = false;
            dsgntdgrdnmblTXTBXNM.IsHitTestVisible = false;
            dsgntdgrdnccptnTXTBXNM.IsHitTestVisible = false;
            dsgntdgrdnmlTXTBXNM.IsHitTestVisible = false;
        }

        private void Reset()
        {
            demomode = false;
            clearInput();
            revertBorderDefault();
            MessageBox.Show("Information are cleared.");
            DemoReadOnlyOff();
        }

        private void revertBorderDefault()
        {
            snrhghschlCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            cllgCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            nwstdntCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            trnsfrCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);

            dnmbrTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            chsnprgrmtrckstrndspclztnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            yrgrdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lrnscnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            frstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            mddlnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            sffxTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            dtfbrthTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            brtplcTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            ctznshpTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            snglCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            mrrdCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);

            mCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            fCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);

            crrntddrsshsltuntnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            crrntddrssstrtTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            crrntddrssbldngsbdvsnbrngyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            crrntddrssctymncpltTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            crrntddrssprvncTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            crrntddrsszpcdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lndlnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            mblTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            mlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattnddhghschlCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattnddjnrhghschlCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattnddsnrhghschlCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattnddllspptCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattnddcllgCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattndddtfgrdtnmmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattndddtfgrdtnmmdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattndddtfgrdtnmmddTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattndddtfgrdtnmmddyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattndddtfgrdtnmmddyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattndddtfgrdtnmmddyyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            lstschlattndddtfgrdtnmmddyyyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschllttnddnmfschlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschllttnddsy1TXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschllttnddsy2TXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschllttnddyrgrdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschllttnddtrmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            fthrsfrstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            fthrsmddlntlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            fthrslstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            fthrssffxTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            fthrsmblTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            fthrsmlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            fthrsccptnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            mthrsfrstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            mthrsmddlntlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            mthrslstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            mthrssffxTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            mthrsmblTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
            mthrsmlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            mthrsccptnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            //***********************************************

            prmnntddrsshsltuntnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            prmnntddrsszpcdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmmdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmmddTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmmddyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmmddyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmmddyyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            lstschlattndddtfgrdtnmmddyyyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            dsgntdgrdnfrstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            dsgntdgrdnmddlntlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            dsgntdgrdnlstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            dsgntdgrdnsffxTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            dsgntdgrdnmblTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            dsgntdgrdnccptnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

            dsgntdgrdnmlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);

        }

        private void clearInput()
        {
            snrhghschlCHCKBXNM.IsChecked = false;
            cllgCHCKBXNM.IsChecked = false;
            nwstdntCHCKBXNM.IsChecked = false;
            trnsfrCHCKBXNM.IsChecked = false;
            dnmbrTXTBXNM.SetValue(TextBox.TextProperty, "");
            chsnprgrmtrckstrndspclztnTXTBXNM.SetValue(TextBox.TextProperty, "");
            yrgrdTXTBXNM.SetValue(TextBox.TextProperty, "");
            lrnscnTXTBXNM.SetValue(TextBox.TextProperty, "");
            frstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            mddlnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            sffxTXTBXNM.SetValue(TextBox.TextProperty, "");
            dtfbrthTXTBXNM.SetValue(TextBox.TextProperty, "");
            brtplcTXTBXNM.SetValue(TextBox.TextProperty, "");
            ctznshpTXTBXNM.SetValue(TextBox.TextProperty, "");
            snglCHCKBXNM.IsChecked = false;
            mrrdCHCKBXNM.IsChecked = false;
            mCHCKBXNM.IsChecked = false;
            fCHCKBXNM.IsChecked = false;
            crrntddrsshsltuntnTXTBXNM.SetValue(TextBox.TextProperty, "");
            crrntddrssstrtTXTBXNM.SetValue(TextBox.TextProperty, "");
            crrntddrssbldngsbdvsnbrngyTXTBXNM.SetValue(TextBox.TextProperty, "");
            crrntddrssctymncpltTXTBXNM.SetValue(TextBox.TextProperty, "");
            crrntddrssprvncTXTBXNM.SetValue(TextBox.TextProperty, "");
            crrntddrsszpcdTXTBXNM.SetValue(TextBox.TextProperty, "");
            prmnntddrsshsltuntnTXTBXNM.SetValue(TextBox.TextProperty, "");
            prmnntddrssstrtTXTBXNM.SetValue(TextBox.TextProperty, "");
            prmnntddrssbldngsbdvsnbrngyTXTBXNM.SetValue(TextBox.TextProperty, "");
            prmnntddrssctymncpltTXTBXNM.SetValue(TextBox.TextProperty, "");
            prmnntddrssprvncTXTBXNM.SetValue(TextBox.TextProperty, "");
            prmnntddrsszpcdTXTBXNM.SetValue(TextBox.TextProperty, "");
            lndlnTXTBXNM.SetValue(TextBox.TextProperty, "");
            mblTXTBXNM.SetValue(TextBox.TextProperty, "");
            mlTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschlattnddhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddjnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddsnrhghschlCHCKBXNM.IsChecked = false;
            lstschlattnddllspptCHCKBXNM.IsChecked = false;
            lstschlattnddcllgCHCKBXNM.IsChecked = false;
            lstschlattndddtfgrdtnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschlattndddtfgrdtnmmTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschlattndddtfgrdtnmmdTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschlattndddtfgrdtnmmddTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschlattndddtfgrdtnmmddyTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschlattndddtfgrdtnmmddyyTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschlattndddtfgrdtnmmddyyyTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschlattndddtfgrdtnmmddyyyyTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschllttnddnmfschlTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschllttnddsy1TXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschllttnddsy2TXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschllttnddyrgrdTXTBXNM.SetValue(TextBox.TextProperty, "");
            lstschllttnddtrmTXTBXNM.SetValue(TextBox.TextProperty, "");
            fthrsfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            fthrsmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "");
            fthrslstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            fthrssffxTXTBXNM.SetValue(TextBox.TextProperty, "");
            fthrsmblTXTBXNM.SetValue(TextBox.TextProperty, "");
            fthrsccptnTXTBXNM.SetValue(TextBox.TextProperty, "");
            fthrsmlTXTBXNM.SetValue(TextBox.TextProperty, "");
            mthrsfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            mthrsmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "");
            mthrslstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            mthrssffxTXTBXNM.SetValue(TextBox.TextProperty, "");
            mthrsmblTXTBXNM.SetValue(TextBox.TextProperty, "");
            mthrsccptnTXTBXNM.SetValue(TextBox.TextProperty, "");
            mthrsmlTXTBXNM.SetValue(TextBox.TextProperty, "");
            dsgntdgrdnfrstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            dsgntdgrdnmddlntlTXTBXNM.SetValue(TextBox.TextProperty, "");
            dsgntdgrdnlstnmTXTBXNM.SetValue(TextBox.TextProperty, "");
            dsgntdgrdnsffxTXTBXNM.SetValue(TextBox.TextProperty, "");
            dsgntdgrdnmblTXTBXNM.SetValue(TextBox.TextProperty, "");
            dsgntdgrdnccptnTXTBXNM.SetValue(TextBox.TextProperty, "");
            dsgntdgrdnmlTXTBXNM.SetValue(TextBox.TextProperty, "");
        }

        private void DemoReadOnlyOff()
        {
            snrhghschlCHCKBXNM.IsHitTestVisible = true;
            cllgCHCKBXNM.IsHitTestVisible = true;
            nwstdntCHCKBXNM.IsHitTestVisible = true;
            trnsfrCHCKBXNM.IsHitTestVisible = true;
            dnmbrTXTBXNM.IsHitTestVisible = true;
            chsnprgrmtrckstrndspclztnTXTBXNM.IsHitTestVisible = true;
            yrgrdTXTBXNM.IsHitTestVisible = true;
            lrnscnTXTBXNM.IsHitTestVisible = true;
            frstnmTXTBXNM.IsHitTestVisible = true;
            mddlnmTXTBXNM.IsHitTestVisible = true;
            lstnmTXTBXNM.IsHitTestVisible = true;
            sffxTXTBXNM.IsHitTestVisible = true;
            dtfbrthTXTBXNM.IsHitTestVisible = true;
            brtplcTXTBXNM.IsHitTestVisible = true;
            ctznshpTXTBXNM.IsHitTestVisible = true;
            snglCHCKBXNM.IsHitTestVisible = true;
            mrrdCHCKBXNM.IsHitTestVisible = true;
            mCHCKBXNM.IsHitTestVisible = true;
            fCHCKBXNM.IsHitTestVisible = true;
            crrntddrsshsltuntnTXTBXNM.IsHitTestVisible = true;
            crrntddrssstrtTXTBXNM.IsHitTestVisible = true;
            crrntddrssbldngsbdvsnbrngyTXTBXNM.IsHitTestVisible = true;
            crrntddrssctymncpltTXTBXNM.IsHitTestVisible = true;
            crrntddrssprvncTXTBXNM.IsHitTestVisible = true;
            crrntddrsszpcdTXTBXNM.IsHitTestVisible = true;
            prmnntddrsshsltuntnTXTBXNM.IsHitTestVisible = true;
            prmnntddrssstrtTXTBXNM.IsHitTestVisible = true;
            prmnntddrssbldngsbdvsnbrngyTXTBXNM.IsHitTestVisible = true;
            prmnntddrssctymncpltTXTBXNM.IsHitTestVisible = true;
            prmnntddrssprvncTXTBXNM.IsHitTestVisible = true;
            prmnntddrsszpcdTXTBXNM.IsHitTestVisible = true;
            lndlnTXTBXNM.IsHitTestVisible = true;
            mblTXTBXNM.IsHitTestVisible = true;
            mlTXTBXNM.IsHitTestVisible = true;
            lstschlattnddhghschlCHCKBXNM.IsHitTestVisible = true;
            lstschlattnddjnrhghschlCHCKBXNM.IsHitTestVisible = true;
            lstschlattnddsnrhghschlCHCKBXNM.IsHitTestVisible = true;
            lstschlattnddllspptCHCKBXNM.IsHitTestVisible = true;
            lstschlattnddcllgCHCKBXNM.IsHitTestVisible = true;
            lstschlattndddtfgrdtnmTXTBXNM.IsHitTestVisible = true;
            lstschlattndddtfgrdtnmmTXTBXNM.IsHitTestVisible = true;
            lstschlattndddtfgrdtnmmdTXTBXNM.IsHitTestVisible = true;
            lstschlattndddtfgrdtnmmddTXTBXNM.IsHitTestVisible = true;
            lstschlattndddtfgrdtnmmddyTXTBXNM.IsHitTestVisible = true;
            lstschlattndddtfgrdtnmmddyyTXTBXNM.IsHitTestVisible = true;
            lstschlattndddtfgrdtnmmddyyyTXTBXNM.IsHitTestVisible = true;
            lstschlattndddtfgrdtnmmddyyyyTXTBXNM.IsHitTestVisible = true;
            lstschllttnddnmfschlTXTBXNM.IsHitTestVisible = true;
            lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.IsHitTestVisible = true;
            lstschllttnddsy1TXTBXNM.IsHitTestVisible = true;
            lstschllttnddsy2TXTBXNM.IsHitTestVisible = true;
            lstschllttnddyrgrdTXTBXNM.IsHitTestVisible = true;
            lstschllttnddtrmTXTBXNM.IsHitTestVisible = true;
            fthrsfrstnmTXTBXNM.IsHitTestVisible = true;
            fthrsmddlntlTXTBXNM.IsHitTestVisible = true;
            fthrslstnmTXTBXNM.IsHitTestVisible = true;
            fthrssffxTXTBXNM.IsHitTestVisible = true;
            fthrsmblTXTBXNM.IsHitTestVisible = true;
            fthrsccptnTXTBXNM.IsHitTestVisible = true;
            fthrsmlTXTBXNM.IsHitTestVisible = true;
            mthrsfrstnmTXTBXNM.IsHitTestVisible = true;
            mthrsmddlntlTXTBXNM.IsHitTestVisible = true;
            mthrslstnmTXTBXNM.IsHitTestVisible = true;
            mthrssffxTXTBXNM.IsHitTestVisible = true;
            mthrsmblTXTBXNM.IsHitTestVisible = true;
            mthrsccptnTXTBXNM.IsHitTestVisible = true;
            mthrsmlTXTBXNM.IsHitTestVisible = true;
            dsgntdgrdnfrstnmTXTBXNM.IsHitTestVisible = true;
            dsgntdgrdnmddlntlTXTBXNM.IsHitTestVisible = true;
            dsgntdgrdnlstnmTXTBXNM.IsHitTestVisible = true;
            dsgntdgrdnsffxTXTBXNM.IsHitTestVisible = true;
            dsgntdgrdnmblTXTBXNM.IsHitTestVisible = true;
            dsgntdgrdnccptnTXTBXNM.IsHitTestVisible = true;
            dsgntdgrdnmlTXTBXNM.IsHitTestVisible = true;
        }

        private void resetBTTN_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void submitBTTN_Click(object sender, RoutedEventArgs e)
        {
            Submit();
        }

        private void Submit()
        {
            getDataFromForm();
            validateData();
        }

        private void validateData()
        {

            DateTime tempDate;


            if (
                (snrhghschlCHCKBXNM.IsChecked == false && cllgCHCKBXNM.IsChecked == false && nwstdntCHCKBXNM.IsChecked == false && trnsfrCHCKBXNM.IsChecked == false) ||
                (dnmbrTXTBXNM.Text.Length == 0) ||
                (chsnprgrmtrckstrndspclztnTXTBXNM.Text.Length == 0) ||
                (yrgrdTXTBXNM.Text.Length == 0) ||
                (lrnscnTXTBXNM.Text.Length == 0) ||
                (frstnmTXTBXNM.Text.Length == 0) ||
                (mddlnmTXTBXNM.Text.Length == 0) ||
                (lstnmTXTBXNM.Text.Length == 0) ||
                (frstnmTXTBXNM.Text.Length == 0 && mddlnmTXTBXNM.Text.Length == 0 && lstnmTXTBXNM.Text.Length == 0 && sffxTXTBXNM.Text.Length == 0) ||
                (dtfbrthTXTBXNM.Text.Length == 0) ||
                (brtplcTXTBXNM.Text.Length == 0) ||
                (ctznshpTXTBXNM.Text.Length == 0) ||
                (snglCHCKBXNM.IsChecked == false && mrrdCHCKBXNM.IsChecked == false) ||
                (mCHCKBXNM.IsChecked == false && fCHCKBXNM.IsChecked == false) ||
                (crrntddrsshsltuntnTXTBXNM.Text.Length == 0 && crrntddrssstrtTXTBXNM.Text.Length == 0 && crrntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length == 0 && crrntddrssctymncpltTXTBXNM.Text.Length == 0 && crrntddrssprvncTXTBXNM.Text.Length == 0 && crrntddrsszpcdTXTBXNM.Text.Length == 0) ||
                (lndlnTXTBXNM.Text.Length == 0 && mblTXTBXNM.Text.Length == 0 && mlTXTBXNM.Text.Length == 0) ||
                (lstschlattnddhghschlCHCKBXNM.IsChecked == false && lstschlattnddjnrhghschlCHCKBXNM.IsChecked == false && lstschlattnddsnrhghschlCHCKBXNM.IsChecked == false && lstschlattnddllspptCHCKBXNM.IsChecked == false && lstschlattnddcllgCHCKBXNM.IsChecked == false) ||
                (
                    lstschlattnddhghschlCHCKBXNM.IsChecked == false && lstschlattnddjnrhghschlCHCKBXNM.IsChecked == false && lstschlattnddsnrhghschlCHCKBXNM.IsChecked == false && lstschlattnddllspptCHCKBXNM.IsChecked == false && lstschlattnddcllgCHCKBXNM.IsChecked == false &&
                    lstschlattndddtfgrdtnmTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmdTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddyTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddyyTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddyyyTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddyyyyTXTBXNM.Text.Length == 0 &&
                    lstschllttnddnmfschlTXTBXNM.Text.Length == 0 && lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.Text.Length == 0 && lstschllttnddsy1TXTBXNM.Text.Length == 0 && lstschllttnddsy2TXTBXNM.Text.Length == 0 && lstschllttnddyrgrdTXTBXNM.Text.Length == 0 && lstschllttnddtrmTXTBXNM.Text.Length == 0
                    ) ||
                (lstschllttnddnmfschlTXTBXNM.Text.Length == 0) ||
                (lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.Text.Length == 0) ||
                (lstschllttnddsy1TXTBXNM.Text.Length == 0) ||
                (lstschllttnddsy2TXTBXNM.Text.Length == 0) ||
                (lstschllttnddyrgrdTXTBXNM.Text.Length == 0) ||
                (lstschllttnddtrmTXTBXNM.Text.Length == 0) ||
                (fthrsfrstnmTXTBXNM.Text.Length == 0) ||
                (fthrsmddlntlTXTBXNM.Text.Length == 0) ||
                (fthrslstnmTXTBXNM.Text.Length == 0) ||
                (fthrsfrstnmTXTBXNM.Text.Length == 0 && fthrsmddlntlTXTBXNM.Text.Length == 0 && fthrslstnmTXTBXNM.Text.Length == 0 && fthrssffxTXTBXNM.Text.Length == 0) ||
                (fthrsmblTXTBXNM.Text.Length == 0 && fthrsmlTXTBXNM.Text.Length == 0) ||
                (fthrsccptnTXTBXNM.Text.Length == 0) ||
                (mthrsfrstnmTXTBXNM.Text.Length == 0) ||
                (mthrsmddlntlTXTBXNM.Text.Length == 0) ||
                (mthrslstnmTXTBXNM.Text.Length == 0) ||
                (mthrsfrstnmTXTBXNM.Text.Length == 0 && mthrsmddlntlTXTBXNM.Text.Length == 0 && mthrslstnmTXTBXNM.Text.Length == 0 && mthrssffxTXTBXNM.Text.Length == 0) ||
                (mthrsmblTXTBXNM.Text.Length == 0 && mthrsmlTXTBXNM.Text.Length == 0) ||
                (mthrsccptnTXTBXNM.Text.Length == 0)

                )
            {
                if (snrhghschlCHCKBXNM.IsChecked == false && cllgCHCKBXNM.IsChecked == false && nwstdntCHCKBXNM.IsChecked == false && trnsfrCHCKBXNM.IsChecked == false)
                {
                    snrhghschlCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    cllgCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    nwstdntCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    trnsfrCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    snrhghschlCHCKBXNM.BringIntoView();
                    cllgCHCKBXNM.BringIntoView();
                    nwstdntCHCKBXNM.BringIntoView();
                    trnsfrCHCKBXNM.BringIntoView();
                }
                else
                {
                    snrhghschlCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    cllgCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    nwstdntCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    trnsfrCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (dnmbrTXTBXNM.Text.Length == 0)
                {
                    dnmbrTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    dnmbrTXTBXNM.BringIntoView();
                }
                else
                {
                    dnmbrTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (chsnprgrmtrckstrndspclztnTXTBXNM.Text.Length == 0)
                {
                    chsnprgrmtrckstrndspclztnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    chsnprgrmtrckstrndspclztnTXTBXNM.BringIntoView();
                }
                else
                {
                    chsnprgrmtrckstrndspclztnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (yrgrdTXTBXNM.Text.Length == 0)
                {
                    yrgrdTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    yrgrdTXTBXNM.BringIntoView();
                }
                else
                {
                    yrgrdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lrnscnTXTBXNM.Text.Length == 0)
                {
                    lrnscnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lrnscnTXTBXNM.BringIntoView();
                }
                else
                {
                    lrnscnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (frstnmTXTBXNM.Text.Length == 0)
                {
                    frstnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    frstnmTXTBXNM.BringIntoView();
                }
                else
                {
                    frstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (mddlnmTXTBXNM.Text.Length == 0)
                {
                    mddlnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mddlnmTXTBXNM.BringIntoView();
                }
                else
                {
                    mddlnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lstnmTXTBXNM.Text.Length == 0)
                {
                    lstnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstnmTXTBXNM.BringIntoView();
                }
                else
                {
                    lstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (frstnmTXTBXNM.Text.Length == 0 && mddlnmTXTBXNM.Text.Length == 0 && lstnmTXTBXNM.Text.Length == 0 && sffxTXTBXNM.Text.Length == 0)
                {
                    sffxTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    sffxTXTBXNM.BringIntoView();
                }
                else
                {
                    sffxTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (dtfbrthTXTBXNM.Text.Length == 0)
                {
                    dtfbrthTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    dtfbrthTXTBXNM.BringIntoView();
                }
                else
                {
                    dtfbrthTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (brtplcTXTBXNM.Text.Length == 0)
                {
                    brtplcTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    brtplcTXTBXNM.BringIntoView();
                }
                else
                {
                    brtplcTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (ctznshpTXTBXNM.Text.Length == 0)
                {
                    ctznshpTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    ctznshpTXTBXNM.BringIntoView();
                }
                else
                {
                    ctznshpTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (snglCHCKBXNM.IsChecked == false && mrrdCHCKBXNM.IsChecked == false)
                {
                    snglCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mrrdCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    snglCHCKBXNM.BringIntoView();
                    mrrdCHCKBXNM.BringIntoView();
                }
                else
                {
                    snglCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    mrrdCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (mCHCKBXNM.IsChecked == false && fCHCKBXNM.IsChecked == false)
                {
                    mCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    fCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mCHCKBXNM.BringIntoView();
                    fCHCKBXNM.BringIntoView();
                }
                else
                {
                    mCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    fCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (crrntddrsshsltuntnTXTBXNM.Text.Length == 0 && crrntddrssstrtTXTBXNM.Text.Length == 0 && crrntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length == 0 && crrntddrssctymncpltTXTBXNM.Text.Length == 0 && crrntddrssprvncTXTBXNM.Text.Length == 0 && crrntddrsszpcdTXTBXNM.Text.Length == 0)
                {
                    crrntddrsshsltuntnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    crrntddrssstrtTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    crrntddrssbldngsbdvsnbrngyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    crrntddrssctymncpltTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    crrntddrssprvncTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    crrntddrsszpcdTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    crrntddrsshsltuntnTXTBXNM.BringIntoView();
                    crrntddrssstrtTXTBXNM.BringIntoView();
                    crrntddrssbldngsbdvsnbrngyTXTBXNM.BringIntoView();
                    crrntddrssctymncpltTXTBXNM.BringIntoView();
                    crrntddrssprvncTXTBXNM.BringIntoView();
                    crrntddrsszpcdTXTBXNM.BringIntoView();
                }
                else
                {
                    crrntddrsshsltuntnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    crrntddrssstrtTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    crrntddrssbldngsbdvsnbrngyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    crrntddrssctymncpltTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    crrntddrssprvncTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    crrntddrsszpcdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lndlnTXTBXNM.Text.Length == 0 && mblTXTBXNM.Text.Length == 0 && mlTXTBXNM.Text.Length == 0)
                {
                    lndlnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mblTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lndlnTXTBXNM.BringIntoView();
                    mblTXTBXNM.BringIntoView();
                    mlTXTBXNM.BringIntoView();
                }
                else
                {
                    lndlnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    mblTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    mlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lstschlattnddhghschlCHCKBXNM.IsChecked == false && lstschlattnddjnrhghschlCHCKBXNM.IsChecked == false && lstschlattnddsnrhghschlCHCKBXNM.IsChecked == false && lstschlattnddllspptCHCKBXNM.IsChecked == false && lstschlattnddcllgCHCKBXNM.IsChecked == false)
                {
                    lstschlattnddhghschlCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattnddjnrhghschlCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattnddsnrhghschlCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattnddllspptCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattnddcllgCHCKBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattnddhghschlCHCKBXNM.BringIntoView();
                    lstschlattnddjnrhghschlCHCKBXNM.BringIntoView();
                    lstschlattnddsnrhghschlCHCKBXNM.BringIntoView();
                    lstschlattnddllspptCHCKBXNM.BringIntoView();
                    lstschlattnddcllgCHCKBXNM.BringIntoView();
                }
                else
                {
                    lstschlattnddhghschlCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattnddjnrhghschlCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattnddsnrhghschlCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattnddllspptCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattnddcllgCHCKBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (
                    lstschlattnddhghschlCHCKBXNM.IsChecked == false && lstschlattnddjnrhghschlCHCKBXNM.IsChecked == false && lstschlattnddsnrhghschlCHCKBXNM.IsChecked == false && lstschlattnddllspptCHCKBXNM.IsChecked == false && lstschlattnddcllgCHCKBXNM.IsChecked == false &&
                    lstschlattndddtfgrdtnmTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmdTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddyTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddyyTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddyyyTXTBXNM.Text.Length == 0 && lstschlattndddtfgrdtnmmddyyyyTXTBXNM.Text.Length == 0 &&
                    lstschllttnddnmfschlTXTBXNM.Text.Length == 0 && lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.Text.Length == 0 && lstschllttnddsy1TXTBXNM.Text.Length == 0 && lstschllttnddsy2TXTBXNM.Text.Length == 0 && lstschllttnddyrgrdTXTBXNM.Text.Length == 0 && lstschllttnddtrmTXTBXNM.Text.Length == 0
                    )
                {
                    lstschlattndddtfgrdtnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattndddtfgrdtnmmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattndddtfgrdtnmmdTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattndddtfgrdtnmmddTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattndddtfgrdtnmmddyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattndddtfgrdtnmmddyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattndddtfgrdtnmmddyyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattndddtfgrdtnmmddyyyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschlattndddtfgrdtnmTXTBXNM.BringIntoView();
                    lstschlattndddtfgrdtnmmTXTBXNM.BringIntoView();
                    lstschlattndddtfgrdtnmmdTXTBXNM.BringIntoView();
                    lstschlattndddtfgrdtnmmddTXTBXNM.BringIntoView();
                    lstschlattndddtfgrdtnmmddyTXTBXNM.BringIntoView();
                    lstschlattndddtfgrdtnmmddyyTXTBXNM.BringIntoView();
                    lstschlattndddtfgrdtnmmddyyyTXTBXNM.BringIntoView();
                    lstschlattndddtfgrdtnmmddyyyyTXTBXNM.BringIntoView();
                }
                else
                {
                    lstschlattndddtfgrdtnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattndddtfgrdtnmmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattndddtfgrdtnmmdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattndddtfgrdtnmmddTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattndddtfgrdtnmmddyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattndddtfgrdtnmmddyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattndddtfgrdtnmmddyyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    lstschlattndddtfgrdtnmmddyyyyTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lstschllttnddnmfschlTXTBXNM.Text.Length == 0)
                {
                    lstschllttnddnmfschlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschllttnddnmfschlTXTBXNM.BringIntoView();
                }
                else
                {
                    lstschllttnddnmfschlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.Text.Length == 0)
                {
                    lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.BringIntoView();
                }
                else
                {
                    lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lstschllttnddsy1TXTBXNM.Text.Length == 0)
                {
                    lstschllttnddsy1TXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschllttnddsy1TXTBXNM.BringIntoView();
                }
                else
                {
                    lstschllttnddsy1TXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lstschllttnddsy2TXTBXNM.Text.Length == 0)
                {
                    lstschllttnddsy2TXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschllttnddsy2TXTBXNM.BringIntoView();
                }
                else
                {
                    lstschllttnddsy2TXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lstschllttnddyrgrdTXTBXNM.Text.Length == 0)
                {
                    lstschllttnddyrgrdTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschllttnddyrgrdTXTBXNM.BringIntoView();
                }
                else
                {
                    lstschllttnddyrgrdTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (lstschllttnddtrmTXTBXNM.Text.Length == 0)
                {
                    lstschllttnddtrmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    lstschllttnddtrmTXTBXNM.BringIntoView();
                }
                else
                {
                    lstschllttnddtrmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (fthrsfrstnmTXTBXNM.Text.Length == 0)
                {
                    fthrsfrstnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    fthrsfrstnmTXTBXNM.BringIntoView();
                }
                else
                {
                    fthrsfrstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (fthrsmddlntlTXTBXNM.Text.Length == 0)
                {
                    fthrsmddlntlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    fthrsmddlntlTXTBXNM.BringIntoView();
                }
                else
                {
                    fthrsmddlntlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (fthrslstnmTXTBXNM.Text.Length == 0)
                {
                    fthrslstnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    fthrslstnmTXTBXNM.BringIntoView();
                }
                else
                {
                    fthrslstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (fthrsfrstnmTXTBXNM.Text.Length == 0 && fthrsmddlntlTXTBXNM.Text.Length == 0 && fthrslstnmTXTBXNM.Text.Length == 0 && fthrssffxTXTBXNM.Text.Length == 0)
                {
                    fthrssffxTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    fthrssffxTXTBXNM.BringIntoView();
                }
                else
                {
                    fthrssffxTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (fthrsmblTXTBXNM.Text.Length == 0 && fthrsmlTXTBXNM.Text.Length == 0)
                {
                    fthrsmblTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    fthrsmlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    fthrsmblTXTBXNM.BringIntoView();
                    fthrsmlTXTBXNM.BringIntoView();
                }
                else
                {
                    fthrsmblTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    fthrsmlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (fthrsccptnTXTBXNM.Text.Length == 0)
                {
                    fthrsccptnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    fthrsccptnTXTBXNM.BringIntoView();
                }
                else
                {
                    fthrsccptnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (mthrsfrstnmTXTBXNM.Text.Length == 0)
                {
                    mthrsfrstnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mthrsfrstnmTXTBXNM.BringIntoView();
                }
                else
                {
                    mthrsfrstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (mthrsmddlntlTXTBXNM.Text.Length == 0)
                {
                    mthrsmddlntlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mthrsmddlntlTXTBXNM.BringIntoView();
                }
                else
                {
                    mthrsmddlntlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (mthrslstnmTXTBXNM.Text.Length == 0)
                {
                    mthrslstnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mthrslstnmTXTBXNM.BringIntoView();
                }
                else
                {
                    mthrslstnmTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (mthrsfrstnmTXTBXNM.Text.Length == 0 && mthrsmddlntlTXTBXNM.Text.Length == 0 && mthrslstnmTXTBXNM.Text.Length == 0 && mthrssffxTXTBXNM.Text.Length == 0)
                {
                    mthrssffxTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mthrssffxTXTBXNM.BringIntoView();
                }
                else
                {
                    mthrssffxTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (mthrsmblTXTBXNM.Text.Length == 0 && mthrsmlTXTBXNM.Text.Length == 0)
                {
                    mthrsmblTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mthrsmlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mthrsmblTXTBXNM.BringIntoView();
                    mthrsmlTXTBXNM.BringIntoView();
                }
                else
                {
                    mthrsmblTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                    mthrsmlTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                if (mthrsccptnTXTBXNM.Text.Length == 0)
                {
                    mthrsccptnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                    mthrsccptnTXTBXNM.BringIntoView();
                }
                else
                {
                    mthrsccptnTXTBXNM.ClearValue(TextBox.BorderBrushProperty);
                }

                MessageBox.Show("Fill Up The Required field");

            }

            else if (

                ((dsgntdgrdnfrstnmTXTBXNM.Text + dsgntdgrdnmddlntlTXTBXNM.Text + dsgntdgrdnlstnmTXTBXNM.Text + dsgntdgrdnsffxTXTBXNM.Text).Length != 0 &&
                ((dsgntdgrdnmblTXTBXNM.Text.Length == 0 && dsgntdgrdnmlTXTBXNM.Text.Length == 0) ||
                (dsgntdgrdnccptnTXTBXNM.Text.Length == 0)))

                ||

                ((dsgntdgrdnfrstnmTXTBXNM.Text + dsgntdgrdnmddlntlTXTBXNM.Text + dsgntdgrdnlstnmTXTBXNM.Text + dsgntdgrdnsffxTXTBXNM.Text).Length != 0 &&
                (dsgntdgrdnfrstnmTXTBXNM.Text.Length == 0 || dsgntdgrdnmddlntlTXTBXNM.Text.Length == 0 || dsgntdgrdnlstnmTXTBXNM.Text.Length == 0))

                ||

                (((dsgntdgrdnmblTXTBXNM.Text.Length != 0 || dsgntdgrdnmlTXTBXNM.Text.Length != 0) || dsgntdgrdnccptnTXTBXNM.Text.Length != 0) &&
                (dsgntdgrdnfrstnmTXTBXNM.Text + dsgntdgrdnmddlntlTXTBXNM.Text + dsgntdgrdnlstnmTXTBXNM.Text + dsgntdgrdnsffxTXTBXNM.Text).Length == 0)

                )
            {
                MessageBox.Show("Guardian information is incomplete.");
                revertBorderDefault();
                dsgntdgrdnfrstnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnmddlntlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnlstnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnsffxTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnmblTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnccptnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnmlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnfrstnmTXTBXNM.BringIntoView();
                dsgntdgrdnmddlntlTXTBXNM.BringIntoView();
                dsgntdgrdnlstnmTXTBXNM.BringIntoView();
                dsgntdgrdnsffxTXTBXNM.BringIntoView();
                dsgntdgrdnmblTXTBXNM.BringIntoView();
                dsgntdgrdnccptnTXTBXNM.BringIntoView();
                dsgntdgrdnmlTXTBXNM.BringIntoView();
            }

            else if (
                (!dnmbrTXTBXNM.Text.Equals("N/A") && dnmbrTXTBXNM.Text.All(char.IsDigit) == false) ||
                (!dnmbrTXTBXNM.Text.Equals("N/A") && dnmbrTXTBXNM.Text.Length != 11)
                )
            {
                if (dnmbrTXTBXNM.Text.All(char.IsDigit) == false)
                {
                    MessageBox.Show("Not a valid ID Number.");
                }
                else if (dnmbrTXTBXNM.Text.Length != 11)
                {
                    MessageBox.Show("ID number contains 11 numeric characters.[ex.02000080654]");
                }
                revertBorderDefault();
                dnmbrTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dnmbrTXTBXNM.BringIntoView();
            }

            else if (
                DateTime.TryParseExact(dtfbrthTXTBXNM.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate) == false ||

                dtfbrthTXTBXNM.Text.Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Length != 2 || dtfbrthTXTBXNM.Text.Replace("-", "").Length != 8
                )
            {
                if (DateTime.TryParseExact(dtfbrthTXTBXNM.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate) == false)
                {
                    MessageBox.Show("Not a valid date");
                }
                else if (dtfbrthTXTBXNM.Text.Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Length != 2 || dtfbrthTXTBXNM.Text.Replace("-","").Length != 8)
                {
                    MessageBox.Show("Invalid format");
                }
                revertBorderDefault();
                dtfbrthTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dtfbrthTXTBXNM.BringIntoView();
            }

            else if (!lrnscnTXTBXNM.Text.Equals("N/A") && (lrnscnTXTBXNM.Text.All(char.IsDigit) == false || (lrnscnTXTBXNM.Text.Length != 12 && lrnscnTXTBXNM.Text.Length != 7)))
            {
                MessageBox.Show("LRN or ESC Number is Invalid");
                revertBorderDefault();
                lrnscnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lrnscnTXTBXNM.BringIntoView();
            }

            else if (!(crrntddrsshsltuntnTXTBXNM.Text.IndexOf("Blk") >= 0 || crrntddrsshsltuntnTXTBXNM.Text.IndexOf("Lt") >= 0) && (crrntddrsshsltuntnTXTBXNM.Text.Length != 0 && crrntddrsshsltuntnTXTBXNM.Text.All(char.IsDigit) == false))
            {
                MessageBox.Show("Current Address contains invalid House/Lot/Unit no.");
                revertBorderDefault();
                crrntddrsshsltuntnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                crrntddrsshsltuntnTXTBXNM.BringIntoView();
            }

            else if (crrntddrsszpcdTXTBXNM.Text.Length != 0 && crrntddrsszpcdTXTBXNM.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show("Current Address contains invalid Zip Code.");
                revertBorderDefault();
                crrntddrsszpcdTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                crrntddrsszpcdTXTBXNM.BringIntoView();
            }

            else if (!(prmnntddrsshsltuntnTXTBXNM.Text.IndexOf("Blk") >= 0 || prmnntddrsshsltuntnTXTBXNM.Text.IndexOf("Lt") >= 0) && (prmnntddrsshsltuntnTXTBXNM.Text.Length != 0 && prmnntddrsshsltuntnTXTBXNM.Text.All(char.IsDigit) == false))
            {
                MessageBox.Show("Permanent Address contains invalid House/Lot/Unit no.");
                revertBorderDefault();
                prmnntddrsshsltuntnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                prmnntddrsshsltuntnTXTBXNM.BringIntoView();
            }

            else if (prmnntddrsszpcdTXTBXNM.Text.Length != 0 && prmnntddrsszpcdTXTBXNM.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show("Permanent Address contains invalid Zip Code.");
                revertBorderDefault();
                prmnntddrsszpcdTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                prmnntddrsszpcdTXTBXNM.BringIntoView();
            }

            else if (!lndlnTXTBXNM.Text.Equals("N/A") && lndlnTXTBXNM.Text.Length != 0 &&
                (
                lndlnTXTBXNM.Text
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .All(char.IsDigit) == false)

                || ((!lndlnTXTBXNM.Text.Equals("N/A") && lndlnTXTBXNM.Text.Length != 0 && lndlnTXTBXNM.Text.Count(Char.IsDigit) != 10))
                )
            {
                MessageBox.Show("Invalid landline");
                revertBorderDefault();
                lndlnTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lndlnTXTBXNM.BringIntoView();
            }

            else if (!mblTXTBXNM.Text.Equals("N/A") && mblTXTBXNM.Text.Length != 0 &&
                (
                mblTXTBXNM.Text
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .All(char.IsDigit) == false)
                || ((!mblTXTBXNM.Text.Equals("N/A") && mblTXTBXNM.Text.Length != 0 && mblTXTBXNM.Text.Count(Char.IsDigit) != 11))
                )
            {
                MessageBox.Show("Invalid mobile number");
                revertBorderDefault();
                mblTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                mblTXTBXNM.BringIntoView();
            }

            else if (!mlTXTBXNM.Text.Equals("N/A") && mlTXTBXNM.Text.Length != 0 && mlTXTBXNM.Text.IndexOf("@") <= 0 || Email.Contains(" "))
            {
                MessageBox.Show("Invalid email");
                revertBorderDefault();
                mlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                mlTXTBXNM.BringIntoView();
            }

            else if (

                (
                lstschlattndddtfgrdtnmTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmdTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddyTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddyyTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.Text.Length != 0
                )

                &&

                (
                !(
                lstschlattndddtfgrdtnmTXTBXNM.Text.Length == 1 &&
                lstschlattndddtfgrdtnmmTXTBXNM.Text.Length == 1 &&
                lstschlattndddtfgrdtnmmdTXTBXNM.Text.Length == 1 &&
                lstschlattndddtfgrdtnmmddTXTBXNM.Text.Length == 1 &&
                lstschlattndddtfgrdtnmmddyTXTBXNM.Text.Length == 1 &&
                lstschlattndddtfgrdtnmmddyyTXTBXNM.Text.Length == 1 &&
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.Text.Length == 1 &&
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.Text.Length == 1
                )
                )
                ||
                (
                lstschlattndddtfgrdtnmTXTBXNM.Text.All(char.IsDigit) == false ||
                lstschlattndddtfgrdtnmmTXTBXNM.Text.All(char.IsDigit) == false ||
                lstschlattndddtfgrdtnmmdTXTBXNM.Text.All(char.IsDigit) == false ||
                lstschlattndddtfgrdtnmmddTXTBXNM.Text.All(char.IsDigit) == false ||
                lstschlattndddtfgrdtnmmddyTXTBXNM.Text.All(char.IsDigit) == false ||
                lstschlattndddtfgrdtnmmddyyTXTBXNM.Text.All(char.IsDigit) == false ||
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.Text.All(char.IsDigit) == false ||
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.Text.All(char.IsDigit) == false
                )
                )
            {
                MessageBox.Show("Invalid Date format");
                revertBorderDefault();
                lstschlattndddtfgrdtnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmdTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmdTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddyTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddyyTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.BringIntoView();
            }
            else if (
                (
                (
                lstschlattndddtfgrdtnmTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmdTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddyTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddyyTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.Text.Length != 0 ||
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.Text.Length != 0
                )
                &&
                (DateTime.TryParseExact(
                lstschlattndddtfgrdtnmTXTBXNM.Text +
                lstschlattndddtfgrdtnmmTXTBXNM.Text +
                "-" +
                lstschlattndddtfgrdtnmmdTXTBXNM.Text +
                lstschlattndddtfgrdtnmmddTXTBXNM.Text +
                "-" +
                lstschlattndddtfgrdtnmmddyTXTBXNM.Text +
                lstschlattndddtfgrdtnmmddyyTXTBXNM.Text +
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.Text +
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.Text
                , "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate)
                ) == false)
                )
            {
                MessageBox.Show("Graduation date isn't valid");
                revertBorderDefault();
                lstschlattndddtfgrdtnmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmdTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschlattndddtfgrdtnmTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmdTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddyTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddyyTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.BringIntoView();
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.BringIntoView();
            }

            else if (((lstschllttnddsy1TXTBXNM.Text.Length != 4) || (lstschllttnddsy1TXTBXNM.Text.Length != 4)) || ((lstschllttnddsy1TXTBXNM.Text.All(char.IsDigit) == false) || (lstschllttnddsy2TXTBXNM.Text.All(char.IsDigit) == false)))
            {
                MessageBox.Show("Invalid School Year");
                revertBorderDefault();
                lstschllttnddsy1TXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschllttnddsy2TXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschllttnddsy1TXTBXNM.BringIntoView();
                lstschllttnddsy2TXTBXNM.BringIntoView();
            }

            else if (lstschllttnddtrmTXTBXNM.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show("School term isn't valid");
                revertBorderDefault();
                lstschllttnddtrmTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                lstschllttnddtrmTXTBXNM.BringIntoView();
            }

            else if (!fthrsmblTXTBXNM.Text.Equals("N/A") && fthrsmblTXTBXNM.Text.Length != 0 &&
                (
                fthrsmblTXTBXNM.Text
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .All(char.IsDigit) == false)
                || ((!fthrsmblTXTBXNM.Text.Equals("N/A") && fthrsmblTXTBXNM.Text.Length != 0 && fthrsmblTXTBXNM.Text.Count(Char.IsDigit) != 11))
                )
            {
                MessageBox.Show("Invalid mobile number");
                revertBorderDefault();
                fthrsmblTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                fthrsmblTXTBXNM.BringIntoView();
            }

            else if (!fthrsmlTXTBXNM.Text.Equals("N/A") && fthrsmlTXTBXNM.Text.Length != 0 && fthrsmlTXTBXNM.Text.IndexOf("@") <= 0 || Father_Email.Contains(" "))
            {
                MessageBox.Show("Invalid email");
                revertBorderDefault();
                fthrsmlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                fthrsmlTXTBXNM.BringIntoView();
            }

            else if (!mthrsmblTXTBXNM.Text.Equals("N/A") && mthrsmblTXTBXNM.Text.Length != 0 &&
                (
                mthrsmblTXTBXNM.Text
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .All(char.IsDigit) == false)
                || ((!mthrsmblTXTBXNM.Text.Equals("N/A") && mthrsmblTXTBXNM.Text.Length != 0 && mthrsmblTXTBXNM.Text.Count(Char.IsDigit) != 11))
                )
            {
                MessageBox.Show("Invalid mobile number");
                revertBorderDefault();
                mthrsmblTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                mthrsmblTXTBXNM.BringIntoView();
            }

            else if (!mthrsmlTXTBXNM.Text.Equals("N/A") && mthrsmlTXTBXNM.Text.Length != 0 && mthrsmlTXTBXNM.Text.IndexOf("@") <= 0 || Mother_Email.Contains(" "))
            {
                MessageBox.Show("Invalid email");
                revertBorderDefault();
                mthrsmlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                mthrsmlTXTBXNM.BringIntoView();
            }

            else if (!dsgntdgrdnmblTXTBXNM.Text.Equals("N/A") && dsgntdgrdnmblTXTBXNM.Text.Length != 0 &&
                (
                dsgntdgrdnmblTXTBXNM.Text
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .All(char.IsDigit) == false)
                || ((!dsgntdgrdnmblTXTBXNM.Text.Equals("N/A") && dsgntdgrdnmblTXTBXNM.Text.Length != 0 && dsgntdgrdnmblTXTBXNM.Text.Count(Char.IsDigit) != 11))
                )
            {
                MessageBox.Show("Invalid mobile number");
                revertBorderDefault();
                dsgntdgrdnmblTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnmblTXTBXNM.BringIntoView();
            }

            else if (!dsgntdgrdnmlTXTBXNM.Text.Equals("N/A") && dsgntdgrdnmlTXTBXNM.Text.Length != 0 && dsgntdgrdnmlTXTBXNM.Text.IndexOf("@") <= 0 || Guardian_Email.Contains(" "))
            {
                MessageBox.Show("Invalid email");
                revertBorderDefault();
                dsgntdgrdnmlTXTBXNM.BorderBrush = System.Windows.Media.Brushes.Red;
                dsgntdgrdnmlTXTBXNM.BringIntoView();
            }

            else
            {
                chkTransac();
            }
        }

        private void chkTransac()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "SELECT COUNT(1) FROM tblSTIEnrollees WHERE STUDENT_ID=@STUDENT_ID AND COURSE=@COURSE AND YEAR_OR_GRADE=@YEAR_OR_GRADE AND LAST_SCHOOL_ATTENDED=@LAST_SCHOOL_ATTENDED AND PREVIOUS_YEAR_OR_GRADE=@PREVIOUS_YEAR_OR_GRADE";
            SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.Parameters.AddWithValue("@STUDENT_ID", Student_ID);
            sqlCMD.Parameters.AddWithValue("@COURSE", Course);
            sqlCMD.Parameters.AddWithValue("@YEAR_OR_GRADE", Year_Or_Grade);
            sqlCMD.Parameters.AddWithValue("@LAST_SCHOOL_ATTENDED", Last_School_Attended);
            sqlCMD.Parameters.AddWithValue("@PREVIOUS_YEAR_OR_GRADE", Previous_Year_Or_Grade);
            int count = Convert.ToInt32(sqlCMD.ExecuteScalar());
            
            if (count >= 1)
            {
                revertBorderDefault();
                MessageBox.Show("An Identical Information is already in the database.");
            }
            else
            {
                revertBorderDefault();
                demomode = false;
                insertDataToServer();
                clearInput();
            }
        }

        private void insertDataToServer()
        {
            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            String colCount = "SELECT COUNT(TRANSACTION_ID) FROM tblSTIEnrollees;";

            int count = 1;
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand countCMD = new SqlCommand(colCount, sqlCon);
                countCMD.CommandType = CommandType.Text;
                count = count + Convert.ToInt32(countCMD.ExecuteScalar());
                sqlCon.Close();
            }
            catch (Exception ex) { }

            Transaction_ID = count;

            DateTime currentTime = DateTime.Now;

            String Time_And_Date_Enrolled = currentTime.ToString("MM-dd-yyyy hh:mm tt");

            String host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");

            String School_Year = System.IO.File.ReadAllText(@"" + host + "\\SchoolYear.txt");

            String insertQUERY = "INSERT into tblSTIEnrollees(TRANSACTION_ID, SCHOOL_LEVEL, STUDENT_ID, COURSE, YEAR_OR_GRADE, LRN_OR_ESC, STUDENT_NAME, BIRTH_DATE, BIRTH_PLACE, CITIZENSHIP, CIVIL_STATUS, GENDER, CURRENT_ADDRESS, PERMANENT_ADDRESS, LANDLINE, MOBILE, EMAIL, PREVIOUS_SCHOOL_LEVEL, GRADUATION, LAST_SCHOOL_ATTENDED, PREVIOUS_LEVEL, PREVIOUS_SCHOOL_YEAR_ATTENDED, PREVIOUS_YEAR_OR_GRADE, TERM, FATHER_NAME, FATHER_CONTACT_NO, FATHER_OCCUPATION, FATHER_EMAIL, MOTHER_NAME, MOTHER_CONTACT_NO, MOTHER_OCCUPATION, MOTHER_EMAIL, GUARDIAN_NAME, GUARDIAN_CONTACT_NO, GUARDIAN_OCCUPATION, GUARDIAN_EMAIL, TIME_AND_DATE_ENROLLED, SCHOOL_YEAR) values " +
                "('" + Transaction_ID + "','" + School_Level + "','" + Student_ID + "','" + Course + "','" + Year_Or_Grade + "','" + LRN_Or_ESC + "','" + Student_Name + "','" + Birth_Date + "','" + Birth_Place + "','" + Citizenship + "','" + Civil_Status + "','" + Gender + "','" + Current_Address + "','" + Permanent_Address + "','" + Landline + "','" + Mobile + "','" + Email + "','" + Previous_School_Level + "','" + Graduation + "','" + Last_School_Attended + "','" + Previous_Level + "','" + Previous_School_Year_Attended + "','" + Previous_Year_Or_Grade + "','" + Term + "','" + Father_Name + "','" + Father_Contact_No + "','" + Father_Occupation + "','" + Father_Email + "','" + Mother_Name + "','" + Mother_Contact_No + "','" + Mother_Occupation + "','" + Mother_Email + "','" + Guardian_Name + "','" + Guardian_Contact_No + "','" + Guardian_Occupation + "','" + Guardian_Email + "','" + Time_And_Date_Enrolled + "','" + School_Year + "')";
            try
            {
                createStudentAccount();
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCMD = new SqlCommand(insertQUERY, sqlCon);
                sqlCMD.ExecuteNonQuery();
                sqlCMD.Dispose();
                sqlCon.Close();
                MessageBox.Show("Student data was inserted successfully.");
                CreateLOGFolder();
                xampp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public void xampp()
        {
            TRANSACTION_ID = ""+Transaction_ID;
            retrieveStudentData();
            generatePDF();
        }

        private void createStudentAccount()
        {
            MySql.Data.MySqlClient.MySqlConnection connection;
            string server = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\WebConfig.txt"); ;
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
                    string sql = "SELECT * FROM tblstudents WHERE studentnumber='" + Convert.ToInt32(dnmbrTXTBXNM.Text) + "'";

                    MySqlCommand lookcmd = new MySqlCommand(sql, connection);
                    MySqlDataReader rdr = lookcmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        { 
                        }
                    }
                    else
                    {
                        DateTime currentTime = DateTime.Now;
                        String currentYear = currentTime.ToString("yyyy");
                        string defaultPassword = "Stilipa" + currentYear;
                        connection.Close();
                        connection.Open();
                        if (connection.State == ConnectionState.Open)
                        {
                            MySqlCommand cmd = new MySqlCommand("insert into tblstudents (studentnumber,lname,fname,mname,section,gender,citizenship,religion,birthdate,pass) VALUES (@studentnumber,@lname,@fname,@mname,@section,@gender,@citizenship,@religion,@birthdate,@pass)", connection);
                            cmd.Parameters.AddWithValue("@studentnumber", Convert.ToInt32(dnmbrTXTBXNM.Text));
                            cmd.Parameters.AddWithValue("@lname", lstnmTXTBXNM.Text);
                            cmd.Parameters.AddWithValue("@fname", frstnmTXTBXNM.Text);
                            cmd.Parameters.AddWithValue("@mname", mddlnmTXTBXNM.Text);
                            cmd.Parameters.AddWithValue("@section", "[NOT SET]");
                            if (mCHCKBXNM.IsChecked == true)
                                cmd.Parameters.AddWithValue("@gender", "MALE");
                            else if (fCHCKBXNM.IsChecked == true)
                                cmd.Parameters.AddWithValue("@gender", "FEMALE");
                            cmd.Parameters.AddWithValue("@citizenship", ctznshpTXTBXNM.Text);
                            cmd.Parameters.AddWithValue("@religion", "[NOT SET]");
                            cmd.Parameters.AddWithValue("@birthdate", dtfbrthTXTBXNM.Text);
                            cmd.Parameters.AddWithValue("@pass", defaultPassword);
                            cmd.ExecuteNonQuery();

                            //MessageBox.Show("Data Was Inserted To XAMPP Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed To Create Student Account.");
                        }

                        connection.Close();
                    }
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

        private void genformLOGS()
        {

            string imgflnm = Student_Name;

            StackPanel element = rgstrtnfrmSTCKPNNL;

            string logCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\LogConfig.txt");

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)element.ActualWidth,
                        (int)element.ActualHeight,
                        96, 96, PixelFormats.Pbgra32);
            element.Measure(new Size(500, 500));
            rtb.Render(element);
            BitmapEncoder imgEncoder = new PngBitmapEncoder();
            imgEncoder.Frames.Add(BitmapFrame.Create(rtb));

            String host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");

            String School_Year = System.IO.File.ReadAllText(@"" + host + "\\SchoolYear.txt");

            using (Stream stream = File.Create(@"" + logCON + "\\"+ School_Year + "\\" + School_Level + "\\" + Year_Or_Grade + "\\" + Course + "\\" + imgflnm + ".png"))
            {
                imgEncoder.Save(stream);
                stream.Close();
            }
            Process.Start(@"" + logCON + "\\" + School_Year + "\\" + School_Level + "\\" + Year_Or_Grade + "\\" + Course + "\\" + imgflnm + ".png");
        }

        private void CreateLOGFolder()
        {

            string logCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\LogConfig.txt");

            String host = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\HostConfig.txt");

            String School_Year = System.IO.File.ReadAllText(@"" + host + "\\SchoolYear.txt");

            string path = @"" + logCON + "\\" + School_Year + "\\" + School_Level + "\\" + Year_Or_Grade + "\\" + Course;

            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);

                    genformLOGS();
                }
                else
                {
                    genformLOGS();
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("" + ioex);
            }
        }

        string School_Level = "";
        string Student_ID;
        string Course = "";
        string Year_Or_Grade = "";
        string LRN_Or_ESC = "";
        string Student_Name = "";
        string Birth_Date = "";
        string Birth_Place = "";
        string Citizenship = "";
        string Civil_Status = "";
        string Gender = "";
        string Current_Address = "";
        string Permanent_Address = "";
        string Landline = "";
        string Mobile = "";
        string Email = "";
        string Previous_School_Level = "";
        string Graduation = "";
        string Last_School_Attended = "";
        string Previous_Level = "";
        string Previous_School_Year_Attended = "";
        string Previous_Year_Or_Grade = "";
        string Term = "";
        string Father_Name = "";
        string Father_Contact_No;
        string Father_Occupation = "";
        string Father_Email = "";
        string Mother_Name = "";
        string Mother_Contact_No;
        string Mother_Occupation = "";
        string Mother_Email = "";
        string Guardian_Name = "";
        string Guardian_Contact_No;
        string Guardian_Occupation = "";
        string Guardian_Email = "";

        private void getDataFromForm()
        {
            School_Level = "";

            if (snrhghschlCHCKBXNM.IsChecked == true)
            {
                School_Level = "Senior High School";
            }
            else if (cllgCHCKBXNM.IsChecked == true)
            {
                School_Level = "College";
            }
            else if (nwstdntCHCKBXNM.IsChecked == true)
            {
                School_Level = "New Student";
            }
            else if (trnsfrCHCKBXNM.IsChecked == true)
            {
                School_Level = "Transferee";
            }

            Student_ID = dnmbrTXTBXNM.Text;

            Course = chsnprgrmtrckstrndspclztnTXTBXNM.Text;

            Year_Or_Grade = yrgrdTXTBXNM.Text;

            LRN_Or_ESC = lrnscnTXTBXNM.Text;

            Student_Name = "";
            if (lstnmTXTBXNM.Text.Length != 0)
            {
                Student_Name = lstnmTXTBXNM.Text;
            }
            if (
                (lstnmTXTBXNM.Text.Length != 0 && frstnmTXTBXNM.Text.Length != 0) ||
                (lstnmTXTBXNM.Text.Length != 0 && mddlnmTXTBXNM.Text.Length != 0) ||
                (lstnmTXTBXNM.Text.Length != 0 && sffxTXTBXNM.Text.Length != 0)
                )
            {
                Student_Name = Student_Name + ", ";
            }
            if (frstnmTXTBXNM.Text.Length != 0)
            {
                Student_Name = Student_Name + frstnmTXTBXNM.Text;
            }
            if (
                (frstnmTXTBXNM.Text.Length != 0 && mddlnmTXTBXNM.Text.Length != 0) ||
                (frstnmTXTBXNM.Text.Length != 0 && sffxTXTBXNM.Text.Length != 0)
                )
            {
                Student_Name = Student_Name + " ";
            }
            if (mddlnmTXTBXNM.Text.Length != 0)
            {
                Student_Name = Student_Name + mddlnmTXTBXNM.Text;
            }
            if (mddlnmTXTBXNM.Text.Length != 0 && sffxTXTBXNM.Text.Length != 0)
            {
                Student_Name = Student_Name + " ";
            }
            if (sffxTXTBXNM.Text.Length != 0)
            {
                Student_Name = Student_Name + sffxTXTBXNM.Text;
            }

            Birth_Date = dtfbrthTXTBXNM.Text;

            Birth_Place = brtplcTXTBXNM.Text;

            Citizenship = ctznshpTXTBXNM.Text;

            if (snglCHCKBXNM.IsChecked == true)
            {
                Civil_Status = "Single";
            }
            else if (mrrdCHCKBXNM.IsChecked == true)
            {
                Civil_Status = "Married";
            }

            if (mCHCKBXNM.IsChecked == true)
            {
                Gender = "Male";
            }
            else if (fCHCKBXNM.IsChecked == true)
            {
                Gender = "Female";
            }

            Current_Address = "";
            if (crrntddrsshsltuntnTXTBXNM.Text.Length != 0)
            {
                Current_Address = Current_Address + crrntddrsshsltuntnTXTBXNM.Text;
            }
            if (
                (crrntddrsshsltuntnTXTBXNM.Text.Length != 0 && crrntddrssstrtTXTBXNM.Text.Length != 0) ||
                (crrntddrsshsltuntnTXTBXNM.Text.Length != 0 && crrntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0) ||
                (crrntddrsshsltuntnTXTBXNM.Text.Length != 0 && crrntddrsszpcdTXTBXNM.Text.Length != 0) ||
                (crrntddrsshsltuntnTXTBXNM.Text.Length != 0 && crrntddrssctymncpltTXTBXNM.Text.Length != 0) ||
                (crrntddrsshsltuntnTXTBXNM.Text.Length != 0 && crrntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Current_Address = Current_Address + " ";
            }
            if (crrntddrssstrtTXTBXNM.Text.Length != 0)
            {
                Current_Address = Current_Address + crrntddrssstrtTXTBXNM.Text;
            }
            if (
                (crrntddrssstrtTXTBXNM.Text.Length != 0 && crrntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0) ||
                (crrntddrssstrtTXTBXNM.Text.Length != 0 && crrntddrsszpcdTXTBXNM.Text.Length != 0) ||
                (crrntddrssstrtTXTBXNM.Text.Length != 0 && crrntddrssctymncpltTXTBXNM.Text.Length != 0) ||
                (crrntddrssstrtTXTBXNM.Text.Length != 0 && crrntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Current_Address = Current_Address + " ";
            }
            if (crrntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0)
            {
                Current_Address = Current_Address + crrntddrssbldngsbdvsnbrngyTXTBXNM.Text;
            }
            if (
                (crrntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0 && crrntddrsszpcdTXTBXNM.Text.Length != 0) ||
                (crrntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0 && crrntddrssctymncpltTXTBXNM.Text.Length != 0) ||
                (crrntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0 && crrntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Current_Address = Current_Address + ", ";
            }
            if (crrntddrsszpcdTXTBXNM.Text.Length != 0)
            {
                Current_Address = Current_Address + crrntddrsszpcdTXTBXNM.Text;
            }
            if (
                (crrntddrsszpcdTXTBXNM.Text.Length != 0 && crrntddrssctymncpltTXTBXNM.Text.Length != 0) ||
                (crrntddrsszpcdTXTBXNM.Text.Length != 0 && crrntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Current_Address = Current_Address + " ";
            }
            if (crrntddrssctymncpltTXTBXNM.Text.Length != 0)
            {
                Current_Address = Current_Address + crrntddrssctymncpltTXTBXNM.Text;
            }
            if (
                (crrntddrssctymncpltTXTBXNM.Text.Length != 0 && crrntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Current_Address = Current_Address + " ";
            }
            if (crrntddrssprvncTXTBXNM.Text.Length != 0)
            {
                Current_Address = Current_Address + crrntddrssprvncTXTBXNM.Text;
            }

            Permanent_Address = "";
            if (prmnntddrsshsltuntnTXTBXNM.Text.Length != 0)
            {
                Permanent_Address = Permanent_Address + prmnntddrsshsltuntnTXTBXNM.Text;
            }
            if (
                (prmnntddrsshsltuntnTXTBXNM.Text.Length != 0 && prmnntddrssstrtTXTBXNM.Text.Length != 0) ||
                (prmnntddrsshsltuntnTXTBXNM.Text.Length != 0 && prmnntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0) ||
                (prmnntddrsshsltuntnTXTBXNM.Text.Length != 0 && prmnntddrsszpcdTXTBXNM.Text.Length != 0) ||
                (prmnntddrsshsltuntnTXTBXNM.Text.Length != 0 && prmnntddrssctymncpltTXTBXNM.Text.Length != 0) ||
                (prmnntddrsshsltuntnTXTBXNM.Text.Length != 0 && prmnntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Permanent_Address = Permanent_Address + " ";
            }
            if (prmnntddrssstrtTXTBXNM.Text.Length != 0)
            {
                Permanent_Address = Permanent_Address + prmnntddrssstrtTXTBXNM.Text;
            }
            if (
                (prmnntddrssstrtTXTBXNM.Text.Length != 0 && prmnntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0) ||
                (prmnntddrssstrtTXTBXNM.Text.Length != 0 && prmnntddrsszpcdTXTBXNM.Text.Length != 0) ||
                (prmnntddrssstrtTXTBXNM.Text.Length != 0 && prmnntddrssctymncpltTXTBXNM.Text.Length != 0) ||
                (prmnntddrssstrtTXTBXNM.Text.Length != 0 && prmnntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Permanent_Address = Permanent_Address + " ";
            }
            if (prmnntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0)
            {
                Permanent_Address = Permanent_Address + prmnntddrssbldngsbdvsnbrngyTXTBXNM.Text;
            }
            if (
                (prmnntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0 && prmnntddrsszpcdTXTBXNM.Text.Length != 0) ||
                (prmnntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0 && prmnntddrssctymncpltTXTBXNM.Text.Length != 0) ||
                (prmnntddrssbldngsbdvsnbrngyTXTBXNM.Text.Length != 0 && prmnntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Permanent_Address = Permanent_Address + ", ";
            }
            if (prmnntddrsszpcdTXTBXNM.Text.Length != 0)
            {
                Permanent_Address = Permanent_Address + prmnntddrsszpcdTXTBXNM.Text;
            }
            if (
                (prmnntddrsszpcdTXTBXNM.Text.Length != 0 && prmnntddrssctymncpltTXTBXNM.Text.Length != 0) ||
                (prmnntddrsszpcdTXTBXNM.Text.Length != 0 && prmnntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Permanent_Address = Permanent_Address + " ";
            }
            if (prmnntddrssctymncpltTXTBXNM.Text.Length != 0)
            {
                Permanent_Address = Permanent_Address + prmnntddrssctymncpltTXTBXNM.Text;
            }
            if (
                (prmnntddrssctymncpltTXTBXNM.Text.Length != 0 && prmnntddrssprvncTXTBXNM.Text.Length != 0)
                )
            {
                Permanent_Address = Permanent_Address + " ";
            }
            if (prmnntddrssprvncTXTBXNM.Text.Length != 0)
            {
                Permanent_Address = Permanent_Address + prmnntddrssprvncTXTBXNM.Text;
            }

            Landline = lndlnTXTBXNM.Text;

            Mobile = mblTXTBXNM.Text;

            Email = mlTXTBXNM.Text;

            if (lstschlattnddhghschlCHCKBXNM.IsChecked == true)
            {
                if (lstschlattnddjnrhghschlCHCKBXNM.IsChecked == true)
                {
                    Previous_School_Level = "Junior High School";
                }
                else if (lstschlattnddsnrhghschlCHCKBXNM.IsChecked == true)
                {
                    Previous_School_Level = "Senior High School";
                }
                else
                {
                    Previous_School_Level = "High School";
                }
            }
            else if (lstschlattnddllspptCHCKBXNM.IsChecked == true)
            {
                Previous_School_Level = "ALS A&E / PEPT***";
            }
            else if (lstschlattnddcllgCHCKBXNM.IsChecked == true)
            {
                Previous_School_Level = "College";
            }

            Graduation =
                (lstschlattndddtfgrdtnmTXTBXNM.Text +
                lstschlattndddtfgrdtnmmTXTBXNM.Text + "-" +
                lstschlattndddtfgrdtnmmdTXTBXNM.Text +
                lstschlattndddtfgrdtnmmddTXTBXNM.Text + "-" +
                lstschlattndddtfgrdtnmmddyTXTBXNM.Text +
                lstschlattndddtfgrdtnmmddyyTXTBXNM.Text +
                lstschlattndddtfgrdtnmmddyyyTXTBXNM.Text +
                lstschlattndddtfgrdtnmmddyyyyTXTBXNM.Text).Replace("--","");

            Last_School_Attended = lstschllttnddnmfschlTXTBXNM.Text;

            Previous_Level = lstschllttnddprgrmrtrckstrndspclztnTXTBXNM.Text;

            Previous_School_Year_Attended = lstschllttnddsy1TXTBXNM.Text + " - " + lstschllttnddsy2TXTBXNM.Text;

            Previous_Year_Or_Grade = lstschllttnddyrgrdTXTBXNM.Text;

            Term = lstschllttnddtrmTXTBXNM.Text;

            Father_Name = "";
            if (fthrslstnmTXTBXNM.Text.Length != 0)
            {
                Father_Name = fthrslstnmTXTBXNM.Text;
            }
            if (
                (fthrslstnmTXTBXNM.Text.Length != 0 && fthrsfrstnmTXTBXNM.Text.Length != 0) ||
                (fthrslstnmTXTBXNM.Text.Length != 0 && fthrsmddlntlTXTBXNM.Text.Length != 0) ||
                (fthrslstnmTXTBXNM.Text.Length != 0 && fthrssffxTXTBXNM.Text.Length != 0)
                )
            {
                Father_Name = Father_Name + ", ";
            }
            if (fthrsfrstnmTXTBXNM.Text.Length != 0)
            {
                Father_Name = Father_Name + fthrsfrstnmTXTBXNM.Text;
            }
            if (
                (fthrsfrstnmTXTBXNM.Text.Length != 0 && fthrsmddlntlTXTBXNM.Text.Length != 0) ||
                (fthrsfrstnmTXTBXNM.Text.Length != 0 && fthrssffxTXTBXNM.Text.Length != 0)
                )
            {
                Father_Name = Father_Name + " ";
            }
            if (fthrsmddlntlTXTBXNM.Text.Length != 0)
            {
                Father_Name = Father_Name + fthrsmddlntlTXTBXNM.Text;
            }
            if (fthrsmddlntlTXTBXNM.Text.Length != 0 && fthrssffxTXTBXNM.Text.Length != 0)
            {
                Father_Name = Father_Name + " ";
            }
            if (fthrssffxTXTBXNM.Text.Length != 0)
            {
                Father_Name = Father_Name + fthrssffxTXTBXNM.Text;
            }

            Father_Contact_No = fthrsmblTXTBXNM.Text;

            Father_Occupation = fthrsccptnTXTBXNM.Text;

            Father_Email = fthrsmlTXTBXNM.Text;

            Mother_Name = "";
            if (mthrslstnmTXTBXNM.Text.Length != 0)
            {
                Mother_Name = mthrslstnmTXTBXNM.Text;
            }
            if (
                (mthrslstnmTXTBXNM.Text.Length != 0 && mthrsfrstnmTXTBXNM.Text.Length != 0) ||
                (mthrslstnmTXTBXNM.Text.Length != 0 && mthrsmddlntlTXTBXNM.Text.Length != 0) ||
                (mthrslstnmTXTBXNM.Text.Length != 0 && mthrssffxTXTBXNM.Text.Length != 0)
                )
            {
                Mother_Name = Mother_Name + ", ";
            }
            if (mthrsfrstnmTXTBXNM.Text.Length != 0)
            {
                Mother_Name = Mother_Name + mthrsfrstnmTXTBXNM.Text;
            }
            if (
                (mthrsfrstnmTXTBXNM.Text.Length != 0 && mthrsmddlntlTXTBXNM.Text.Length != 0) ||
                (mthrsfrstnmTXTBXNM.Text.Length != 0 && mthrssffxTXTBXNM.Text.Length != 0)
                )
            {
                Mother_Name = Mother_Name + " ";
            }
            if (mthrsmddlntlTXTBXNM.Text.Length != 0)
            {
                Mother_Name = Mother_Name + mthrsmddlntlTXTBXNM.Text;
            }
            if (mthrsmddlntlTXTBXNM.Text.Length != 0 && mthrssffxTXTBXNM.Text.Length != 0)
            {
                Mother_Name = Mother_Name + " ";
            }
            if (mthrssffxTXTBXNM.Text.Length != 0)
            {
                Mother_Name = Mother_Name + mthrssffxTXTBXNM.Text;
            }

            Mother_Contact_No = mthrsmblTXTBXNM.Text;

            Mother_Occupation = mthrsccptnTXTBXNM.Text;

            Mother_Email = mthrsmlTXTBXNM.Text;

            Guardian_Name = "";
            if (dsgntdgrdnlstnmTXTBXNM.Text.Length != 0)
            {
                Guardian_Name = dsgntdgrdnlstnmTXTBXNM.Text;
            }
            if (
                (dsgntdgrdnlstnmTXTBXNM.Text.Length != 0 && dsgntdgrdnfrstnmTXTBXNM.Text.Length != 0) ||
                (dsgntdgrdnlstnmTXTBXNM.Text.Length != 0 && dsgntdgrdnmddlntlTXTBXNM.Text.Length != 0) ||
                (dsgntdgrdnlstnmTXTBXNM.Text.Length != 0 && dsgntdgrdnsffxTXTBXNM.Text.Length != 0)
                )
            {
                Guardian_Name = Guardian_Name + ", ";
            }
            if (dsgntdgrdnfrstnmTXTBXNM.Text.Length != 0)
            {
                Guardian_Name = Guardian_Name + dsgntdgrdnfrstnmTXTBXNM.Text;
            }
            if (
                (dsgntdgrdnfrstnmTXTBXNM.Text.Length != 0 && dsgntdgrdnmddlntlTXTBXNM.Text.Length != 0) ||
                (dsgntdgrdnfrstnmTXTBXNM.Text.Length != 0 && dsgntdgrdnsffxTXTBXNM.Text.Length != 0)
                )
            {
                Guardian_Name = Guardian_Name + " ";
            }
            if (dsgntdgrdnmddlntlTXTBXNM.Text.Length != 0)
            {
                Guardian_Name = Guardian_Name + dsgntdgrdnmddlntlTXTBXNM.Text;
            }
            if (dsgntdgrdnmddlntlTXTBXNM.Text.Length != 0 && dsgntdgrdnsffxTXTBXNM.Text.Length != 0)
            {
                Guardian_Name = Guardian_Name + " ";
            }
            if (dsgntdgrdnsffxTXTBXNM.Text.Length != 0)
            {
                Guardian_Name = Guardian_Name + dsgntdgrdnsffxTXTBXNM.Text;
            }

            Guardian_Contact_No = dsgntdgrdnmblTXTBXNM.Text;

            Guardian_Occupation = dsgntdgrdnccptnTXTBXNM.Text;

            Guardian_Email = dsgntdgrdnmlTXTBXNM.Text;
        }

        private void retrieveStudentData()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = "server";
            csb.InitialCatalog = "database";
            csb.IntegratedSecurity = true;

            string connString = csb.ToString();

            int searchID = Convert.ToInt32(TRANSACTION_ID);

            string dbCON = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\DBConfig.txt");

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;");

            string queryString = "select top 1 TRANSACTION_ID, SCHOOL_LEVEL, STUDENT_ID, COURSE, YEAR_OR_GRADE, LRN_OR_ESC, STUDENT_NAME, BIRTH_DATE, BIRTH_PLACE, CITIZENSHIP, CIVIL_STATUS, GENDER, CURRENT_ADDRESS, PERMANENT_ADDRESS, LANDLINE, MOBILE, EMAIL, PREVIOUS_SCHOOL_LEVEL, GRADUATION, LAST_SCHOOL_ATTENDED, PREVIOUS_LEVEL, PREVIOUS_SCHOOL_YEAR_ATTENDED, PREVIOUS_YEAR_OR_GRADE, TERM, FATHER_NAME, FATHER_CONTACT_NO, FATHER_OCCUPATION, FATHER_EMAIL, MOTHER_NAME, MOTHER_CONTACT_NO, MOTHER_OCCUPATION, MOTHER_EMAIL, GUARDIAN_NAME, GUARDIAN_CONTACT_NO, GUARDIAN_OCCUPATION, GUARDIAN_EMAIL, TIME_AND_DATE_ENROLLED, SCHOOL_YEAR from tblSTIEnrollees Where TRANSACTION_ID=" + searchID;

            using (SqlConnection connection = new SqlConnection(@"Data Source=" + dbCON + ";  Initial Catalog=STILocalDB; Integrated Security=true;"))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transaction_idValue = reader["TRANSACTION_ID"].ToString();
                        school_levelValue = reader["SCHOOL_LEVEL"].ToString();
                        student_idValue = reader["STUDENT_ID"].ToString();
                        courseValue = reader["COURSE"].ToString();
                        year_or_gradeValue = reader["YEAR_OR_GRADE"].ToString();
                        lrn_or_escValue = reader["LRN_OR_ESC"].ToString();
                        student_nameValue = reader["STUDENT_NAME"].ToString();
                        birth_dateValue = reader["BIRTH_DATE"].ToString();
                        birth_placeValue = reader["BIRTH_PLACE"].ToString();
                        citizenshipValue = reader["CITIZENSHIP"].ToString();
                        civil_statusValue = reader["CIVIL_STATUS"].ToString();
                        genderValue = reader["GENDER"].ToString();
                        current_addressValue = reader["CURRENT_ADDRESS"].ToString();
                        permanent_addressValue = reader["PERMANENT_ADDRESS"].ToString();
                        landlineValue = reader["LANDLINE"].ToString();
                        mobileValue = reader["MOBILE"].ToString();
                        emailValue = reader["EMAIL"].ToString();
                        previous_school_levelValue = reader["PREVIOUS_SCHOOL_LEVEL"].ToString();
                        graduationValue = reader["GRADUATION"].ToString();
                        last_school_attendedValue = reader["LAST_SCHOOL_ATTENDED"].ToString();
                        previous_levelValue = reader["PREVIOUS_LEVEL"].ToString();
                        previous_school_year_attendedValue = reader["PREVIOUS_SCHOOL_YEAR_ATTENDED"].ToString();
                        previous_year_or_gradeValue = reader["PREVIOUS_YEAR_OR_GRADE"].ToString();
                        termValue = reader["TERM"].ToString();
                        father_nameValue = reader["FATHER_NAME"].ToString();
                        father_contact_noValue = reader["FATHER_CONTACT_NO"].ToString();
                        father_occupationValue = reader["FATHER_OCCUPATION"].ToString();
                        father_emailValue = reader["FATHER_EMAIL"].ToString();
                        mother_nameValue = reader["MOTHER_NAME"].ToString();
                        mother_contact_noValue = reader["MOTHER_CONTACT_NO"].ToString();
                        mother_occupationValue = reader["MOTHER_OCCUPATION"].ToString();
                        mother_emailValue = reader["MOTHER_EMAIL"].ToString();
                        guardian_nameValue = reader["GUARDIAN_NAME"].ToString();
                        guardian_contact_noValue = reader["GUARDIAN_CONTACT_NO"].ToString();
                        guardian_occupationValue = reader["GUARDIAN_OCCUPATION"].ToString();
                        guardian_emailValue = reader["GUARDIAN_EMAIL"].ToString();
                        time_and_date_enrolledValue = reader["TIME_AND_DATE_ENROLLED"].ToString();
                        school_yearValue = reader["SCHOOL_YEAR"].ToString();
                    }
                }
            }
        }

        private void generatePDF()
        {
            do
            {
                transaction_idValue = "0" + transaction_idValue;
            }
            while (transaction_idValue.Length < 8);

            PdfDocument document = new PdfDocument();
            document.Info.Title = "STI Front Line PDF";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            page.Width = 612;
            page.Height = 792;

            const string times_new_roman = "Times New Roman";
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.WinAnsi, PdfFontEmbedding.Default);
            XFont fontHeader = new XFont(times_new_roman, 20, XFontStyle.Regular, options);
            gfx.DrawString("Student Information", fontHeader, XBrushes.DarkSlateGray, 30, 50);

            XPen pen = new XPen(XColors.Black, 0.5);
            gfx.DrawLine(pen, 30, 60, 580, 60);

            const string arial = "Arial";
            XFont fontRegular = new XFont(arial, 12, XFontStyle.Regular, options);

            gfx.DrawString("Transaction ID ", fontRegular, XBrushes.Black, 119, 110);
            gfx.DrawString("School Level ", fontRegular, XBrushes.Black, 128, 125);
            gfx.DrawString("Student ID ", fontRegular, XBrushes.Black, 140, 140);
            gfx.DrawString("Course ", fontRegular, XBrushes.Black, 158, 155);
            gfx.DrawString("Year/Grade ", fontRegular, XBrushes.Black, 135, 170);
            gfx.DrawString("LRN/ESC ", fontRegular, XBrushes.Black, 145, 185);
            gfx.DrawString("Student Name ", fontRegular, XBrushes.Black, 120, 200);
            gfx.DrawString("Birth Date ", fontRegular, XBrushes.Black, 143, 215);
            gfx.DrawString("Birth Place ", fontRegular, XBrushes.Black, 139, 230);
            gfx.DrawString("Citizenship ", fontRegular, XBrushes.Black, 138, 245);
            gfx.DrawString("Civil Status ", fontRegular, XBrushes.Black, 137, 260);
            gfx.DrawString("Gender ", fontRegular, XBrushes.Black, 157, 275);
            gfx.DrawString("Current Address ", fontRegular, XBrushes.Black, 109, 290);
            gfx.DrawString("Permanent Address ", fontRegular, XBrushes.Black, 91, 305);
            gfx.DrawString("Landline ", fontRegular, XBrushes.Black, 151, 320);
            gfx.DrawString("Mobile ", fontRegular, XBrushes.Black, 161, 335);
            gfx.DrawString("Email ", fontRegular, XBrushes.Black, 167, 350);
            gfx.DrawString("Previous School Level ", fontRegular, XBrushes.Black, 78, 365);
            gfx.DrawString("Graduation ", fontRegular, XBrushes.Black, 138, 380);
            gfx.DrawString("Last School Attended ", fontRegular, XBrushes.Black, 82, 395);
            gfx.DrawString("Previous Level ", fontRegular, XBrushes.Black, 118, 410);
            gfx.DrawString("Previous School Year Attended ", fontRegular, XBrushes.Black, 30, 425);
            gfx.DrawString("Previous Year/Grade ", fontRegular, XBrushes.Black, 85, 440);
            gfx.DrawString("Term ", fontRegular, XBrushes.Black, 168, 455);
            gfx.DrawString("Father's Name ", fontRegular, XBrushes.Black, 119, 470);
            gfx.DrawString("Father's Contact No. ", fontRegular, XBrushes.Black, 87, 485);
            gfx.DrawString("Father's Occupation ", fontRegular, XBrushes.Black, 89, 500);
            gfx.DrawString("Father's Email ", fontRegular, XBrushes.Black, 120, 515);
            gfx.DrawString("Mother's Name ", fontRegular, XBrushes.Black, 116, 530);
            gfx.DrawString("Mother's Contact No. ", fontRegular, XBrushes.Black, 84, 545);
            gfx.DrawString("Mother's Occupation ", fontRegular, XBrushes.Black, 86, 560);
            gfx.DrawString("Mother's Email ", fontRegular, XBrushes.Black, 117, 575);
            gfx.DrawString("Guardian's Name ", fontRegular, XBrushes.Black, 103, 590);
            gfx.DrawString("Guardian's Contact No. ", fontRegular, XBrushes.Black, 71, 605);
            gfx.DrawString("Guardian's Occupation ", fontRegular, XBrushes.Black, 74, 620);
            gfx.DrawString("Guardian's Email ", fontRegular, XBrushes.Black, 106, 635);
            gfx.DrawString("Time & Data Enrolled ", fontRegular, XBrushes.Black, 83, 650);
            gfx.DrawString("School Year " + ": ", fontRegular, XBrushes.Black, 131, 665);

            gfx.DrawString(": " + transaction_idValue, fontRegular, XBrushes.Black, 200, 110);
            gfx.DrawString(": " + school_levelValue, fontRegular, XBrushes.Black, 200, 125);
            gfx.DrawString(": " + student_idValue, fontRegular, XBrushes.Black, 200, 140);
            gfx.DrawString(": " + courseValue, fontRegular, XBrushes.Black, 200, 155);
            gfx.DrawString(": " + year_or_gradeValue, fontRegular, XBrushes.Black, 200, 170);
            gfx.DrawString(": " + lrn_or_escValue, fontRegular, XBrushes.Black, 200, 185);
            gfx.DrawString(": " + student_nameValue, fontRegular, XBrushes.Black, 200, 200);
            gfx.DrawString(": " + birth_dateValue, fontRegular, XBrushes.Black, 200, 215);
            gfx.DrawString(": " + birth_placeValue, fontRegular, XBrushes.Black, 200, 230);
            gfx.DrawString(": " + citizenshipValue, fontRegular, XBrushes.Black, 200, 245);
            gfx.DrawString(": " + civil_statusValue, fontRegular, XBrushes.Black, 200, 260);
            gfx.DrawString(": " + genderValue, fontRegular, XBrushes.Black, 200, 275);
            gfx.DrawString(": " + current_addressValue, fontRegular, XBrushes.Black, 200, 290);
            gfx.DrawString(": " + permanent_addressValue, fontRegular, XBrushes.Black, 200, 305);
            gfx.DrawString(": " + landlineValue, fontRegular, XBrushes.Black, 200, 320);
            gfx.DrawString(": " + mobileValue, fontRegular, XBrushes.Black, 200, 335);
            gfx.DrawString(": " + emailValue, fontRegular, XBrushes.Black, 200, 350);
            gfx.DrawString(": " + previous_school_levelValue, fontRegular, XBrushes.Black, 200, 365);
            gfx.DrawString(": " + graduationValue, fontRegular, XBrushes.Black, 200, 380);
            gfx.DrawString(": " + last_school_attendedValue, fontRegular, XBrushes.Black, 200, 395);
            gfx.DrawString(": " + previous_levelValue, fontRegular, XBrushes.Black, 200, 410);
            gfx.DrawString(": " + previous_school_year_attendedValue, fontRegular, XBrushes.Black, 200, 425);
            gfx.DrawString(": " + previous_year_or_gradeValue, fontRegular, XBrushes.Black, 200, 440);
            gfx.DrawString(": " + termValue, fontRegular, XBrushes.Black, 200, 455);
            gfx.DrawString(": " + father_nameValue, fontRegular, XBrushes.Black, 200, 470);
            gfx.DrawString(": " + father_contact_noValue, fontRegular, XBrushes.Black, 200, 485);
            gfx.DrawString(": " + father_occupationValue, fontRegular, XBrushes.Black, 200, 500);
            gfx.DrawString(": " + father_emailValue, fontRegular, XBrushes.Black, 200, 515);
            gfx.DrawString(": " + mother_nameValue, fontRegular, XBrushes.Black, 200, 530);
            gfx.DrawString(": " + mother_contact_noValue, fontRegular, XBrushes.Black, 200, 545);
            gfx.DrawString(": " + mother_occupationValue, fontRegular, XBrushes.Black, 200, 560);
            gfx.DrawString(": " + mother_emailValue, fontRegular, XBrushes.Black, 200, 575);
            gfx.DrawString(": " + guardian_nameValue, fontRegular, XBrushes.Black, 200, 590);
            gfx.DrawString(": " + guardian_contact_noValue, fontRegular, XBrushes.Black, 200, 605);
            gfx.DrawString(": " + guardian_occupationValue, fontRegular, XBrushes.Black, 200, 620);
            gfx.DrawString(": " + guardian_emailValue, fontRegular, XBrushes.Black, 200, 635);
            gfx.DrawString(": " + time_and_date_enrolledValue, fontRegular, XBrushes.Black, 200, 650);
            gfx.DrawString(": " + school_yearValue, fontRegular, XBrushes.Black, 200, 665);

            gfx.DrawLine(pen, 30, 720, 580, 720);

            DateTime currentTime = DateTime.Now;

            String Time_And_Date_Generated = currentTime.ToString("MM-dd-yyyy hh:mm tt");

            gfx.DrawString("" + Time_And_Date_Generated, fontRegular, XBrushes.Black, 30, 745);

            try
            {

                string siteDIR= System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\SiteDirectory.txt");
                
                string path = @"" + siteDIR + "\\STI Front Line\\data\\";

                String date_time = currentTime.ToString("MMddyyyyhhmmtt");

                string file = date_time + dnmbrTXTBXNM.Text;

                convert = StringToBinary(file);

                string filename = path+ convert +".pdf";

                try
                {
                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);

                        document.Save(filename);
                        datatoWEB();
                    }
                    else
                    {
                        document.Save(filename);
                        datatoWEB();
                    }
                }
                catch (IOException ioex)
                {
                    MessageBox.Show("" + ioex);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert student data to Xampp Server.");
            }
        }

        private void datatoWEB()
        {
            MySql.Data.MySqlClient.MySqlConnection connection;
            string server = System.IO.File.ReadAllText(@"C:\ProgramData\STI Front Line\System Files\Local\WebConfig.txt"); ;
            string database = "dbfrontline";
            string uid = "root";
            string password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; SslMode = none;";
            connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                convert = convert + ".pdf";

                MySqlCommand cmd = new MySqlCommand("insert into tblenrollees (transactionid,studentid,student,course,schoolyear,file) VALUES (@transactionid,@studentid,@student,@course,@schoolyear,@file)", connection);
                cmd.Parameters.AddWithValue("@transactionid", transaction_idValue);
                cmd.Parameters.AddWithValue("@studentid", student_idValue);
                cmd.Parameters.AddWithValue("@student", student_nameValue);
                cmd.Parameters.AddWithValue("@course", courseValue);
                cmd.Parameters.AddWithValue("@schoolyear", school_yearValue);
                cmd.Parameters.AddWithValue("@file", convert);
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Data Was Inserted To XAMPP Successfully");
            }
            else
            {
                MessageBox.Show("Failed To Insert Student Data Information.");
            }

            connection.Close();
        }

        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
    }
}
