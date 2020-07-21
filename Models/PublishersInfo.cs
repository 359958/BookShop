using System;
using System.Collections.Generic;

namespace BookShop.Models
{
    public partial class PublishersInfo
    {
       public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
