using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.UnitOfWork;
using Logic.Services.Interfaces;
using Logic.ViewModels.Client;

namespace Logic.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Zwraca listę wszystkich przystanków autobusowych
        public List<GetAllBusStopsViewModel> GetAllBusStops()
        {
            var allBusStops = _unitOfWork.BusStopsRepository.GetAll();
            var allBusStopsViewModel = _mapper.Map<List<GetAllBusStopsViewModel>>(allBusStops);
            return allBusStopsViewModel;
        }

        // Zwraca listę wszystkich linii
        public List<GetAllLinesViewModel> GetAllLines()
        {
            var allLines = _unitOfWork.LinesRepository.GetAll();
            var allLinesViewModel = _mapper.Map<List<GetAllLinesViewModel>>(allLines);
            return allLinesViewModel;
        }

        // Zwraca listę wszystkich zaplanowanych przejazdów
        public List<GetAllRidesViewModel> GetAllRides()
        {
            var allRides = _unitOfWork.RidesRepository.GetAll();
            var allRidesViewModel = _mapper.Map<List<GetAllRidesViewModel>>(allRides);
            return allRidesViewModel;
        }
    }
}