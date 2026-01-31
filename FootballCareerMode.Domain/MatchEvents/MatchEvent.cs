using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.MatchEvents
{
    public class MatchEvent
    {
        public Guid Id { get; private set; }
        public Guid MatchId { get; private set; }
        public string PlayerName { get; private set; }
        public int? Minute { get; private set; }

        private MatchEvent() { }
        public MatchEvent(Guid id, Guid matchId, string playerName, int? minute)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("MatchEvent ID cannot be empty.");

            if (matchId == Guid.Empty)
                throw new ArgumentException("Match ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(playerName))
                throw new ArgumentException("Player name is required.");

            if (minute.HasValue && (minute < 0 || minute > 130))
                throw new ArgumentException("Invalid minute value.");

            Id = id;
            MatchId = matchId;
            PlayerName = playerName;
            Minute = minute;
        }

    }
}
