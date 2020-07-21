using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.IServices;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Service
{
    public class UserService : IUser
    {
        private readonly BookShopContext bookShopContext;

        public UserService(BookShopContext bookShopContext)
        {
            this.bookShopContext = bookShopContext;
        }
        //public async Task<JwtToken> Login(UserInfo user)
        //{
        //  //bool IsvalidUser =  Authenticate(user.Email, user.Password);
        //  //  if (IsvalidUser)
        //  //  {

        //  //  }
        //}

        public bool Authenticate(string username, string password)
        {
            if (username != null && password != null)
            {
                var Isuser = bookShopContext.UserInfo.SingleOrDefault(x => x.Email == username && x.Password == password);
                // check if password is correct
                if (Isuser != null)  return true; 
                else return false;

            }
            else return false;
        }
    }
}
