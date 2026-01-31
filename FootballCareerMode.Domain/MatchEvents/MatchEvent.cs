using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.MatchEvents
{
    public class MatchEvent
    {
        public Guid Id { get; }
        public Guid MatchId { get; }
        public string PlayerName { get; }
        public int? Minute { get; }

    }
}
