using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using BookShop.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace BookShop.Service
{
    public class UserSevice : IUser
    {
        private readonly BookShopContext _usercontext;
        private readonly JWTConfigToken _jwt;


        public UserSevice(BookShopContext usercontext, IOptions<JWTConfigToken> jWT)
        {
            this._usercontext = usercontext;
            this._jwt = jWT.Value;
        }
        

        public JWTTokenString Login(string UName, string pwd)
        {
            string Jwt = string.Empty;
            var isUserValid = _usercontext.UserInfo.Where(x => x.UserId == UName & x.Password == pwd);
            if (isUserValid != null)
            {
                Jwt = GenerateToken(UName, 30, _jwt.PrivateKey);
            }
            return new JWTTokenString
            {
                TokenString = Jwt
            };
        }   

        public void Logout(string UserId)
        {
            throw new NotImplementedException();
        }

        public void Register(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public static string GenerateToken(string username, int expireMinutes, string key)
        {
            var symmetricKey = System.Text.Encoding.ASCII.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, username)
        }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

    }
}
