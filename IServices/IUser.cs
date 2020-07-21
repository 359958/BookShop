using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.IServices
{
    public interface IUser
    {
        public JWTTokenString Login(string UName, string pwd);
        public void Register(UserInfo user);
        public void Logout(string UserId);

    }
}
