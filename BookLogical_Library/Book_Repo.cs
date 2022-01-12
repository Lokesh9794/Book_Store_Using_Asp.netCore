using BookData_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogical_Library
{
   public class Book_Repo:IBook_Repo
    {
        private readonly BookStoreDBContext Db = new BookStoreDBContext();
        public async Task<bool> AddBook(Book book)
        {
            Book exBook = await Db.Books.FindAsync(book.BookId);
            if(exBook!=null)
            {
                return false;
            }
            else
            {
                 await Db.Books.AddAsync(book);
                await Db.SaveChangesAsync();
                return true;
            }
        }
        public async Task<Book> GetBookById(int id)
        {
            Book exBook = await Db.Books.FindAsync(id);
            if (exBook != null)
            {
                return exBook;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> ModifyBook(int id,Book book)
        {
            Book exBook = await Db.Books.FindAsync(id);
            if(exBook!=null)
            {
                exBook.Name = book.Name;
                exBook.Title = book.Title;
                exBook.TotalPage = book.TotalPage;
                exBook.Rating = book.Rating;
                exBook.Isbn = book.Isbn;
                await Db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<IEnumerable<Book>> GetBookByPublisherId(int publisherId)
        {
            return await Db.Books.Where(b => b.PublisherId == publisherId).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await Db.Books.ToListAsync();
        }

    }
}
