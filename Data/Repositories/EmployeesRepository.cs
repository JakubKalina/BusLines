using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmployeesRepository : GenericRepository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(LinieAutobusoweContext context) : base(context) {}

        public async Task<Employees> GetUserByUsernameAsync(string username)
        {
            return await _context.Set<Employees>().SingleOrDefaultAsync(c => c.Login == username);
        }
    }
}
