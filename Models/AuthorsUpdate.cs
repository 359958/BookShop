using System;
using System.Collections.Generic;
using AutoMapper;

namespace BookShop.Models
{
    public partial class AuthorsUpdate
    {
        public string AuFname { get; set; }
        public string AuLname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
