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
    public partial class MarksPage : Page
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        private List<Marks> marksList = new List<Marks>();
        public int accountId = 0;

        public MarksPage()
        {
            InitializeComponent();
        }

        public void GetMarksData(SqlConnection connection)
        {
            string sqlExpression = $"SELECT Title, Mark, Description, DateAdded, CONCAT(LastName, ' ', LEFT(FirstName, 1),'. ', LEFT(SecondName, 1), '.') FROM Marks INNER JOIN Person ON Person.PersonID = Marks.personMark WHERE personMark = '{accountId}'";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    marksList.Add(new Marks(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4)));
                }
                marksGrid.ItemsSource = marksList.ToList();
            }
            reader.Close();
            marksList.Clear();
        }
    }
}
