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
    public partial class PersonOperationWindow : Window
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        List<Person> personList = new List<Person>();

        public PersonOperationWindow()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                GetPersonData(connection);
            }
        }

        private void personGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (personGrid.SelectedItem is Person selectedPerson)
            {
                TbFirstName.Text = selectedPerson.FirstName;
                TbLastName.Text = selectedPerson.LastName;
                TbSecondName.Text = selectedPerson.SecondName;
                TbAdress.Text = selectedPerson.Address;
                TbPhoneNumber.Text = selectedPerson.PhoneNumber;
                TbClassNumber.Text = selectedPerson.ClassNumber;
                TbLogin.Text = selectedPerson.Login;
                TbPassword.Text = selectedPerson.Password;
                CbIsAdmin.IsChecked = selectedPerson.IsAdmin;
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

        public void GetPersonData(SqlConnection connection)
        {
            string sqlExpression = "SELECT PersonID, FirstName, LastName, SecondName, Address, PhoneNumber, ClassNumber, Login, Password, isAdmin FROM Person  INNER JOIN Accounts ON Person.AccountsID = Accounts.AccountsID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    personList.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetBoolean(9)));
                }
                personGrid.ItemsSource = personList.ToList();
            }
            reader.Close();
            personList.Clear();
        }

        public void AddRow(SqlConnection connection)
        {
            string sqlExpression1 = $"INSERT INTO Accounts VALUES('{TbLogin.Text}', '{TbPassword.Text}', '{CbIsAdmin.IsChecked}');";
            SqlCommand command1 = new SqlCommand(sqlExpression1, connection);
            command1.ExecuteNonQuery();
            int accountId = default;
            string sqlExpressionRead = "SELECT TOP 1 AccountsID FROM Accounts ORDER BY AccountsID DESC";
            SqlCommand commandRead = new SqlCommand(sqlExpressionRead, connection);
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    accountId = reader.GetInt32(0);
                }
            }
            reader.Close();

            string sqlExpression2 = $"INSERT INTO Person VALUES('{TbFirstName.Text}', '{TbLastName.Text}', '{TbSecondName.Text}', '{TbAdress.Text}', '{TbPhoneNumber.Text}', '{TbClassNumber.Text}', '{accountId}');";
            SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
            command2.ExecuteNonQuery();
            GetPersonData(connection);

            TbFirstName.Text = "";
            TbLastName.Text = "";
            TbSecondName.Text = "";
            TbAdress.Text = "";
            TbPhoneNumber.Text = "";
            TbClassNumber.Text = "";
            TbLogin.Text = "";
            TbPassword.Text = "";
            CbIsAdmin.IsChecked = false;
        }

        public void UpdateRow(SqlConnection connection)
        {
            if (personGrid.SelectedItem is Person selectedPerson)
            {
                int accountId = default;
                string sqlExpressionRead = $"SELECT Accounts.AccountsID FROM Accounts INNER JOIN Person ON Person.AccountsID = Accounts.AccountsID WHERE Person.PersonID = '{selectedPerson.PersonId}'";
                SqlCommand commandRead = new SqlCommand(sqlExpressionRead, connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        accountId = reader.GetInt32(0);
                    }
                }
                reader.Close();

                string sqlExpression1 = $"UPDATE Accounts SET Login = '{TbLogin.Text}', Password = '{TbPassword.Text}', isAdmin = '{CbIsAdmin.IsChecked}' WHERE AccountsID = '{accountId}'";
                SqlCommand command1 = new SqlCommand(sqlExpression1, connection);
                command1.ExecuteNonQuery();

                string sqlExpression2 = $"UPDATE Person SET FirstName = '{TbFirstName.Text}', LastName = '{TbLastName.Text}', SecondName = '{TbSecondName.Text}', Address = '{TbAdress.Text}', PhoneNumber = '{TbPhoneNumber.Text}', ClassNumber = '{TbClassNumber.Text}' WHERE PersonID = '{selectedPerson.PersonId}'";
                SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                command2.ExecuteNonQuery();

                GetPersonData(connection);

                TbFirstName.Text = "";
                TbLastName.Text = "";
                TbSecondName.Text = "";
                TbAdress.Text = "";
                TbPhoneNumber.Text = "";
                TbClassNumber.Text = "";
                TbLogin.Text = "";
                TbPassword.Text = "";
                CbIsAdmin.IsChecked = false;
            }
        }
        public void DeleteRow(SqlConnection connection)
        {
            if (personGrid.SelectedItem is Person selectedPerson)
            {
                int accountId = default;
                string sqlExpressionRead = $"SELECT Accounts.AccountsID FROM Accounts INNER JOIN Person ON Person.AccountsID = Accounts.AccountsID WHERE Person.PersonID = '{selectedPerson.PersonId}'";
                SqlCommand commandRead = new SqlCommand(sqlExpressionRead, connection);
                SqlDataReader reader = commandRead.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        accountId = reader.GetInt32(0);
                    }
                }
                reader.Close();

                string sqlExpression1 = $"DELETE FROM Person WHERE PersonID = '{selectedPerson.PersonId}'";
                SqlCommand command1 = new SqlCommand(sqlExpression1, connection);
                command1.ExecuteNonQuery();

                string sqlExpression2 = $"DELETE FROM Accounts WHERE AccountsID = '{accountId}'";
                SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                command2.ExecuteNonQuery();

                GetPersonData(connection);

                TbFirstName.Text = "";
                TbLastName.Text = "";
                TbSecondName.Text = "";
                TbAdress.Text = "";
                TbPhoneNumber.Text = "";
                TbClassNumber.Text = "";
                TbLogin.Text = "";
                TbPassword.Text = "";
                CbIsAdmin.IsChecked = false;
            }
        }
    }
}

