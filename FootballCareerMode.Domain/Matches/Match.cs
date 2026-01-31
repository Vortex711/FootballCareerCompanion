using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.Matches
{
    public class Match
    {
        public Guid Id { get; }
        public Guid SeasonId { get; }
        public string CompetitionName { get; }
        public string OpponentName { get; }
        public bool IsHome { get; }
        public int TeamGoals { get; }
        public int OpponentGoals { get; }
        public DateTime PlayedAt { get; }
        public DateTime CreatedAt { get; }

    }
}
