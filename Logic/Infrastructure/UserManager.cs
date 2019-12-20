using Data.UnitOfWork;
using Logic.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Infrastructure
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            var result = await UserIsValid(username, password);
            return result;
        }

        public async Task<bool> UserIsValid(string username, string password)
        {
            var user = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(username);
            if(user == null)
            {
                return false;
            }
            if (user.Login == username && user.Password == password)
            {
                return true;
            }
            else return false;
        }

    }
}
