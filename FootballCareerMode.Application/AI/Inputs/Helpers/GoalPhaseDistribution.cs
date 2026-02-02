using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI.Inputs.Helpers
{
    public sealed class GoalPhaseDistribution
    {
        public int EarlyGame { get; init; } 
        public int MidGame { get; init; }
        public int LateGame { get; init; }
    }
}
