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
    public partial class SubjectOperationWindow : Window
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        List<Subject> subjects = new List<Subject>();

        public SubjectOperationWindow()
        {
            InitializeComponent();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                GetSubjectData(connection);
            }
        }

        public void GetSubjectData(SqlConnection connection)
        {
            string sqlExpression = "SELECT SubjectsID, title, CONCAT(LastName, ' ', LEFT(FirstName, 1),'. ', LEFT(SecondName, 1), '.') FROM Subjects INNER JOIN Person ON Person.PersonID = Subjects.teacherName";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    subjects.Add(new Subject(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
                subjectGrid.ItemsSource = subjects.ToList();
            }
            reader.Close();
            subjects.Clear();
        }

        private void subjectGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (subjectGrid.SelectedItem is Subject selectedSubject)
            {
                TbTitle.Text = selectedSubject.Title;
                TbTeacher.Text = selectedSubject.TeacherName;
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
            string sqlExpression = $"INSERT INTO Subjects VALUES('{TbTitle.Text}', '{TbTeacher.Text}');";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            GetSubjectData(connection);

            TbTitle.Text = "";
            TbTeacher.Text = "";
        }

        public void UpdateRow(SqlConnection connection)
        {
            if (subjectGrid.SelectedItem is Subject selectedSubject)
            {
                string sqlExpression = $"UPDATE Subjects SET title = '{TbTitle.Text}', teacherName = '{TbTeacher.Text}' WHERE SubjectsID = '{selectedSubject.Id}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                GetSubjectData(connection);

                TbTitle.Text = "";
                TbTeacher.Text = "";
            }
        }

        public void DeleteRow(SqlConnection connection)
        {
            if (subjectGrid.SelectedItem is Subject selectedSubject)
            {
                string sqlExpression = $"DELETE FROM Subjects WHERE SubjectsID = '{selectedSubject.Id}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                GetSubjectData(connection);

                TbTitle.Text = "";
                TbTeacher.Text = "";
            }
        }
    }
}
