using AutoMapper;
using Data.Models;
using Logic.ViewModels.Account;
using Logic.ViewModels.Client;
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
        }
    }
}
