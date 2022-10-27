using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Reflection;

namespace WpfApp1
{
    public partial class SchedulesPage : Page
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        List<Schedule> schedules = new List<Schedule>();

        public SchedulesPage()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                GetScheduleData(connection);
            }
        }

        public void GetScheduleData(SqlConnection connection)
        {
            string sqlExpression = "SELECT SubjectName, cabinetNumber, classNumber, lessonNumber, DateAdded FROM Schedules;";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    schedules.Add(new Schedule(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4)));
                }
                scheduleGrid.ItemsSource = schedules.ToList();
            }
            reader.Close();
            schedules.Clear();
        }

        private void DatePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)((DatePicker)sender).SelectedDate;
            dp1.Text = newdate.ToString();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                GetScheduleDataChanged(connection);
            }
        }

        public void GetScheduleDataChanged(SqlConnection connection)
        {
            string sqlExpression = $"SELECT SubjectName, cabinetNumber, classNumber, lessonNumber, DateAdded FROM Schedules WHERE DateAdded = '{dp1.Text}' AND classNumber = '{TbClass.Text}';";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    schedules.Add(new Schedule(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4)));
                }
                scheduleGrid.ItemsSource = schedules.ToList();
            }

            reader.Close();
            schedules.Clear();
        }
    }
}

