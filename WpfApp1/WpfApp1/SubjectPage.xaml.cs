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
    public partial class SubjectPage : Page
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        List<Subject> subjects = new List<Subject>();

        public SubjectPage()
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
            string sqlExpression = "SELECT title, CONCAT(LastName, ' ', LEFT(FirstName, 1),'. ', LEFT(SecondName, 1), '.') FROM Subjects  INNER JOIN Person ON Person.PersonID = Subjects.teacherName";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    subjects.Add(new Subject(reader.GetString(0), reader.GetString(1)));
                }
                subjectGrid.ItemsSource = subjects.ToList();
            }
            reader.Close();
            subjects.Clear();
        }
    }
}

