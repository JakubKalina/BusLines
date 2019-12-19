using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Services.Interfaces;
using Logic.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusLines.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
        public async Task<IActionResult> Login(UserLoginViewModel model, string returnUrl)
        {
            // Jeśeli stan modelu się nie zgadza
            if (!ModelState.IsValid) return View(model);

            // Hashowanie hasła użytkownika

            var loginResult = await _accountService.LoginAsync(model);

            if (loginResult == string.Empty) return RedirectToPage(returnUrl);

            ModelState.AddModelError("", loginResult);

            return View(model);
        }

    }
}