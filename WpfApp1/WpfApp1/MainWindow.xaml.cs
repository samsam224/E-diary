using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";

        public MarksPage marksPage = new MarksPage();
        public SchedulesPage schedulePage = new SchedulesPage();
        public SubjectPage subjectPage = new SubjectPage();
        public MyAccountPage myAccountPage = new MyAccountPage();

        public MainWindow()
        {
            InitializeComponent();
            MyFrame.Content = marksPage;
        }



        private void Marks_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = marksPage;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                marksPage.GetMarksData(connection);
            }
        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = schedulePage;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                schedulePage.GetScheduleData(connection);
            }
        }

        private void Subject_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = subjectPage;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                subjectPage.GetSubjectData(connection);
            }
        }

        private void MyAccount_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = myAccountPage;
            myAccountPage.mainWindow = this;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                myAccountPage.GetPersonData(connection);
            }
        }
    }
}


