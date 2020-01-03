using AutoMapper;
using Data.Models;
using Logic.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterViewModel, Employees>();
            CreateMap<Employees, UserRegisterViewModel>();
            CreateMap<UserLoginViewModel, Employees>();
            CreateMap<Employees, UserLoginViewModel>();
        }
    }
}
