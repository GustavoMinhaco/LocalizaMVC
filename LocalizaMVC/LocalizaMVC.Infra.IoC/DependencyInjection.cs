using LocalizaMVC.Application.Interfaces;
using LocalizaMVC.Application.Mappings;
using LocalizaMVC.Application.Services;
using LocalizaMVC.Domain.Interfaces;
using LocalizaMVC.Infra.Data.Context;
using LocalizaMVC.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Infra.IoC
{

    //Cross Cutting
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {

            /* - registrando o contexto ApplicationDbContext
             * - definindo o provedor do banco de dados
             * - definindo a string de conexão
             * - informando que a migração vai ficar na mesma pasta definido o arquivo de contexto, no Projeto Infra.Data
            */
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // registrando os repositórios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IOperadorRepository, OperadorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            // registrando os serviços
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IOperadorService, OperadorService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            // registrando AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // registrando o serviço do IMediator
            var myHandlers = AppDomain.CurrentDomain.Load("LocalizaMVC.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
