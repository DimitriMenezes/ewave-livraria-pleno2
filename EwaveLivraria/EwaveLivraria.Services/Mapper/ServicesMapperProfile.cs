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
            CreateMap<AddressRequest, Address>();
            CreateMap<AdministratorRequest, Administrator>();
            CreateMap<InstitutionRequest, Institution>();
            CreateMap<BookRequest, Book>();
            CreateMap<BookLoanRequest, BookLoan>();
            CreateMap<UserRequest, User>();

            //Entity to Result Model
            CreateMap<Address, AddressModel>();
            CreateMap<Administrator, AdministratorModel>();
            CreateMap<Book , BookModel>();
            CreateMap<BookLoan, BookLoanModel>();
            CreateMap<Institution, InstitutionModel>();
            CreateMap<User, UserModel>();
            
        }
    }
}
