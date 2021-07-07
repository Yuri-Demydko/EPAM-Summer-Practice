using BLL.Interfaces;
using BLL.Logic;
using DAL.EF;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace DependencyResolver
{
    public class ServiceCollectionResolver
    {
        public void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IBooksBLO, BooksBLO>();
            services.AddScoped<DAL.Interfaces.IBooksDAO, BooksDAO>();
            services.AddScoped<DAL.Interfaces.IUsersDAO, UsersDAO>();
            services.AddScoped<DAL.Interfaces.ITechDAO, TechnicalDAO>();
            services.AddScoped<BLL.Interfaces.ITechBLO, TechBLO>();
            services.AddScoped<IUsersBLO, UsersBLO>();
            services.AddIdentity<EUser, IdentityRole>()
                            .AddEntityFrameworkStores<EFDBContext>()
                            .AddDefaultTokenProviders();
            services.AddDbContext<EFDBContext>();
        }
    }
}