using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
using System.Xml.Linq;

namespace WpfApp1
{
    public partial class MarksOperationWindow : Window
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        List<Marks> marks = new List<Marks>();

        public MarksOperationWindow()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                GetMarksData(connection);
            }
        }

        public void GetMarksData(SqlConnection connection)
        {
            string sqlExpression = "SELECT MarksID, Title, Mark, Description, DateAdded, CONCAT(LastName, ' ', LEFT(FirstName, 1),'. ', LEFT(SecondName, 1), '.') FROM Marks  INNER JOIN Person ON Person.PersonID = Marks.personMark";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    marks.Add(new Marks(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5)));
                }
                marksGrid.ItemsSource = marks.ToList();
            }
            reader.Close();
            marks.Clear();
        }

        private void marksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (marksGrid.SelectedItem is Marks selectedMarks)
            {
                TbName.Text = selectedMarks.Title;
                TbDesc.Text = selectedMarks.Description;
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
            SqlDateTime myDateTime = DateTime.Now;

            string sqlExpression = $"INSERT INTO Marks VALUES('{TbName.Text}', '{TbMark.Text}', '{TbDesc.Text}', GETDATE(), '{TbStudent.Text}');";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            GetMarksData(connection);
        }

        public void UpdateRow(SqlConnection connection)
        {
            if (marksGrid.SelectedItem is Marks selectedMarks)
            {
                string sqlExpression = $"UPDATE Marks SET Title = '{TbName.Text}', Description = '{TbDesc.Text}', Mark = '{TbMark.Text}', personMark = '{TbStudent.Text}' WHERE MarksID='{selectedMarks.Id}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                GetMarksData(connection);

                TbMark.Text = "";
                TbName.Text = "";
                TbDesc.Text = "";
                TbStudent.Text = "";
            }
        }

        public void DeleteRow(SqlConnection connection)
        {
            if (marksGrid.SelectedItem is Marks selectedMarks)
            {
                string sqlExpression = $"DELETE FROM Marks WHERE MarksID='{selectedMarks.Id}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                GetMarksData(connection);

                TbMark.Text = "";
                TbName.Text = "";
                TbDesc.Text = "";
                TbStudent.Text = "";
            }
        }
    }
}