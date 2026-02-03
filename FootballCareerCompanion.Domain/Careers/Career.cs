using FootballCareerCompanion.Domain.Seasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Domain.Careers
{
    public class Career
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string ClubName { get; private set; } = null!;
        public string ManagerName { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }

        private readonly List<Season> _seasons = new();
        public IReadOnlyCollection<Season> Seasons => _seasons.AsReadOnly();

        private Career() { }

        public Career (
            Guid id, 
            string name, 
            string clubName, 
            string managerName,
            DateTime createdAt) 
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Career ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Career name is required.");

            if (string.IsNullOrWhiteSpace(clubName))
                throw new ArgumentException("Club name is required.");

            if (string.IsNullOrWhiteSpace(managerName))
                throw new ArgumentException("Manager name is required.");

            Id = id;
            Name = name;
            ClubName = clubName;
            CreatedAt = createdAt;
            ManagerName = managerName;

        }

        public void AddSeason(Season season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Add(season);
        }

    }
}
