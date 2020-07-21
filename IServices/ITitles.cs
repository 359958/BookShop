using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.IServices
{
    public interface ITitles
    {
        public Titles GetById(string id);
        public void InsertBook(Titles books);
        public Titles GetBookUpdate(Titles update);
    }
}
