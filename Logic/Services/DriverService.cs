using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.UnitOfWork;
using Logic.Services.Interfaces;
using Logic.ViewModels.Driver;

namespace Logic.Services
{
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Zwraca listę wszystkich zmian danego pracownika
        public async Task<List<DriverShiftsViewModel>> ShowDriverShitfs(string login)
        {
            var driver = await _unitOfWork.EmployeesRepository.GetUserByUsernameAsync(login);
            var driverShifts = _unitOfWork.ShiftsRepository.GetAll().Where(c => c.EmployeeId == driver.Id).ToList();
            var driverShiftsViewModels = _mapper.Map<List<DriverShiftsViewModel>>(driverShifts);
            return driverShiftsViewModels;
        }
    }
}