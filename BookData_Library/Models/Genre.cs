using System;
using System.Collections.Generic;

#nullable disable

namespace BookData_Library.Models
{
    public partial class Genre
    {
        public Genre()
        {
            InverseParent = new HashSet<Genre>();
        }

        public int GenreId { get; set; }
        public string Genre1 { get; set; }
        public int? ParentId { get; set; }

        public virtual Genre Parent { get; set; }
        public virtual ICollection<Genre> InverseParent { get; set; }
    }
}
