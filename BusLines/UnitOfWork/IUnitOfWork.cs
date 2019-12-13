using BusLines.Models;
using BusLines.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusLines.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<BusStops> BusStopsRepository { get; }
        IGenericRepository<Employees> EmployeesRepository { get; }
        IGenericRepository<Lines> LinesRepository { get; }
        IGenericRepository<Rides> RidesRepository { get; }
        IGenericRepository<RouteSections> RouteSectionsRepository { get; }
        IGenericRepository<Shifts> ShiftsRepository { get; }
        IGenericRepository<Tickets> TicketsRepository { get; }
        IGenericRepository<Vehicles> VehiclesRepository { get; }
        IGenericRepository<VisitedBusStops> VisitedBusStopsRepository { get; }
        void Save();
    }
}
