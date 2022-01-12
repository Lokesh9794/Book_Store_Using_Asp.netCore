using BookData_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogical_Library
{
   public interface IPublisher_repo
    {
         Task<bool> AddPublisher(Publisher publisher);
         Task<bool> ModifyPublisher(int id, string publisherName);
         Task<IEnumerable<Publisher>> GetAllPublisher();
         Task<Publisher> GetPublisherById(int id);
    }
}
