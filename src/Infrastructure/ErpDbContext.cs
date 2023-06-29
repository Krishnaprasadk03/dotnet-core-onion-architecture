using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities; 
namespace Infrastructure
{ 
  public partial class ErpDbContext : DbContext
{

    public ErpDbContext(DbContextOptions<ErpDbContext> options)
        : base(options)
    {
            this.ChangeTracker.LazyLoadingEnabled = false;
    }
        public DbSet<Users> Users { get; set; }
        public DbSet<Client> ClientMaster { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



    }
}
