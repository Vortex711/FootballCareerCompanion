using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.AI.Generators
{
    public class FakeSeasonNarrativeGenerator : ISeasonNarrativeGenerator
    {
        public Task<string> GenerateAsync(string prompt)
        {
            var fakeResponse =
                "SEASON SUMMARY (FAKE AI)\n\n" +
                "This is a placeholder season narrative generated using the provided prompt.\n\n" +
                "Prompt received:\n" +
                prompt;

            return Task.FromResult(fakeResponse);
        }
    }
}
