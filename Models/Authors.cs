using System;
using System.Collections.Generic;

namespace BookShop.Models
{
    public partial class Authors
    {
        public Authors()
        {
            Titles = new HashSet<Titles>();
        }

        public string AuId { get; set; }
        public string AuFname { get; set; }
        public string AuLname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public ICollection<Titles> Titles { get; set; }
    }
}
