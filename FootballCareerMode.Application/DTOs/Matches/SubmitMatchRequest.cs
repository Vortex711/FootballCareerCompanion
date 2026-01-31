using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.DTOs.Matches
{
    public class SubmitMatchRequest
    {
        public Guid SeasonId { get; init; }
        public string CompetitionName { get; init; } = null!;
        public string OpponentName { get; init; } = null!;
        public bool IsHome { get; init; }
        public int TeamGoals { get; init; }
        public int OpponentGoals { get; init; }
        public DateTime PlayedAt { get; init; } 

        public List<GoalEventRequest>? GoalEvents { get; init; }

    }

    public class GoalEventRequest
    {
        public string PlayerName { get; init; } = null!;
        public int? Minute { get; init; }
    }
}
