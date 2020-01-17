using System.Collections.Generic;
using AutoMapper;
using Data.Models;
using Data.UnitOfWork;
using Logic.Services.Interfaces;
using Logic.ViewModels.Admin;

namespace Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<VehicleViewModel> GetAllVehicles()
        {
            var models = _unitOfWork.VehiclesRepository.GetAll();
            var viewModels = _mapper.Map<List<VehicleViewModel>>(models);
            return viewModels;
        }


        public void AddNewVehicle(AddVehicleViewModel model)
        {
            Vehicles newVehicle = new Vehicles() {
                YearOfProduction = model.YearOfProduction,
                NumberOfSeats = model.NumberOfSeats,
                RegistrationNumber = model.RegistrationNumber
            };
            _unitOfWork.VehiclesRepository.Create(newVehicle);
            _unitOfWork.VehiclesRepository.Save();
        }
    }
}