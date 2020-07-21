using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public partial class Titles
    {
        public string TitleId { get; set; }
        public string TitleName { get; set; }
        public string Type { get; set; }
        public string PubId { get; set; }
        public int? Pages { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Pubdate { get; set; }
        public string AuId { get; set; }
        public virtual Authors Au { get; set; }
        public virtual Publishers Pub { get; set; }
    }
}
