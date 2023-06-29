using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Client : AuditableEntity
{
    [Key]
    public string Id { get; set; }

    public string Secret { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int ApplicationType { get; set; }

    public bool Active { get; set; }

    public int RefreshTokenLifeTime { get; set; }

    public string? AllowedOrigin { get; set; }
}
