using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Core.Repositories;
using Application.Core.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using ERP.Infrastructure.Services;

namespace Infrastructure.DependencyResolver
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ErpDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:ERPDb",
                x => x.MigrationsAssembly("DbMigrations")));

            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<ErpDbContext>>();
            using (var dbContext = new ErpDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}