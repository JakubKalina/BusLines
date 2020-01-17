using System.Collections.Generic;
using System.Threading.Tasks;
using Logic.ViewModels.Driver;

namespace Logic.Services.Interfaces
{
    public interface IDriverService
    {
        Task<List<DriverShiftsViewModel>> ShowDriverShitfs(string login);
    }
}