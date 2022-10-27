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

namespace WpfApp1
{
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();
        }

        private void Marks_Click(object sender, RoutedEventArgs e)
        {
            MarksOperationWindow marksOperationWindow = new MarksOperationWindow();
            marksOperationWindow.Show();
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            ScheduleOperationWindow scheduleOperationWindow = new ScheduleOperationWindow();
            scheduleOperationWindow.Show();
        }

        private void Subject_Click(object sender, RoutedEventArgs e)
        {
            SubjectOperationWindow subjectOperationWindow = new SubjectOperationWindow();
            subjectOperationWindow.Show();
        }

        private void Person_Click(object sender, RoutedEventArgs e)
        {
            PersonOperationWindow personOperationWindow = new PersonOperationWindow();
            personOperationWindow.Show();
        }
    }
}
