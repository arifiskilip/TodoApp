using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Mappings.AutoMapper
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, CreateWorkDto>().ReverseMap();
            CreateMap<Work, UpdateWorkDto>().ReverseMap();
            CreateMap<Work, WorkListDto>().ReverseMap();
        }
    }
}
