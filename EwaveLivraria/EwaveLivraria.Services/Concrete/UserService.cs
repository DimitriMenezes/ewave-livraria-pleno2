﻿using AutoMapper;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Model;
using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.FluentValidator;
using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IInstitutionRepository _institutionRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IInstitutionRepository institutionRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _institutionRepository = institutionRepository;
            _mapper = mapper;
        }

        public async Task<ReturnModel> CreateUser(UserRequest request)
        {
            var userValidator = new UserValidator().Validate(request);
            if (!userValidator.IsValid)            
                return new ReturnModel { Errors = userValidator.Errors };          

            var institution = await _institutionRepository.GetById(request.InstitutionId);
            if (!institution.IsActive) 
                return new ReturnModel { Errors = "Instituição Inativa." };

            var user = await _userRepository.GetByCpf(request.Cpf);
            if (user != null)
                return new ReturnModel { Errors = "CPF já utilizado por outro Usuário" };

            user = _mapper.Map<User>(request);
            user.RegisteredAt = DateTime.Now;
            user.IsActive = true;
            user.Password = PasswordService.GeneratePassword(user.Password);

            var result = await _userRepository.Insert(user);

            return new ReturnModel { Data = _mapper.Map<UserModel>(result) };
        }

        public async Task<ReturnModel> UpdateUser(UserRequest request)
        {
            var userValidator = new UserValidator().Validate(request);
            if (!userValidator.IsValid)
                return new ReturnModel { Errors = userValidator.Errors };

            var institution = await _institutionRepository.GetById(request.InstitutionId);
            if (!institution.IsActive)
                return new ReturnModel { Errors = "Instituição Inativa." };

            var user = await _userRepository.GetByCpf(request.Cpf);
            if (user == null)
                return new ReturnModel { Errors = "Usuário não cadastrado" };

            var result = await UpdateEntity(user, request);

            return new ReturnModel { Data = _mapper.Map<UserModel>(result) };
        }

        public async Task<ReturnModel> GetUser(int id)
        {
            var result = await _userRepository.GetById(id);           

            return new ReturnModel { Data = _mapper.Map<UserModel>(result) };
        }

        public async Task<ReturnModel> GetAllUsers()
        {
            var result = await _userRepository.GetAll();
            return new ReturnModel { Data = _mapper.Map<List<UserModel>>(result) };
        }

        public async Task<ReturnModel> BlockUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
                return new ReturnModel { Errors = "Usuario Não Existe" };

            user.IsActive = false;
            user.BlockedUntil = DateTime.Now.AddDays(30);

            var result = await _userRepository.Update(user);
            return new ReturnModel { Data = _mapper.Map<UserModel>(result) };
        }

        private async Task<User> UpdateEntity(User entity, UserRequest newEntity)
        {
            if (entity.Name != newEntity.Name)
                entity.Name = newEntity.Name;
            if (entity.InstitutionId != newEntity.InstitutionId)
                entity.InstitutionId = newEntity.InstitutionId;
            if (entity.Password != PasswordService.GeneratePassword(newEntity.Password))
                entity.Password = PasswordService.GeneratePassword(newEntity.Password);
            if (entity.Phone != newEntity.Phone)
                entity.Phone = newEntity.Phone;
            if (entity.Email != entity.Email)
                entity.Email = entity.Email;

            return await _userRepository.Update(entity);
        }
    }
}
