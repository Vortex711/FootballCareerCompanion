using FootballCareerCompanion.Application.AI.Inputs.Enums;
using FootballCareerCompanion.Application.AI.Inputs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.AI.Inputs
{
    public sealed class SeasonNarrativeInput
    {
        public string ClubName { get; init; } = null!;
        public string SeasonName { get; init; } = null!;

        public SeasonInvocationType InvocationType { get; init; }
        public int MatchesPlayed { get; init; }

        public int Wins { get; init; }
        public int Draws { get; init; }
        public int Losses { get; init; }

        public int GoalsFor { get; init; }
        public int GoalsAgainst { get; init; }
        
        public int GoalDifference { get; init; }

        public int RecentFormMatchCount { get; init; }
        public FormSnapshot RecentForm { get; init; } = default!;
        public GoalPhaseDistribution GoalsScoredByPhase { get; init; } = default!;
        public IReadOnlyList<TopScorerSummary> TopScorers { get; init; } = Array.Empty<TopScorerSummary>();

        public VenueRecord Home { get; init; } = default!;
        public VenueRecord Away { get; init; } = default!;

        public NarrativeToneHint ToneHint { get; init; }

    }
}
