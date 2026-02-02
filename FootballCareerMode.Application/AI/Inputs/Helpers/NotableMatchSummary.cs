using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI.Inputs.Helpers
{
    public sealed class NotableMatchSummary
    {
        public string OpponentName { get; init; } = null!;
        public bool IsHome { get; init; }

        public int TeamGoals { get; init; }
        public int OpponentGoals { get; init; }

        public string ContextLabel { get; init; } = null!;
    }
}
