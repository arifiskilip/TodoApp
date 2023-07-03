using Core.Response;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDto>>> GetWorkListDtos();
        Task<IResponse<WorkListDto>> GetWorkListDto(int id);
        Task<IResponse<CreateWorkDto>> Add(CreateWorkDto createWorkDto);
        IResponse<UpdateWorkDto> Update(UpdateWorkDto updateWorkDto);
        IResponse Delete(int id);
    }
}
