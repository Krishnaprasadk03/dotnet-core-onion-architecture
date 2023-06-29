using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<TokenRes> LoginUser(TokenReq req);

       
    }
}