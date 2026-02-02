using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI.Generators
{
    public interface ISeasonNarrativeGenerator
    {
        Task<string> GenerateAsync(string input);
    }
}
