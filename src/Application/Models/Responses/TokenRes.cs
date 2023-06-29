using System.ComponentModel.DataAnnotations;


namespace Application.Models.Requests
{
    public class TokenRes
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string? UserName { get; set; }
        public string? GrpComp { get; set; }
        public string? Comp { get; set; }
        public string? UserId { get; set; }

    }
}
