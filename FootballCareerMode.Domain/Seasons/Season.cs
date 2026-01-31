using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.Seasons
{
    public class Season
    {
        public Guid Id { get; }
        public Guid CareerId { get; }
        public string Name { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public DateTime CreatedAt { get; }
    }
}
