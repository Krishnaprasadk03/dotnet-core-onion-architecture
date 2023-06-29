using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public partial class Users : AuditableEntity
{
    [Key]
    public string UserId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public string UserType { get; set; } = null!;

    public string GrpCompId { get; set; } = null!;

    public string CompId { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Phone1 { get; set; } = null!;

    public string Phone2 { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? IsActive { get; set; }
}
