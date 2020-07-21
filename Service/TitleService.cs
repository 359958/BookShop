using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.IServices;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Service
{
    public class TitleService : ITitles
    {
        private readonly BookShopContext dbContext;

        public TitleService(BookShopContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Titles GetById(string id)
        {
            if (id != null)
            {
                var books = dbContext.Titles
                                           .Include(x => x.Pub)
                                           .Include(x => x.Au)
                                           .Where(x => x.TitleId == id)
                                           .FirstOrDefault();
                return books;
            }
            else   return null;
            
        }

        public void InsertBook(Titles books)
        {
            try
            {
                if (books != null)
                {
                    using (var bookcontext = dbContext)
                    {
                        bookcontext.Titles.Add(books);
                        bookcontext.SaveChanges();
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw ex.InnerException;
            }
        }

        public Titles GetBookUpdate(Titles update)
        {
            using (var book = dbContext)
            {
                book.Titles.Update(update);
                book.SaveChanges();
                
            }

            return update;
        }
    }
}
