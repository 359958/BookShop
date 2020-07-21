﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BookUpdate
    {
        public string TitleId { get; set; }
        public string TitleName { get; set; }
        public string Type { get; set; }
        public int? Pages { get; set; }
        public decimal? Price { get; set; }
        public string AuId { get; set; }
        public string PubId { get; set; }
    }
}
