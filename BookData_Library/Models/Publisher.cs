using System;
using System.Collections.Generic;

#nullable disable

namespace BookData_Library.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            BookAuthors = new HashSet<BookAuthor>();
            Books = new HashSet<Book>();
        }

        public int PublisherId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
