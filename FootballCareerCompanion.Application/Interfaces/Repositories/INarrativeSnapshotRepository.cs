using FootballCareerCompanion.Domain.Narratives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.Interfaces.Repositories
{
    public interface INarrativeSnapshotRepository
    {
        Task AddAsync(NarrativeSnapshot snapshot);
        Task<NarrativeSnapshot?> GetByMatchIdAsync(Guid matchId);
        Task<NarrativeSnapshot?> GetBySeasonIdAsync(Guid matchId);

    }
}
