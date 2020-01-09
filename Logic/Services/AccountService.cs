using Data.UnitOfWork;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logic.ViewModels.Account;
using Logic.Infrastructure;
using Logic.Infrastructure.Interfaces;
using System.Security.Claims;
using AutoMapper;
using Data.Models;
using Microsoft.Owin.Security;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;

namespace Logic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;


        private static bool _firstRun = true;

        public AccountService(IUnitOfWork unitOfWork, IUserManager userManager, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
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
            // TODO

            _unitOfWork.EmployeesRepository.Create(model);
            _unitOfWork.EmployeesRepository.Save();

            return true;
        }

        /// <summary>
        /// Wyszukuje użytkownika po jego loginie
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<EditProfileViewModel> EditProfileAsync(string login)
        {
            var user = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(login);
            var viewModel = _mapper.Map<EditProfileViewModel>(user);
            return viewModel;
        }

        /// <summary>
        /// Dokonuje edycji i zapisu danych użytkownika
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<EditProfileViewModel> EditProfileAsync(EditProfileViewModel model, string login)
        {
            var user = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(login);

            // Aktualizacja danych użytkownika
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;
            user.EmailAddress = model.EmailAddress;

            try
            {
                _unitOfWork.EmployeesRepository.Update(user);
                var userEdited = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(login);
                var result = _mapper.Map<EditProfileViewModel>(userEdited);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Dokonuje walidacji aktualnego hasła i zmienia na nowe hasło
        /// </summary>
        /// <param name="model">Model do zmiany hasła</param>
        /// <param name="login">Login zalogowanego użytkownika</param>
        /// <returns></returns>
        public async Task<ChangePasswordViewModel> ChangePasswordAsync(ChangePasswordViewModel model, string login)
        {
            var user = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(login);

            var mathingPasswords = _passwordHasher.Check(user.Password, model.OldPassword);

            // Jeśli stare hasło jest prawidłowe
            if (mathingPasswords.Verified)
            {
                user.Password = model.NewPassword;
                try
                {
                    _unitOfWork.EmployeesRepository.Update(user);
                    var userEdited = _mapper.Map<ChangePasswordViewModel>(user);
                    return userEdited;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else return null; // Jesli stare hasło jest nieprawidłowe

        }

        /// <summary>
        /// Dokonuje wysłania linku do resetu hasła użytkownika
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                var user = _unitOfWork.EmployeesRepository.GetAll().Where(c => c.EmailAddress == model.Email).Single();

                if (user != null)
                {
                    // Generowanie kodu - tymczasowego hasła
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[16];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var code = new String(stringChars);

                    //Multiple Parameters
                    var queryParams = new Dictionary<string, string>()
                {
                    {"userId", user.Id.ToString() },
                    {"code", code }
                };
                    var callbackUrl = QueryHelpers.AddQueryString(LogicConstants.Home + "/Account/ResetPassword", queryParams);

                    await _userManager.SendEmailAsync(user.Id, "Reset hasła",
                        "Zresetuj hasło, klikając <a href=\"" + callbackUrl + "\">tutaj</a>");

                    // dodać podmiane hasła na tymczasowe i aktualizacje rekordu użytkownika
                    user.Password = code;
                    try
                    {
                        _unitOfWork.EmployeesRepository.Update(user);
                        var userEdited = _mapper.Map<ChangePasswordViewModel>(user);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else // Nie pokazuj, że użytkownika nie ma w bazie
                {
                    return false;
                }
            }
            catch (Exception) { return false; }

            }
        }
    }
