using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class Service
    {
        public string UpdateDatabase(IUnitOfWork unitOfWork)
        {

            try
            {
                unitOfWork.Save();
            }
            catch
            {
                return "Błąd podczas aktualizacji bazy!";
            }
            return string.Empty;
        }

    }
}
