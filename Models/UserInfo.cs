using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public partial class UserInfo
    {
        public string UserId { get; set; }
      
        [Required]
       [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
