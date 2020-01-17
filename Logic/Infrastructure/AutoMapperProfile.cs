using AutoMapper;
using Data.Models;
using Logic.ViewModels.Account;
using Logic.ViewModels.Admin;
using Logic.ViewModels.Client;
using Logic.ViewModels.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Dla AccountController
            CreateMap<UserRegisterViewModel, Employees>();
            CreateMap<Employees, UserRegisterViewModel>();
            CreateMap<UserLoginViewModel, Employees>();
            CreateMap<Employees, UserLoginViewModel>();
            CreateMap<EditProfileViewModel, Employees>();
            CreateMap<Employees, EditProfileViewModel>();
            CreateMap<ChangePasswordViewModel, Employees>();
            CreateMap<Employees, ChangePasswordViewModel>();

            // Dla ClientController
            CreateMap<GetAllBusStopsViewModel, BusStops>();
            CreateMap<BusStops, GetAllBusStopsViewModel>();
            CreateMap<GetAllLinesViewModel, Lines>();
            CreateMap<Lines, GetAllLinesViewModel>();
            CreateMap<GetAllRidesViewModel, Rides>();
            CreateMap<Rides, GetAllRidesViewModel>();
            CreateMap<BusStopViewModel, BusStops>();
            CreateMap<BusStops, BusStopViewModel>();

            // Dla AdminController
            CreateMap<AddBusLineViewModel, Lines>();
            CreateMap<Lines, AddBusLineViewModel>();
            CreateMap<AddBusStopViewModel, BusStops>();
            CreateMap<BusStops, AddBusStopViewModel>();
            CreateMap<AddRideViewModel, Rides>();
            CreateMap<Rides, AddRideViewModel>();
            CreateMap<AddRouteSectionViewModel, RouteSections>();
            CreateMap<RouteSections, AddRouteSectionViewModel>();
            CreateMap<AddVehicleViewModel, Vehicles>();
            CreateMap<Vehicles, AddVehicleViewModel>();
            CreateMap<EditBusLineViewModel, Lines>();
            CreateMap<Lines, EditBusLineViewModel>();
            CreateMap<EditBusStopViewModel, BusStops>();
            CreateMap<BusStops, EditBusStopViewModel>();
            CreateMap<EditRideViewModel, Rides>();
            CreateMap<Rides, EditRideViewModel>();
            CreateMap<EditRouteSectionViewModel, RouteSections>();
            CreateMap<RouteSections, EditRouteSectionViewModel>();
            CreateMap<EditVehicleViewModel, Vehicles>();
            CreateMap<Vehicles, EditVehicleViewModel>();
            CreateMap<VehicleViewModel, Vehicles>();
            CreateMap<Vehicles, VehicleViewModel>();

            // Dla DriverController
            CreateMap<DriverShiftsViewModel, Shifts>();
            CreateMap<Shifts, DriverShiftsViewModel>();

        }
    }
}
