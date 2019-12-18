using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IService
    {
        /// <summary>
        /// Aktualizuje bazę danych, a w przypadku wyjątku zwraca wiadomość zwrotną
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        string UpdateDatabase(IUnitOfWork unitOfWork);

    }
}
