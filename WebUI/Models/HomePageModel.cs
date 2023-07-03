using Entities.DTOs;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class HomePageModel
    {
        public List<WorkListDto> WorkListDtos { get; set; }
        public CreateWorkDto CreateWorkDto { get; set; }

    }
}
