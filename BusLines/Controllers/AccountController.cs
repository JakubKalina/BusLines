using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Services.Interfaces;
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



    }
}