using AutoMapper;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Model;
using EwaveLivraria.Services.Abstract;
using EwaveLivraria.Services.FluentValidator;
using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Concrete
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IInstitutionRepository _institutionRepository;
        private readonly IMapper _mapper;

        public InstitutionService(IInstitutionRepository institutionRepository, IMapper mapper)
        {
            _institutionRepository = institutionRepository;
            _mapper = mapper;
        }

        public async Task<ReturnModel> CreateInstitution(InstitutionRequest request)
        {
            var institutionValidator = new InstitutionValidator().Validate(request);
            if (!institutionValidator.IsValid)
                return new ReturnModel { Errors = institutionValidator.Errors };

            var institution = await _institutionRepository.GetByCnpj(request.Cnpj);
            if (institution != null)
                return new ReturnModel { Errors = "CNPJ já utilizado por outra Instituição" };

            institution = _mapper.Map<Institution>(request);
            institution.RegisteredAt = DateTime.Now;
            institution.IsActive = true;

            var result = await _institutionRepository.Insert(institution);

            return new ReturnModel { Data = _mapper.Map<InstitutionModel>(result) };
        }

        public async Task<ReturnModel> UpdateInstitution(InstitutionRequest request)
        {
            var institutionValidator = new InstitutionValidator().Validate(request);
            if (!institutionValidator.IsValid)
                return new ReturnModel { Errors = institutionValidator.Errors };

            var institution = await _institutionRepository.GetByCnpj(request.Cnpj);
            if(institution == null)
                return new ReturnModel { Errors = "Instituição Inválida" };

            institution.Name = request.Name;

            var result = await _institutionRepository.Update(institution);

            return new ReturnModel { Data = _mapper.Map<InstitutionModel>(result) };

        }

        public async Task<ReturnModel> BlockInstitution(int id)
        {
            var institution = await _institutionRepository.GetById(id);
            institution.IsActive = false;

            var result = await _institutionRepository.Update(institution);

            return new ReturnModel { Data = _mapper.Map<InstitutionModel>(result) };
        }

        public async Task<ReturnModel> GetAllInstitutions()
        {
            var institution = await _institutionRepository.GetAll();

            return new ReturnModel { Data = _mapper.Map<List<InstitutionModel>>(institution) };
        }

        public async Task<ReturnModel> GetInstitution(int id)
        {
            var institution = await _institutionRepository.GetById(id);

            return new ReturnModel { Data = _mapper.Map<InstitutionModel>(institution) };
        }
    }
}
