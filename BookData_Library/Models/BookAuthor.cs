using System;
using System.Collections.Generic;

#nullable disable

namespace BookData_Library.Models
{
    public partial class BookAuthor
    {
        public int BookAuthorId { get; set; }
        public int BookId { get; set; }
        public int PublisherId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
