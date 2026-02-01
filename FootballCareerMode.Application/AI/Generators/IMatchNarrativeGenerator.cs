using FootballCareerMode.Application.AI.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI.Generators
{
    public interface IMatchNarrativeGenerator
    {
        Task<string> GenerateAsync(MatchNarrativeInput input);
    }
}
