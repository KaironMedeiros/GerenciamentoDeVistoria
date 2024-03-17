using ControleDeVistoria.Infra.Data.IdentityData.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVistoria.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionSqlServer = configuration.GetConnectionString("DataBase");
            
            services.AddDbContext<ControleDeVistoriaIdentityContext>(options => options.UseSqlServer(connectionSqlServer));
            services.AddDefaultIdentity<ControleDeVistoriaIdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ControleDeVistoriaIdentityContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            });
            
            return services;
        }
    }
}
