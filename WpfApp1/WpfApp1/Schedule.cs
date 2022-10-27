using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Schedule
    {
        public Schedule(string subjectName, string cabinetNumber, string classNumber, int lessonNumber, DateTime dateAdded)
        {
            SubjectName = subjectName;
            CabinetNumber = cabinetNumber;
            ClassNumber = classNumber;
            LessonNumber = lessonNumber;
            DateAdded = dateAdded;
        }

        public Schedule(int id, string subjectName, string cabinetNumber, string classNumber, int lessonNumber, DateTime dateAdded)
        {
            Id = id;
            SubjectName = subjectName;
            CabinetNumber = cabinetNumber;
            ClassNumber = classNumber;
            LessonNumber = lessonNumber;
            DateAdded = dateAdded;
        }

        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string CabinetNumber { get; set; }
        public string ClassNumber { get; set; }
        public int LessonNumber { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
