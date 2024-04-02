using ControleDeVistoria.Application.Interfaces;
using ControleDeVistoria.Application.Services;
using ControleDeVistoria.Domain.Interface;
using ControleDeVistoria.Infra.Data.IdentityData.Data;
using ControleDeVistoria.Infra.Data.Repository;
using ControleDeVistoria.Infra.IoC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VControleDeVistoria.Infra.Data.Context;

namespace ControleDeVistoria.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionSqlServer = configuration.GetConnectionString("DataBase");

            services.AddDbContext<VistoriaContext>(options => options.UseSqlServer(connectionSqlServer));
            services.AddDbContext<ControleDeVistoriaIdentityContext>(options => options.UseSqlServer(connectionSqlServer));
            services.AddDefaultIdentity<ControleDeVistoriaIdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ControleDeVistoriaIdentityContext>();

            services.AddScoped<IAmbienteRepositorio, AmbienteRepositorio>();
            services.AddScoped<IImovelRepositorio, ImovelRepositorio>();
            services.AddScoped<ILocatarioRepositorio, LocatarioRepositorio>();
            services.AddScoped<IVistoriadorRepositorio, VistoriadorRepositorio>();
            services.AddScoped<IVistoriaRepositorio, VistoriaRepositorio>();

            services.AddScoped<IAmbienteService, AmbienteService>();
            services.AddScoped<IImovelService, ImovelService>();
            services.AddScoped<ILocatarioService, LocatarioService>();
            services.AddScoped<IVistoriadorService, VistoriadorService>();
            services.AddScoped<IVistoriaService, VistoriaService>();

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
