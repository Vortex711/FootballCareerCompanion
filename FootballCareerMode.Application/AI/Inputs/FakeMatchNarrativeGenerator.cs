using FootballCareerMode.Application.AI.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI.Inputs
{
     public class FakeMatchNarrativeGenerator : IMatchNarrativeGenerator
    {
        public Task<string> GenerateAsync(MatchNarrativeInput input)
        {
            var text = $"""
                 {input.CompetitionName}: {input.TeamGoals}-{input.OpponentGoals} vs {input.OpponentName} 
                A {input.Result.ToLower()} with a goal difference of {input.TeamGoals - input.OpponentGoals}. 
                Recent form coming into the match was {input.RecentForm}. 
                """; 
            return Task.FromResult(text);
        }
    }
}
