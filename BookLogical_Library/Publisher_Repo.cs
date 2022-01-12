using BookData_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogical_Library
{
  public  class Publisher_Repo:IPublisher_repo
    {
        private readonly BookStoreDBContext Db= new BookStoreDBContext();

        public async Task<bool>AddPublisher(Publisher publisher)
        {
            Publisher exPublisher = await Db.Publishers.FindAsync(publisher.PublisherId);
            if (exPublisher != null)
            {
                return false;
            }
            else
            {
                Db.Add(publisher);
                await Db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> ModifyPublisher(int id,string publisherName)
        {
            Publisher exPublisher = await Db.Publishers.FindAsync(id);
            if(exPublisher!=null)
            {
                exPublisher.Name = publisherName;
                await Db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Publisher>> GetAllPublisher()
        {
            return await Db.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            Publisher exPublisher = await Db.Publishers.FindAsync(id);
            if (exPublisher != null)
            {
                return exPublisher;

            }
            else
            {
                return null;
            }
        }

    }
}
