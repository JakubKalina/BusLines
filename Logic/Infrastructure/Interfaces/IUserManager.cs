using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Infrastructure.Interfaces
{
    public interface IUserManager
    {
        Task<ClaimsPrincipal> LoginUser(string username, string password);
    }
}
