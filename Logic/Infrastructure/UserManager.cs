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


namespace Logic.Infrastructure
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                        new Claim(ClaimTypes.Role, "Kierowca")
                    };
                }
                else return null;


                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                return principal;







            }
            else return null;
        }

        /// <summary>
        /// Walidacja użytkownika
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> UserIsValid(string username, string password)
        {
            var user = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(username);
            if(user == null)
            {
                return null;
            }
            if (user.Login == username && user.Password == password)
            {
                return user.Role.ToString();
            }
            else return null;
        }

    }
}
