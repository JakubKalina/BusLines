using Data.UnitOfWork;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    class AccountService : Service, IAccountService, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        private static bool _firstRun = true;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string UpdateDatabase(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateDatabaseAsync(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        string Lol()
        {
            return "LOL";
        }
    }
}
