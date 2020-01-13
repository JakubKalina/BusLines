using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IBusStopsRepository : IGenericRepository<BusStops>
    {
        Task<BusStops> GetBusStopByNameAsync(string name);
    }
}
