using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    class Service
    {
        public string UpdateDatabase(IUnitOfWork unitOfWork)
        {

            try
            {
                unitOfWork.Complete();
            }
            catch
            {
                return "Błąd podczas aktualizacji bazy!";
            }
            return string.Empty;
        }


        public async Task<string> UpdateDatabaseAsync(IUnitOfWork unitOfWork)
        {

            try
            {
                await unitOfWork.CompleteAsync();
            }
            catch
            {
                return "Błąd podczas aktualizacji bazy!";
            }
            return string.Empty;
        }
    }
}
