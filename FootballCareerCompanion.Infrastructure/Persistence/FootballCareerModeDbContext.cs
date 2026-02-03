using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballCareerCompanion.Domain.Careers;
using FootballCareerCompanion.Domain.Matches;
using FootballCareerCompanion.Domain.MatchEvents;
using FootballCareerCompanion.Domain.Narratives;
using FootballCareerCompanion.Domain.Seasons;
using Microsoft.EntityFrameworkCore;

namespace FootballCareerCompanion.Infrastructure.Persistence
{
    public class FootballCareerCompanionDbContext: DbContext
    {
        public FootballCareerCompanionDbContext(DbContextOptions<FootballCareerCompanionDbContext> options)
        : base(options) { }

        public DbSet<Career> Careers => Set<Career>();
        public DbSet<Season> Seasons => Set<Season>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<MatchEvent> MatchEvents => Set<MatchEvent>();
        public DbSet<NarrativeSnapshot> NarrativeSnapshots => Set<NarrativeSnapshot>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FootballCareerCompanionDbContext).Assembly);
        }
    }
}
