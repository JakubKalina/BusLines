using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BusStopsRepository : GenericRepository<BusStops>, IBusStopsRepository
    {
        public BusStopsRepository(LinieAutobusoweContext context) : base(context) {}

        /// <summary>
        /// Wyszukanie przystanku po nazwie
        /// </summary>
        /// <param name="name">Nazwa przystanku jest unikatowa</param>
        /// <returns></returns>
        public async Task<BusStops> GetBusStopByNameAsync(string name)
        {
            return await _context.Set<BusStops>().SingleOrDefaultAsync(c => c.Name == name );
        }
    }
}
