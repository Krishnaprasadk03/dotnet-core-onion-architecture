using Domain.Entities;
using Domain.Core.Specifications;

namespace Domain.Specifications
{
    public static class UserSpecifications
    {
        public static BaseSpecification<Users> GetUserSpec(string Emailid,string Password)
        {
            return new BaseSpecification<Users>(x => x.Email == Emailid && x.PassWord == Password);
        }
    }
}
