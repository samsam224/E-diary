using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Marks
    {
        public Marks(string title, string mark, string description, DateTime dateAdded, string personMark)
        {
            Title = title;
            Mark = mark;
            Description = description;
            DateAdded = dateAdded;
            DateAdded.ToString("dd.MM.yyyy");
            PersonMark = personMark;
        }

        public Marks(int id, string mark, string title, string description, DateTime dateAdded, string personMark)
        {
            Id = id;
            Title = title;
            Mark = mark;
            Description = description;
            DateAdded = dateAdded;
            DateAdded.ToString("dd.MM.yyyy");
            PersonMark = personMark;
        }

        public int Id { get; set; }
        public string Mark { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PersonMark { get; set; }
    }
}
