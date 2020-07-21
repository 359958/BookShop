using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BooksInfo
    {
        public string TitleId { get; set; }
        public string TitleName { get; set; }
        public decimal? Price { get; set; }
        public AuthorsInfo Au { get; set; }
        public PublishersInfo Pub { get; set; }
    }
}
