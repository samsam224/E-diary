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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApp1
{
    public partial class ScheduleOperationWindow : Window
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        List<Schedule> schedules = new List<Schedule>();

        public ScheduleOperationWindow()
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
            string sqlExpression = "SELECT * FROM Schedules";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    schedules.Add(new Schedule(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetDateTime(5)));
                }
                scheduleGrid.ItemsSource = schedules.ToList();
            }
            reader.Close();
            schedules.Clear();
        }

        private void scheduleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (scheduleGrid.SelectedItem is Schedule selectedSchedules)
            {
                TbTitle.Text = selectedSchedules.SubjectName;
                TbCabinet.Text = selectedSchedules.CabinetNumber;
            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                AddRow(connection);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                UpdateRow(connection);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DeleteRow(connection);
            }
        }


        public void AddRow(SqlConnection connection)
        {
            string sqlExpression = $"INSERT INTO Schedules VALUES('{TbTitle.Text}', '{TbCabinet.Text}', '{TbClass.Text}', '{TbLesson.Text}', '{dp2.SelectedDate}');";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            GetScheduleData(connection);

            TbTitle.Text = "";
            TbCabinet.Text = "";
            TbClass.Text = "";
            TbLesson.Text = "";
        }

        public void UpdateRow(SqlConnection connection)
        {
            if (scheduleGrid.SelectedItem is Schedule selectedSchedule)
            {
                string sqlExpression = $"UPDATE Schedules SET subjectName = '{TbTitle.Text}', CabinetNumber = '{TbCabinet.Text}', classNumber = '{TbClass.Text}', lessonNumber = '{TbLesson.Text}', dateAdded = '{dp2.SelectedDate}' WHERE SchedulesID = '{selectedSchedule.Id}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                GetScheduleData(connection);

                TbTitle.Text = "";
                TbCabinet.Text = "";
                TbClass.Text = "";
                TbLesson.Text = "";
            }
        }

        public void DeleteRow(SqlConnection connection)
        {
            if (scheduleGrid.SelectedItem is Schedule selectedSchedule)
            {
                string sqlExpression = $"DELETE FROM Schedules WHERE SchedulesID = '{selectedSchedule.Id}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                GetScheduleData(connection);

                TbTitle.Text = "";
                TbCabinet.Text = "";
                TbClass.Text = "";
                TbLesson.Text = "";
            }
        }
    }
}