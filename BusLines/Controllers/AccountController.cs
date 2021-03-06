﻿using System;
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
using BusLines.Utilities;
using Logic.Infrastructure;

namespace BusLines.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AccountController(IAccountService accountService, IPasswordHasher passwordHasher)
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
            //Jeśli stan modelu się nie zgadza
            if (!ModelState.IsValid) return View(model);

            var principal = await _accountService.LoginAsync(model);

            if (principal == null)
            {
                ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło.");
                return View(model);
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Zwraca widok rejestracji pracownika
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Hashowanie hasła użytkownika
            model.Password = _passwordHasher.Hash(model.Password);

            var result = await  _accountService.RegisterAsync(model);
                  
            if(result == null)
            {
                return RedirectToAction("Login");//wyświetlić komunikat, że się udało
            }
            else
            {
                //Wyświetlenie informacji o nieprawidłowych danych
                ModelState.AddModelError("", result);

                return View(model);
            }
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
            return RedirectToAction("Login");
        }


        /// <summary>
        ///     Bierze obecnie zalogowanego użytkownika i wypełnia jego danymi formularz
        ///     do edycji danych, który następnie zwraca do użytkownika.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            // Wyszukanie loginu aktualnie zalogowanego użytkownika
            var userLogin = HttpContext.User.Identity.Name;
            var model = await _accountService.EditProfileAsync(userLogin);
            return View(model);
        }

        /// <summary>
        ///     Wysyła polecenie edycji profilu użytkownika i nadpisanie edytowanych pól użytkownika (np. imię).
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Wyszukanie loginu aktualnie zalogowanego użytkownika
            var userLogin = HttpContext.User.Identity.Name;

            var user = await _accountService.EditProfileAsync(model, userLogin);

            // Jeśli nie udało się zapisać zmian
            if(user == null)
            {
                ModelState.AddModelError("", "Wystąpił błąd podczas zapisu");
            }
            else
            {
                ViewBag.Message = "Profil został zaktualizowany";
            }

            return View(model);
        }

        /// <summary>
        ///     Zwraca formularz do zmiany hasła.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        ///     Wysyła polecenie serwisowi aby ten zmienił hasło dla obecnie zalogowanego użytkownika.
        ///     Użytkownik po zmianie hasła jest wylogowywany i proszony o ponowne zalogowanie z użyciem nowego hasła.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Wyszukanie loginu aktualnie zalogowanego użytkownika
            var userLogin = HttpContext.User.Identity.Name;

            // Hashowanie hasła użytkownika
            model.NewPassword = _passwordHasher.Hash(model.NewPassword);
            model.ConfirmPassword = _passwordHasher.Hash(model.ConfirmPassword);

            var result = await _accountService.ChangePasswordAsync(model, userLogin);

            // dodać komunikat że haslo zostało zmienione
            // TODO

            if (result != null)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Login");
            }

            // Jeśli podano nieprawidłowe stare hasło to wyświetl komunikat
            ModelState.AddModelError("", "Podane obecne hasło jest nieprawidłowe");

            return View(model);
        }

        /// <summary>
        ///     Widok dla przypomnienia hasła, w którym użytkownik wprowadza adres email,
        ///     na który ma zostać wysłany link do resetowania hasła.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        ///     Wysyła polecenie, by sprawdzić czy użytkownik potwierdził email.
        ///     Jeśli potwierdził, to wysyła na adres email link do zresetowania hasła.
        ///     Jeśli nie potwierdził, to wysyłany jest nowy link aktywacyjny na email.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            LogicConstants.Home = $"{this.Request.Scheme}://{this.Request.Host.Value.ToString()}{this.Request.PathBase.Value.ToString()}";

            var result = await _accountService.ForgotPassword(model);

            return RedirectToAction("ForgotPasswordConfirmation", "Account");
        }

        /// <summary>
        ///     Widok potwierdzający zmianę hasła - informuje
        ///     użytkownika, by udał się na swoją skrzynkę mailową
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        /// <summary>
        ///     Widok potwierdzający zresetowanie hasła.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

    }
}


// Gdy użytkownik zapomni hasła, to jego hasło jest zmieniane na hash i wysyłane na podany adres email
// Loguje się za pomocą hashu i wtedy ma możliwość zmiany hasła dopiero w aplikacji po zalogowaniu