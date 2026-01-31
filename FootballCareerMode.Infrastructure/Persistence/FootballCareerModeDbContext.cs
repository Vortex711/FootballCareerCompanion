using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballCareerMode.Domain.Careers;
using FootballCareerMode.Domain.Matches;
using FootballCareerMode.Domain.MatchEvents;
using FootballCareerMode.Domain.Narratives;
using FootballCareerMode.Domain.Seasons;
using Microsoft.EntityFrameworkCore;

namespace FootballCareerMode.Infrastructure.Persistence
{
    public class FootballCareerModeDbContext: DbContext
    {
        public FootballCareerModeDbContext(DbContextOptions<FootballCareerModeDbContext> options)
        : base(options) { }

        public DbSet<Career> Careers => Set<Career>();
        public DbSet<Season> Seasons => Set<Season>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<MatchEvent> MatchEvents => Set<MatchEvent>();
        public DbSet<NarrativeSnapshot> NarrativeSnapshots => Set<NarrativeSnapshot>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FootballCareerModeDbContext).Assembly);
        }
    }
}
