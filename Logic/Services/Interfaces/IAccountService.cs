using Logic.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IAccountService : IService
    {
        Task<string> LoginAsync(UserLoginViewModel model);
    }
}
