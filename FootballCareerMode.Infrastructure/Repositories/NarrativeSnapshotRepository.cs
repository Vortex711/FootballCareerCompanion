using FootballCareerMode.Application.Interfaces.Repositories;
using FootballCareerMode.Domain.Narratives;
using FootballCareerMode.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Infrastructure.Repositories
{
    public class NarrativeSnapshotRepository : INarrativeSnapshotRepository
    {
        private readonly FootballCareerModeDbContext _db;

        public NarrativeSnapshotRepository(FootballCareerModeDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(NarrativeSnapshot snapshot)
        {
            _db.NarrativeSnapshots.Add(snapshot);
            await _db.SaveChangesAsync();
        }

        public async Task<NarrativeSnapshot?> GetByMatchIdAsync(Guid matchId)
        {
            return await _db.NarrativeSnapshots
            .FirstOrDefaultAsync(n => n.MatchId == matchId);
        }

        public async Task<NarrativeSnapshot?> GetBySeasonIdAsync(Guid seasonId)
        {
            return await _db.NarrativeSnapshots
            .FirstOrDefaultAsync(n => n.SeasonId == seasonId);
        }
    }
}
