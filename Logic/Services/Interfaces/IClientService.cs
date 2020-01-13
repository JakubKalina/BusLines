using System.Collections.Generic;
using System.Threading.Tasks;
using Logic.ViewModels.Client;

namespace Logic.Services.Interfaces
{
    public interface IClientService
    {
         List<GetAllBusStopsViewModel> GetAllBusStops();
         List<GetAllLinesViewModel> GetAllLines();
         List<GetAllRidesViewModel> GetAllRides();
         Task<FoundRidesViewModel> FindRide(FindRideViewModel model);
    }
}