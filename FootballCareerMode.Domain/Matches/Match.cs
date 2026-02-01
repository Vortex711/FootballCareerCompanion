using FootballCareerMode.Domain.MatchEvents;
using FootballCareerMode.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.Matches
{
    public class Match
    {
        public Guid Id { get; private set; }
        public Guid SeasonId { get; private set; }
        public Season Season { get; private set; } = null!;
        public string CompetitionName { get; private set; }
        public string OpponentName { get; private set; }
        public bool IsHome { get; private set; }
        public int TeamGoals { get; private set; }
        public int OpponentGoals { get; private set; }
        public DateTime PlayedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<MatchEvent> _events = new();
        public IReadOnlyCollection<MatchEvent> Events => _events.AsReadOnly();

        private Match() { }
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
