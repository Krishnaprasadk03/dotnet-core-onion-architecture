using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public partial class RefreshToken : AuditableEntity
{
    [Key]
    public string Id { get; set; } 

    public string Subject { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public DateTime IssuedUtc { get; set; }

    public DateTime ExpiresUtc { get; set; }

    public string ProtectedTicket { get; set; } = null!;

    public string FcmToken { get; set; } = null!;
}
