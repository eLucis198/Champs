using Champs.Domain.Interfaces;
using Champs.Infra.Data.Context;
using Champs.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Champs.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IChampionRepository, ChampionRepository>();
            services.AddScoped<IStatRepository, StatRepository>();
            services.AddScoped<ISpellRepository, SpellRepository>();

            return services;
        }
    }
}