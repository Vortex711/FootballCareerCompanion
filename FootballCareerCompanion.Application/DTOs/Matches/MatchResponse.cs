using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.DTOs.Matches
{
    public class MatchResponse
    {
        public Guid Id { get; init; }
        public string ClubName { get; init; } = null!;
        public string CompetitionName { get; init; } = null!;
        public string OpponentName { get; init; } = null!;
        public bool IsHome { get; init; }
        public int TeamGoals { get; init; }
        public int OpponentGoals { get; init; }
        public int? LeaguePositionBefore { get; init; }
        public int? LeaguePositionAfter { get; init; }
        public DateTime PlayedAt { get; init; }
    }
}
