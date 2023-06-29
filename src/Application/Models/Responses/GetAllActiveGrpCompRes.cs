using Application.Models.DTOs;

namespace Application.Models.Responses
{
    public class GetAllActiveGrpCompRes
    {
        public IList<GrpCompanyDTOs> Data { get; set; }
    }
}
