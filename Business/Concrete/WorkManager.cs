using AutoMapper;
using Business.Abstract;
using Core.Response;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WorkManager : IWorkService
    {
        private readonly IUoW<Work> _uoW;
        private readonly IWorkDal _workDal;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateWorkDto> _createWorkValidator;
        private readonly IValidator<UpdateWorkDto> _updateWorkValidator;
        public WorkManager(IUoW<Work> uoW, IWorkDal workDal, IMapper mapper, IValidator<CreateWorkDto> createWorkValidator, IValidator<UpdateWorkDto> updateWorkValidator)
        {
            _uoW = uoW;
            _workDal = workDal;
            _mapper = mapper;
            _createWorkValidator = createWorkValidator;
            _updateWorkValidator = updateWorkValidator;
        }

        public async Task<IResponse<CreateWorkDto>> Add(CreateWorkDto createWorkDto)
        {
            var validationResult = _createWorkValidator.Validate(createWorkDto);
            if (!validationResult.IsValid)
            {
                List<CustomeValidationError> errors = new();
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(new CustomeValidationError() { ErrorMessage = item.ErrorMessage, PropertyName = item.PropertyName });
                }

                return new Response<CreateWorkDto>(ResponseType.ValidationError, createWorkDto, errors);
            } 
            await _workDal.AddAsync(_mapper.Map<Work>(createWorkDto));
            await _uoW.SaveChangesAsync();
            return new Response<CreateWorkDto>(ResponseType.Success, createWorkDto);
        }

        public IResponse Delete(int id)
        {
            var work = _workDal.GetAsycn(id).Result;
            if (work != null)
            {
                _workDal.Delete(work);
                _uoW.SaveChanges();
                return new Response(ResponseType.Success);

            }
            return new Response(ResponseType.NotFound, "İlgili kayıt bulunamadı.");
        }

        public async Task<IResponse<WorkListDto>> GetWorkListDto(int id)
        {
            var data = _mapper.Map<WorkListDto>(await _workDal.GetAsycn(id));
            if (data != null)
            {

                return new Response<WorkListDto>(ResponseType.Success,data);
            }
            return new Response<WorkListDto>(ResponseType.NotFound, "İlgili kayıt bulunamadı.");
        }

        public async Task<IResponse<List<WorkListDto>>> GetWorkListDtos()
        {
            var data = _mapper.Map<List<WorkListDto>>(await _workDal.GetAllAsync());
            return new Response<List<WorkListDto>>(ResponseType.Success,data);
        }

        public IResponse<UpdateWorkDto> Update(UpdateWorkDto updateWorkDto)
        {
            var validationResult = _updateWorkValidator.Validate(updateWorkDto);
            if (!validationResult.IsValid)
            {
                List<CustomeValidationError> errors = new();
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(new CustomeValidationError() { ErrorMessage = item.ErrorMessage, PropertyName = item.PropertyName });
                }

                return new Response<UpdateWorkDto>(ResponseType.ValidationError, updateWorkDto,errors);

            }     
            _workDal.Update(_mapper.Map<Work>(updateWorkDto));
            _uoW.SaveChanges();
            return new Response<UpdateWorkDto>(ResponseType.Success,updateWorkDto);

        }
    }
}
