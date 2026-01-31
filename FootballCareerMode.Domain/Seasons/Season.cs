using FootballCareerMode.Domain.Careers;
using FootballCareerMode.Domain.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.Seasons
{
    public class Season
    {
        public Guid Id { get; private set; }
        public Guid CareerId { get; private set; }
        public Career Career { get; private set; } = null!;
        public string Name { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<Match> _matches = new();
        public IReadOnlyCollection<Match> Matches => _matches.AsReadOnly();

        private Season() { }
        public Season(
            Guid id, 
            Guid careerId, 
            string name, 
            DateTime? startDate, 
            DateTime createdAt)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Season ID cannot be empty.");

            if (careerId == Guid.Empty)
                throw new ArgumentException("Career ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Season name is required");

            Id = id;
            CareerId = careerId;
            StartDate = startDate;
            Name = name;
            CreatedAt = createdAt;
        }

        public void EndSeason(DateTime endDate)
        {
            if (EndDate != null)
                throw new InvalidOperationException("Season is already ended.");

            EndDate = endDate;
        }

        public void AddMatch(Match match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match));

            if (EndDate != null)
            {
                throw new InvalidOperationException("Cannot add matches to an ended season.");
            }

            _matches.Add(match);
        }
    }
}
