using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.DTOs.Seasons
{
    public class SeasonResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;

        public string BoardExpectation { get; init; } = null!;
        public int? LeaguePosition { get; init; }

        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }

    }
}
