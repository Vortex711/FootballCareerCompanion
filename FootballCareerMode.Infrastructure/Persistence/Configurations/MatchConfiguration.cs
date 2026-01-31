using FootballCareerMode.Domain.Matches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Infrastructure.Persistence.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.CompetitionName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.OpponentGoals)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(m => new
            {
                m.SeasonId,
                m.CompetitionName,
                m.OpponentName,
                m.PlayedAt
            }).IsUnique();

            builder.HasMany(m => m.Events)
                .WithOne()
                .HasForeignKey(e => e.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
