using FootballCareerCompanion.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.AI.Inputs
{
    public class MatchNarrativeInput
    {
        public string CompetitionName { get; init; } = null!;
        public string TeamManagerName { get; init; } = null!;
        public string TeamName { get; init; } = null!;
        public string OpponentName { get; init; } = null!;
        public bool IsHome { get; init; }

        public int TeamGoals { get; init; }
        public int OpponentGoals { get; init; }

        public int? LeaguePositionAfter { get; init; }
        public int? LeaguePositionBefore { get; init; }

        public BoardExpectation Expectation { get; init; } 

        public DateTime PlayedAt { get; init; }

        public IReadOnlyList<HeadToHeadResult> RecentHeadToHeadResults { get; init; }
            = new List<HeadToHeadResult>();

        public IReadOnlyList<GoalEvent> GoalEvents { get; init; } = new List<GoalEvent>();
        public string RecentForm { get; init; } = null!;
    }
}

public class HeadToHeadResult
{
    public DateTime PlayedAt { get; init; }
    public string CompetitionName { get; init; } = null!;
    public int TeamGoals { get; init; }
    public int OpponentGoals { get; init; }

    public string Result =>
        TeamGoals > OpponentGoals ? "Win" :
        TeamGoals < OpponentGoals ? "Loss" :
        "Draw";
}

public class GoalEvent
{
    public string Scorer { get; init; } = null!;
    public int? Minute { get; init; }
}
