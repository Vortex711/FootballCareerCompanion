using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballCareerCompanion.Domain.Seasons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballCareerCompanion.Infrastructure.Persistence.Configurations
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Career)
               .WithMany(c => c.Seasons)
               .HasForeignKey(s => s.CareerId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
