using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Subject
    {
        public Subject(string title, string teacherName)
        {
            Title = title;
            TeacherName = teacherName;
        }

        public Subject(int id, string title, string teacherName)
        {
            Id = id;
            Title = title;
            TeacherName = teacherName;
        }

        public Subject(string title)
        {
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string TeacherName { get; set; }
    }
}
