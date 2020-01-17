using Data.UnitOfWork;
using Logic.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Logic.Infrastructure
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Interfaces.IPasswordHasher _passwordHasher;

        public UserManager(IUnitOfWork unitOfWork, Interfaces.IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Logowanie użytkownika
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<ClaimsPrincipal> LoginUser(string username, string password)
        {
            string userRole = await UserIsValid(username, password);


            // Jeżeli kierowcy walidacja przebiegła pomyślnie
            if (userRole != null)
            {
                List<Claim> claims;

                if (userRole == "0")
                {
                    // Zapamiętanie kierowcy 
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "Kierowca")
                    };
                }
                else if (userRole == "1")
                {
                    // Zapamiętanie admina
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                }
                else return null;


                //var userIdentity = new ClaimsIdentity(claims, "login");
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                return principal;







            }
            else return null;
        }

        /// <summary>
        /// Walidacja użytkownika
        /// </summary>
        /// <param name="username">Login użytkownika</param>
        /// <param name="password">Hasło użytkownika niezahashowane</param>
        /// <returns></returns>
        public async Task<string> UserIsValid(string username, string password)
        {
            var user = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(username);

            if(user == null)
            {
                return null;
            }

            var mathingPasswords = _passwordHasher.Check(user.Password, password);


            if (mathingPasswords.Verified)
            {
                return user.Role.ToString();
            }
            else return null;
        }

        /// <summary>
        /// Wysyłanie maila z kodem do resetu konta
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="topic"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(int userId, string topic, string body)
        {
            throw new NotImplementedException();
        }

    }

}
