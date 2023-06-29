using System.Security.Claims;

namespace Domain.Core.Services
{
    public interface IUserContext
    {
        public ClaimsPrincipal User { get; }

        public string GetCurrentEmployeeId();
        public string GetCurrentCompanyId();
    }
}