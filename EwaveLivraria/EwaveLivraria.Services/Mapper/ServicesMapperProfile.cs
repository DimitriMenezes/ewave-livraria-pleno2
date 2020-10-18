using AutoMapper;
using EwaveLivraria.Domain.Model;
using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Mapper
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            ////Request to Entity           
            CreateMap<UserRequest, User>();
            CreateMap<AddressRequest, Address>();
            CreateMap<AdministratorRequest, Administrator>();
            CreateMap<InstitutionRequest, Institution>();

            //Entity to Result Model
            CreateMap<User, UserModel>();
            CreateMap<Address, AddressModel>();
            CreateMap<Administrator, AdministratorModel>();
            CreateMap<Institution, InstitutionModel>();
        }
    }
}
