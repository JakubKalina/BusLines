using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Logic.Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using Logic.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;


using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNet.Identity;

namespace BusLines.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly Logic.Infrastructure.Interfaces.IPasswordHasher _passwordHasher;

        public AccountController(IAccountService accountService, Logic.Infrastructure.Interfaces.IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Zwraca widok logowania
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// Przeprowadza akcję logowania użytkownika
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel model, string returnUrl = null)
        {
            // Jeśeli stan modelu się nie zgadza
            if (!ModelState.IsValid) return View(model);

            var principal = await _accountService.LoginAsync(model);

            if (principal == null)
            {
                //return RedirectToPage(returnUrl);
                ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło.");
                return View(model);           
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return View("Register");
        }

        /// <summary>
        /// Zwraca widok przywracania hasła
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// Zwraca widok rejestracji pracownika
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Przeprowadza akcję rejestracji użytkownika
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Hashowanie hasła użytkownika
            model.Password = _passwordHasher.Hash(model.Password);

            var result = await  _accountService.RegisterAsync(model);
            

         

            //Testowy powrót
            return View("Login");

            /*
            if (result == true)
            {
                return RedirectToAction("Register", "Account");//wyświetlić komunikat, że się udało
            }
            else
            {
                // Wyświetlenie informacji o nieprawidłowych danych
                ModelState.AddModelError("", "Wprowadzono nieprawidłowe dane.");

                return View(model);
            }
            */
        }


        /// <summary>
        ///     Wylogowuje użytkownika i przenosi go na ekran logowania.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View("Login");
        }



    }
}