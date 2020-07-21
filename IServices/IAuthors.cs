using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.IServices
{
    public interface IAuthors
    {
        public Authors GetAuthor(string id);
        public void AddAuthor(Authors info);
        public void updateAuthor(string id , Authors updateinfo);
        public void PartialupdateAuthor(string id, Authors partialupdateinfo);

    }
}
