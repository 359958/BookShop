using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using BookShop.IServices;
using Microsoft.EntityFrameworkCore;
namespace BookShop.Service
{
    public class AuthorService : IAuthors
    {
        private readonly BookShopContext _dbContext;

        public AuthorService(BookShopContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void AddAuthor(Authors info)
        {
            if (info != null)
            {
                try
                {
                    _dbContext.Authors.Add(info);
                    _dbContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw ex.InnerException;
                }
            }
        }

        public Authors GetAuthor(string id)
        {
            if (id != null)
            {
                var author = _dbContext.Authors.Find(id);
                return author;
            }
            else return null;
        }

        public void PartialupdateAuthor(string id, Authors partialupdateinfo)
        {
            throw new NotImplementedException();
        }

        public void updateAuthor(string id, Authors updateinfo)
        {
            _dbContext.Entry(updateinfo).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
