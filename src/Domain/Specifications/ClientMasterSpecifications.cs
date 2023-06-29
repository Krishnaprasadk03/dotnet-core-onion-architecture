using Domain.Entities;
using Domain.Core.Specifications;

namespace Domain.Specifications
{
    public static class ClientMasterSpecifications
    {
        public static BaseSpecification<Client> GetClientMasterSpec(string clientid)
        {
            return new BaseSpecification<Client>(x => x.Id == clientid && x.Active==true);
        }
    }
}
