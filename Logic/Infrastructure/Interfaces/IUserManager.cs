using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Infrastructure.Interfaces
{
    public interface IUserManager
    {
        Task<bool> LoginUser(string username, string password);
    }
}
