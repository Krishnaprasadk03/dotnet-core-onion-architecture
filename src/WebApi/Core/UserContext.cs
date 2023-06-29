using System.Security.Claims;
using Domain.Core.Services;
using Infrastructure.Services;

namespace WebApi.Core
{
    public class UserContext : IUserContext
    {
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            User = httpContextAccessor.HttpContext.User;
        }

        public ClaimsPrincipal User { get; }

        public string GetCurrentUserId()
        {
            return (User.Claims.First(x => x.Type == "usrid").Value);
        }
        public string GetCurrentCompanyId()
        {
            return (User.Claims.First(x => x.Type == "compid").Value);
        }

        public string GetCurrentEmployeeId()
        {
            return (User.Claims.First(x => x.Type == "usrid").Value);
        }
    }
}