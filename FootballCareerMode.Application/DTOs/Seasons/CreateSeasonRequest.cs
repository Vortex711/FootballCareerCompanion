using FootballCareerMode.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.DTOs.Seasons
{
    public class CreateSeasonRequest
    {
        public string Name { get; init; } = null!;
        public DateTime? StartDate { get; init; } 
        public BoardExpectation Expectation { get; init; }

    }
}
