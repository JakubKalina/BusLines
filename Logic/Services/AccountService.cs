using Data.UnitOfWork;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    public class AccountService : Service, IAccountService, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;

        private static bool _firstRun = true;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string UpdateDatabase(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

    }
}
