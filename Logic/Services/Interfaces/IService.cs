using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services.Interfaces
{
    interface IService
    {
        /// <summary>
        /// Aktualizuje bazę danych, a w przypadku wyjątku zwraca wiadomość zwrotną
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        string UpdateDatabase(IUnitOfWork unitOfWork);

        Task<string> UpdateDatabaseAsync(IUnitOfWork unitOfWork);
    }
}
