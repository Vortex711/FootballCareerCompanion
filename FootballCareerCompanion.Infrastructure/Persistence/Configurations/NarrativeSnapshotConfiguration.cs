using FootballCareerCompanion.Domain.Narratives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Infrastructure.Persistence.Configurations
{
    public class NarrativeSnapshotConfiguration : IEntityTypeConfiguration<NarrativeSnapshot>
    {
        public void Configure(EntityTypeBuilder<NarrativeSnapshot> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Type)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(n => n.Content)
                   .IsRequired();

            builder.Property(n => n.PromptVersion)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(n => n.ModelVersion)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(n => n.GeneratedAt)
                   .IsRequired();

            builder.HasIndex(n => n.MatchId);
            builder.HasIndex(n => n.SeasonId);
        }
    }
}
