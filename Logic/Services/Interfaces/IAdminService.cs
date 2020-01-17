using System.Collections.Generic;
using Logic.ViewModels.Admin;

namespace Logic.Services.Interfaces
{
    public interface IAdminService
    {
        List<VehicleViewModel> GetAllVehicles();
         void AddNewVehicle(AddVehicleViewModel model);
    }
}