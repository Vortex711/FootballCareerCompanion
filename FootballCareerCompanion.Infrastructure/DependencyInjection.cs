using FootballCareerCompanion.Infrastructure.Persistence;
using FootballCareerCompanion.Infrastructure.Repositories;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<FootballCareerCompanionDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<ICareerRepository, CareerRepository>();
            services.AddScoped<INarrativeSnapshotRepository, NarrativeSnapshotRepository>();

            return services;
        }
    }
}
