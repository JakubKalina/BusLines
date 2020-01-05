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
using AutoMapper;
using Data.Models;
using Microsoft.Owin.Security;

namespace Logic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        private static bool _firstRun = true;

        public AccountService(IUnitOfWork unitOfWork, IUserManager userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
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
            var result = await _userManager.LoginUser(model.Username, model.Password);
            if (result == null) return null;

            return result;
        }

        /// <summary>
        /// Rejestracja użytkownika
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> RegisterAsync(UserRegisterViewModel viewModel)
        {
            var model = _mapper.Map<Employees>(viewModel);

            var allEmployees = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(model.Login);
            // Dodać wyszukiwanie czy nie istnieje już taki użytkownik

            _unitOfWork.EmployeesRepository.Create(model);
            _unitOfWork.EmployeesRepository.Save();


            // Dodać hashowanie hasła użytkownika
            var i = 1;

            return true;

        }

    }
}
