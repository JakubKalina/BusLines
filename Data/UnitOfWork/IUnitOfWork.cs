using Data.Models;
using Data.Repositories.Interfaces;
using System;


namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<BusStops> BusStopsRepository { get; }
        IEmployeesRepository EmployeesRepository { get; }
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
