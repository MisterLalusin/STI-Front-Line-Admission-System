using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Interaction logic for StudentProfileDialog.xaml
    /// </summary>
    public partial class StudentProfileDialog : Window
    {
        string TRANSACTION_ID;
        public string TRANSACTION_ID_PASS { get; set; }
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

        public StudentProfileDialog(string form1)
        {
            InitializeComponent();

            CenterWindow();

            TRANSACTION_ID = form1;

            try
            {
                retrieveStudentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            displayStudentData();
        }

        private void displayStudentData()
        {
            do
            {
                transaction_idValue = "0" + transaction_idValue;
            }
            while (transaction_idValue.Length < 8);

            trnsctndTXTBLCKNM.Text = "Transaction ID: " + transaction_idValue;
            schlllvlTXTBLCKNM.Text = "School Level: " + school_levelValue;
            stdntdTXTBLCKNM.Text = "Student ID: " + student_idValue;
            crsTXTBLCKNM.Text = "Course: " + courseValue;
            yrrgrdTXTBLCKNM.Text = "Year/Grade: " + year_or_gradeValue;
            lrnrscTXTBLCKNM.Text = "LRN/ESC: " + lrn_or_escValue;
            stdntnmTXTBLCKNM.Text = "Student Name: " + student_nameValue;
            brthdtTXTBLCKNM.Text = "Birth Date: " + birth_dateValue;
            brthplcTXTBLCKNM.Text = "Birth Place: " + birth_placeValue;
            ctznshpTXTBLCKNM.Text = "Citizenship: " + citizenshipValue;
            cvlsttsTXTBLCKNM.Text = "Civil Status: " + civil_statusValue;
            gndrTXTBLCKNM.Text = "Gender: " + civil_statusValue;
            crrntddrssTXTBLCKNM.Text = "Current Address:" + current_addressValue;
            prmntddrssTXTBLCKNM.Text = "Permanent Address: " + permanent_addressValue;
            lndlnTXTBLCKNM.Text = "Landline: " + landlineValue;
            mblTXTBLCKNM.Text = "Mobile: " + mobileValue;
            mlTXTBLCKNM.Text = "Email: " + emailValue;
            prvsschllvlTXTBLXKNM.Text = "Previous School Level: " + previous_levelValue;
            grdtnTXBLCKNM.Text = "Graduation: " + graduationValue;
            lstschllttnddTXTBLCKNM.Text = "Last School Attended: " + last_school_attendedValue;
            prvslvlTXTBLCKNM.Text = "Previous Level: " + previous_levelValue;
            prvsschlyrttnddTXTBLCKNM.Text = "Previous School Year Attended: " + previous_school_year_attendedValue;
            prvsyrrgrdTXTBLCKNM.Text = "Previous Year/Grade: " + previous_year_or_gradeValue;
            trmTXTBLCKNM.Text = "Term: " + termValue;
            fthrnmTXTBLCKNM.Text = "Father's Name: " + father_nameValue;
            fthrcntctnmbrTXTBLCKNM.Text = "Father's Contact Number: " + father_contact_noValue;
            fthrccptnTXTBLCKNM.Text = "Father's Occupation: " + father_occupationValue;
            fthrmlTXTBLCKNM.Text = "Father's Email: " + father_emailValue;
            mthrnmTXTBLCKNM.Text = "Mother's Name: " + mother_nameValue;
            mthrcntctnmbrTXTBLCKNM.Text = "Mother's Contact Number: " + mother_contact_noValue;
            mthrccptnTXTBLCKNM.Text = "Mother's Occupation: " + mother_occupationValue;
            mthrmlTXTBLCKNM.Text = "Mother's Email: " + mother_emailValue;
            grdnnmTXTBLCKNM.Text = "Guardian's Name: " + guardian_nameValue;
            grdncntctnmbrTXTBLCKNM.Text = "Guardian's Contact Number: " + guardian_contact_noValue;
            grdnccptnTXTBLCKNM.Text = "Guardian's Occupation: " + guardian_occupationValue;
            grdnmlTXTBLCKNM.Text = "Guardian's Email: " + guardian_emailValue;
            tmnddtnrlldTXTBLCKNM.Text = "Time & Date Enrolled: " + time_and_date_enrolledValue;
            schlyrTXTBLCKNM.Text = "School Year: " + school_yearValue;
            hdrTXTBLCKNM.Text = student_nameValue;
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
            gfx.DrawString("Year/Grade " , fontRegular, XBrushes.Black, 135, 170);
            gfx.DrawString("LRN/ESC " , fontRegular, XBrushes.Black, 145, 185);
            gfx.DrawString("Student Name ", fontRegular, XBrushes.Black, 120, 200);
            gfx.DrawString("Birth Date " , fontRegular, XBrushes.Black, 143, 215);
            gfx.DrawString("Birth Place " , fontRegular, XBrushes.Black, 139, 230);
            gfx.DrawString("Citizenship " , fontRegular, XBrushes.Black, 138, 245);
            gfx.DrawString("Civil Status " , fontRegular, XBrushes.Black, 137, 260);
            gfx.DrawString("Gender " , fontRegular, XBrushes.Black, 157, 275);
            gfx.DrawString("Current Address " , fontRegular, XBrushes.Black, 109, 290);
            gfx.DrawString("Permanent Address " , fontRegular, XBrushes.Black, 91, 305);
            gfx.DrawString("Landline " , fontRegular, XBrushes.Black, 151, 320);
            gfx.DrawString("Mobile " , fontRegular, XBrushes.Black, 161, 335);
            gfx.DrawString("Email " , fontRegular, XBrushes.Black, 167, 350);
            gfx.DrawString("Previous School Level " , fontRegular, XBrushes.Black, 78, 365);
            gfx.DrawString("Graduation " , fontRegular, XBrushes.Black, 138, 380);
            gfx.DrawString("Last School Attended " , fontRegular, XBrushes.Black, 82, 395);
            gfx.DrawString("Previous Level " , fontRegular, XBrushes.Black, 118, 410);
            gfx.DrawString("Previous School Year Attended " , fontRegular, XBrushes.Black, 30, 425);
            gfx.DrawString("Previous Year/Grade " , fontRegular, XBrushes.Black, 85, 440);
            gfx.DrawString("Term " , fontRegular, XBrushes.Black, 168, 455);
            gfx.DrawString("Father's Name " , fontRegular, XBrushes.Black, 119, 470);
            gfx.DrawString("Father's Contact No. " , fontRegular, XBrushes.Black, 87, 485);
            gfx.DrawString("Father's Occupation " , fontRegular, XBrushes.Black, 89, 500);
            gfx.DrawString("Father's Email " , fontRegular, XBrushes.Black, 120, 515);
            gfx.DrawString("Mother's Name " , fontRegular, XBrushes.Black, 116, 530);
            gfx.DrawString("Mother's Contact No. " , fontRegular, XBrushes.Black, 84, 545);
            gfx.DrawString("Mother's Occupation ", fontRegular, XBrushes.Black, 86, 560);
            gfx.DrawString("Mother's Email " , fontRegular, XBrushes.Black, 117, 575);
            gfx.DrawString("Guardian's Name " , fontRegular, XBrushes.Black, 103, 590);
            gfx.DrawString("Guardian's Contact No. " , fontRegular, XBrushes.Black, 71, 605);
            gfx.DrawString("Guardian's Occupation ", fontRegular, XBrushes.Black, 74, 620);
            gfx.DrawString("Guardian's Email " , fontRegular, XBrushes.Black, 106, 635);
            gfx.DrawString("Time & Data Enrolled " , fontRegular, XBrushes.Black, 83, 650);
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

            gfx.DrawString(""+Time_And_Date_Generated, fontRegular, XBrushes.Black, 30, 745);

            string filename = string.Empty;
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = student_nameValue;
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF documents (.pdf)|*.pdf";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                try
                {
                    filename = dlg.FileName;
                    document.Save(filename);
                    Process.Start(filename);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("File is open with other programs.");
                }
            }
        }

        private void gnrtpdfBTTNNM_Click(object sender, RoutedEventArgs e)
        {
            generatePDF();
        }
    }
}