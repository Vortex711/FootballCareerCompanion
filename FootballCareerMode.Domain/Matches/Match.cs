using FootballCareerMode.Domain.MatchEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.Matches
{
    public class Match
    {
        public Guid Id { get; }
        public Guid SeasonId { get; }
        public string CompetitionName { get; }
        public string OpponentName { get; }
        public bool IsHome { get; }
        public int TeamGoals { get; }
        public int OpponentGoals { get; }
        public DateTime PlayedAt { get; }
        public DateTime CreatedAt { get; }

        private readonly List<MatchEvent> _events = new();
        public IReadOnlyCollection<MatchEvent> Events => _events.AsReadOnly();

        public Match(
            Guid id,
            Guid seasonId,
            string competitionName,
            string opponentName,
            bool isHome,
            int teamGoals,
            int opponentGoals,
            DateTime playedAt,
            DateTime createdAt)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Match ID cannot be empty.");

            if (seasonId == Guid.Empty)
                throw new ArgumentException("Season ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(competitionName))
                throw new ArgumentException("Competition name is required.");

            if (string.IsNullOrWhiteSpace(opponentName))
                throw new ArgumentException("Opponent name is required.");

            if (teamGoals < 0 || opponentGoals < 0)
                throw new ArgumentException("Goals cannot be negative.");

            Id = id;
            SeasonId = seasonId;
            CompetitionName = competitionName;
            OpponentName = opponentName;
            IsHome = isHome;
            TeamGoals = teamGoals;
            OpponentGoals = opponentGoals;
            PlayedAt = playedAt;
            CreatedAt = createdAt;
        }
        public void AddGoalEvent(MatchEvent matchEvent)
        {
            if (matchEvent == null)
                throw new ArgumentNullException(nameof(matchEvent));

            if (_events.Count >= TeamGoals)
                throw new InvalidOperationException("Goal events exceed team goals.");

            _events.Add(matchEvent);
        }
    }
}
