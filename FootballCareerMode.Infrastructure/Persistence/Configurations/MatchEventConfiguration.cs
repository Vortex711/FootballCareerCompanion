using FootballCareerMode.Domain.MatchEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Infrastructure.Persistence.Configurations
{
    public class MatchEventConfiguration : IEntityTypeConfiguration<MatchEvent>
    {
        public void Configure(EntityTypeBuilder<MatchEvent> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PlayerName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Minute);
        }
    }
}
