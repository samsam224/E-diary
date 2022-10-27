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
    public partial class Authorization : Window
    {
        string connectionString = "Server=DESKTOP-K7UG4KB;Database=Kursovoi;Trusted_Connection=True;";
        public static int currentAccountId;
        bool isAdmin;

        public Authorization()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Autho(connection);
            }
        }

        public void Autho(SqlConnection connection)
        {
            string sqlExpression = "SELECT * FROM Accounts WHERE Login = '" + login.Text + "' AND Password = '" + password.Password + "'";

            try
            {
                if (login.Text != "" && password.Password != "")
                {
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Hide();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        MyAccountPage myAccountPage = new MyAccountPage();
                        MarksPage newsPage = new MarksPage();
                        while (reader.Read())
                        {
                            currentAccountId = (int)reader["AccountsID"];
                            isAdmin = (bool)reader["isAdmin"];
                        }
                        if (isAdmin)
                        {
                            myAccountPage.VisibilityAdminButton(Visibility.Visible);
                        }
                        else
                        {
                            myAccountPage.VisibilityAdminButton(Visibility.Hidden);
                        }
                        myAccountPage.accountId = currentAccountId;
                        mainWindow.myAccountPage = myAccountPage;
                        newsPage.accountId = currentAccountId;
                        mainWindow.marksPage = newsPage;
                    }
                    else
                    {
                        MessageBox.Show("Неправильной логин или пароль.");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка ввода.");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения.");
            }
        }
    }
}

