using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.AI.Inputs.Helpers
{
    public sealed class FormSnapshot
    {
        public int Matches { get; init; }

        public int Wins { get; init; }
        public int Draws { get; init; }
        public int Losses { get; init; }

        public int GoalsFor { get; init; }
        public int GoalsAgainst { get; init; }

    }
}
