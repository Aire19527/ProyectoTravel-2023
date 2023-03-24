using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.DependencyInjection;
using Travel.Domain.Services.Security;
using Travel.Domain.Services.Security.Interfaces;
using Travel.Domain.Services.Travel;
using Travel.Domain.Services.Travel.Interface;

namespace Travel.Web.Handlers
{
    public class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            // Repository await UnitofWork parameter ctor explicit
            services.AddScoped<UnitOfWork, UnitOfWork>();

            // Infrastructure
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<SeedDb>();

            //Domain
            services.AddTransient<IAutorServices, AutorServices>();
            services.AddTransient<IBookServices, BookServices>();
            services.AddTransient<IEditorialServices, EditorialServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IPermissionServices, PermissionServices>();
        }
    }
}
