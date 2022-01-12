using System;
using System.Collections.Generic;

#nullable disable

namespace BookData_Library.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int BookId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? TotalPage { get; set; }
        public decimal? Rating { get; set; }
        public string Isbn { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
