using BookData_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogical_Library
{
   public interface IBook_Repo
    {
        Task<bool> AddBook(Book book);
        Task<Book> GetBookById(int id);
        Task<bool> ModifyBook(int id, Book book);
        Task<IEnumerable<Book>> GetBookByPublisherId(int publisherId);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
