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
using System.Net;
using System.Data.SqlClient;

namespace WpfApp1
{
    public partial class MyAccountPage : Page
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        List<Person> person = new List<Person>();
        public MainWindow mainWindow;
        public int accountId = 0;
        public MyAccountPage()
        {
            InitializeComponent();
        }


        public void GetPersonData(SqlConnection connection)
        {
            string sqlExpression = $"SELECT FirstName, LastName, SecondName, Address, PhoneNumber, ClassNumber FROM Person WHERE AccountsID = {accountId}";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    person.Add(new Person(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                }
                TbFirstName.Text = person[0].FirstName;
                TbLastName.Text = person[0].LastName;
                TbSecondName.Text = person[0].SecondName;
                TbPhoneNumber.Text = person[0].PhoneNumber;
                TbAddress.Text = person[0].Address;
                TbClassNumber.Text = person[0].ClassNumber;
            }
            reader.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            mainWindow.Hide();
        }

        public void VisibilityAdminButton(Visibility visibility)
        {
            adminButton.Visibility = visibility;
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPanelWindow adminPanel = new AdminPanelWindow();
            adminPanel.Show();
        }
    }
}
