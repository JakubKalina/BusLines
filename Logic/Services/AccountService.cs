using Data.UnitOfWork;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logic.Services.Interfaces;
using Logic.ViewModels.Account;
using Logic.Infrastructure;
using Logic.Infrastructure.Interfaces;

namespace Logic.Services
{
    public class AccountService : Service, IAccountService, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        private readonly IUserManager _userManager;

        private static bool _firstRun = true;

        public AccountService(IUnitOfWork unitOfWork, IAccountService accountService, IUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
            _userManager = userManager;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string UpdateDatabase(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logowanie użytkownika
        /// </summary>
        /// <returns></returns>
        public async Task<string> LoginAsync(UserLoginViewModel model)
        {
            var user = _userManager.LoginUser(model.Username, model.Password);
            if (user == false) return "Nieprawidłowa nazwa użytkownika lub hasło.";

        }


    }
}
