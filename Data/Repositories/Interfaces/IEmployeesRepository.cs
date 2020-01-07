using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IEmployeesRepository : IGenericRepository<Employees>
    {
        Task<Employees> GetUserByUsernameAsync(string username);
        Task<Employees> GetUserByEmailAddressAsync(string emailAddress);
    }
}
