using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<FoundRidesViewModel> FindRide(FindRideViewModel model)
        {
            var initialBusStop = await _unitOfWork.BusStopsRepository.GetBusStopByNameAsync(model.InitialBusStop);
            var finalBusStop = await _unitOfWork.BusStopsRepository.GetBusStopByNameAsync(model.FinalBusStop);
            var allRides = _unitOfWork.RidesRepository.GetAll();

            // Jeśli nie odnaleziono takiego przystanku końcowego / początkowego
            if (initialBusStop == null || finalBusStop == null) return null;

            
            FoundRidesViewModel result = new FoundRidesViewModel()
            {
                InitialBusStop = _mapper.Map<BusStopViewModel>(initialBusStop),
                FinalBusStop = _mapper.Map<BusStopViewModel>(finalBusStop),
                RideTimeFrom = model.RideTimeFrom
            };

            foreach (var ride in allRides)
            {
                // Sprawdzenie czy przejazd rozpoczyna się po podanej dacie i czasie
                if(ride.StartingDate > model.RideTimeFrom)
                {
                    var lineId = ride.LineId;

                    // Wyszystkie odcinki tras dla danej linii
                    var routeSections = _unitOfWork.RouteSectionsRepository.GetAll().Where(c => c.LineId == lineId).OrderBy(o => o.RecordNumber).ToList();

                    var initialBusStopSection = routeSections.Where(c => c.BusStopId == initialBusStop.Id).Single();
                    var finalBusStopSection = routeSections.Where(c => c.BusStopId == finalBusStop.Id).Single();

                    // Jeśli istnieją obie sekcje
                    if(initialBusStopSection != null && finalBusStopSection != null)
                    {
                        RideViewModel rideViewModel = new RideViewModel();
                        // Wyliczenie dostępnych miejsc
                        var vehicle = _unitOfWork.VehiclesRepository.GetById(ride.VehicleId);
                        rideViewModel.AvailableSeats = (vehicle.NumberOfSeats - ride.OccupiedSeats);

                        // Pętla po wszystkich odcinkach trasy
                        foreach(var section in routeSections)
                        {
                            rideViewModel.FinalDistance += section.Distance;
                            rideViewModel.FinalPrice += section.Price;
                            rideViewModel.FinalTime += section.Time;
                        }
                        
                        // Mocno przetestować w domu !
                        // TODO:
                        // DOdąć kilka przykłądowych przejazdów i je potestować czy to wszystko ładnie chodzi jak należy

                        result.Rides.Add(rideViewModel);
                    }


                }
            }

            if (result.Rides.Count() == 0) return null;
            else return result;
        }
    }
}