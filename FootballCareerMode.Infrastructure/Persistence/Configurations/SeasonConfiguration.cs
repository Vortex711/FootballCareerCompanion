using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballCareerMode.Domain.Seasons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballCareerMode.Infrastructure.Persistence.Configurations
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Matches)
                .WithOne()
                .HasForeignKey(m => m.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
