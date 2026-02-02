using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI.Inputs.Helpers
{
    public sealed class TopScorerSummary
    {
        public string PlayerName { get; init; } = null!;
        public int Goals { get; init; }
    }
}
