using Domain.Entities;

namespace Application.Models.DTOs
{
    public class GrpCompanyDTOs
    {
        public string GrpComp { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public GrpCompanyDTOs(Users usr)
        {
            GrpComp = usr.GrpCompId;
            UserName = usr.UserName;
            Email = usr.Email;
            Phone = usr.Phone1;
            Address = usr.Address;
                
        }
    }
}