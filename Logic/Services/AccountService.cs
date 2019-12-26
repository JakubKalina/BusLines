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
using System.Security.Claims;

namespace Logic.Services
{
    public class AccountService : Service, IAccountService, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        private static bool _firstRun = true;

        public AccountService(IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _unitOfWork = unitOfWork;
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
        public async Task<ClaimsPrincipal> LoginAsync(UserLoginViewModel model)
        {
            var ident = await _userManager.LoginUser(model.Username, model.Password);
            if (ident == null) return null;

            return ident;
        }

        /// <summary>
        /// Rejestracja użytkownika
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> RegisterAsync(UserRegisterViewModel model)
        {
            // Dodac mapowanie z ViewModelu na Model

            throw new NotImplementedException();
        }
    }
}
