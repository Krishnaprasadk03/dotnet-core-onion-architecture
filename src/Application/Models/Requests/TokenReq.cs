using System.ComponentModel.DataAnnotations;


namespace Application.Models.Requests
{
    public class TokenReq
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string ClientId { get; set; }


    }
}
