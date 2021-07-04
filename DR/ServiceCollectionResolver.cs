using BLL.Interfaces;
using DAO.Interfaces;
using DTO.Entities;
using EFDAO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DependencyResolver
{
    public class ServiceCollectionResolver
    {
        public void SetupServices(IServiceCollection services)
        {
            //IServiceCollection services = new ServiceCollection();
            
            services.AddScoped<IBLO, BLL.Library.LibraryBlo>();
            services.AddScoped<IDAO, EFDAO.DAO>();
            services.AddIdentity<EUser, IdentityRole>()
                            .AddEntityFrameworkStores<EFDBContext>()
                            .AddDefaultTokenProviders();
            services.AddDbContext<EFDBContext>();

            // return services;
        }
    }
}