using Application.Core.Services;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Infrastructure.Data
{
    public class DataInitializer
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DbContextOptions<ErpDbContext> _dbContextOptions;
        private readonly IEncryptionService _encryptionService;
        public DataInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _dbContextOptions = _serviceProvider.GetRequiredService<DbContextOptions<ErpDbContext>>();
            _encryptionService = _serviceProvider.GetRequiredService<IEncryptionService>();
        }

        public void Initialize()
        {
            using (var dbContext = new ErpDbContext(_dbContextOptions))
            {
                if (dbContext.Database.CanConnect())
                {
                    dbContext.Database.Migrate();
                    return;
                }

                dbContext.Database.Migrate();



                var SecretKey = Guid.NewGuid().ToString("n");
                dbContext.ClientMaster.Add(new Client 
                {
                   Id = "ErpWebTest",Secret= SecretKey,Name = "ErpWebTest",ApplicationType=1,Active =true,
                    RefreshTokenLifeTime=1440,AllowedOrigin ="*"   
                });
                dbContext.SaveChanges();
                var passwordhash = _encryptionService.CreatePasswordHash("12345", "kspn23");  
                dbContext.Users.Add(new Users { 
                UserId ="10100001001",UserName ="Admin",Address ="-",CompId="1001",GrpCompId="10100001",Email="test@admin.com",
                PassWord = passwordhash,Startdate =new DateTime(),Enddate =new DateTime().AddYears(1),IsActive=true,UserType="1"
                
                
                });  


            }
        }
    }
}
