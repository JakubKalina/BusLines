using Data.Models;
using Data.Repositories;
using Data.Repositories.Interfaces;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LinieAutobusoweContext _context;
        private GenericRepository<BusStops> _busStopsRepository;
        private GenericRepository<Employees> _employeesRepository;
        private GenericRepository<Lines> _linesRepository;
        private GenericRepository<Rides> _ridesRepository;
        private GenericRepository<RouteSections> _routeSectionsRepository;
        private GenericRepository<Shifts> _shiftsRepository;
        private GenericRepository<Tickets> _ticketsRepository;
        private GenericRepository<Vehicles> _vehiclesRepository;
        private GenericRepository<VisitedBusStops> _visitesBusStopsRepository;

        public UnitOfWork(LinieAutobusoweContext context)
        {
            _context = context;
        }

        public IGenericRepository<BusStops> BusStopsRepository =>
            _busStopsRepository ?? (_busStopsRepository = new GenericRepository<BusStops>(_context));

        public IGenericRepository<Employees> EmployeesRepository =>
            _employeesRepository ?? (_employeesRepository = new GenericRepository<Employees>(_context));

        public IGenericRepository<Lines> LinesRepository =>
            _linesRepository ?? (_linesRepository = new GenericRepository<Lines>(_context));

        public IGenericRepository<Rides> RidesRepository =>
            _ridesRepository ?? (_ridesRepository = new GenericRepository<Rides>(_context));

        public IGenericRepository<RouteSections> RouteSectionsRepository =>
            _routeSectionsRepository ?? (_routeSectionsRepository = new GenericRepository<RouteSections>(_context));

        public IGenericRepository<Shifts> ShiftsRepository =>
            _shiftsRepository ?? (_shiftsRepository = new GenericRepository<Shifts>(_context));

        public IGenericRepository<Tickets> TicketsRepository =>
            _ticketsRepository ?? (_ticketsRepository = new GenericRepository<Tickets>(_context));

        public IGenericRepository<Vehicles> VehiclesRepository =>
            _vehiclesRepository ?? (_vehiclesRepository = new GenericRepository<Vehicles>(_context));

        public IGenericRepository<VisitedBusStops> VisitedBusStopsRepository =>
            _visitesBusStopsRepository ?? (_visitesBusStopsRepository = new GenericRepository<VisitedBusStops>(_context));

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
