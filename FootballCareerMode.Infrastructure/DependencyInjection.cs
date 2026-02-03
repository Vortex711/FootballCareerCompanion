using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Infrastructure.Persistence;
using FootballCareerMode.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<FootballCareerModeDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<ICareerRepository, CareerRepository>();
            services.AddScoped<INarrativeSnapshotRepository, NarrativeSnapshotRepository>();

            return services;
        }
    }
}
