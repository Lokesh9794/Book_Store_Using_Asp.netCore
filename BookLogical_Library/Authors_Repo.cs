using BookData_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogical_Library
{
    class Authors_Repo:IAuthors_Repo
    {
        private readonly BookStoreDBContext Db = new BookStoreDBContext();
        public async Task<bool> AddAuthor(Author author)
        {
            Author exAuthor = await Db.Authors.FindAsync(author.AuthorId);
            if (exAuthor != null)
            {
                return false;
            }
            else
            {
                await Db.Authors.AddAsync(author);
                await Db.SaveChangesAsync();
                return true;
            }
        }
        public async Task<Author> GetAuthorById(int id)
        {
            Author exAuthor = await Db.Authors.FindAsync(id);
            if (exAuthor != null)
            {
                return exAuthor;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> ModifyAuthor(int id, Author author)
        {
            Author exAuthor = await Db.Authors.FindAsync(id);
            if (exAuthor != null)
            {
                exAuthor.FirstName = author.FirstName;
                exAuthor.LastName = author.LastName;
                await Db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await Db.Authors.ToListAsync();
        }

        public async Task<bool> AddBookAuthor(BookAuthor bookAuthor)
        {   
                await Db.BookAuthors.AddAsync(bookAuthor);
                await Db.SaveChangesAsync();
                return true;   
        }

    }
}
