using BLL.Interfaces;
using EFDAO;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DepencyResolver
{
    public class ServiceCollectionResolver
    {
        public void SetupServices(IServiceCollection services)
        {
            //IServiceCollection services = new ServiceCollection();
            
            services.AddScoped<IBLO, BLL.Library.LibraryBlo>();
            services.AddScoped<IDAO.IDAO, EFDAO.DAO>();
            services.AddIdentity<EUser, IdentityRole>()
                            .AddEntityFrameworkStores<EFDBContext>()
                            .AddDefaultTokenProviders();
            services.AddDbContext<EFDBContext>();

            // return services;
        }
    }
}