using FootballCareerCompanion.Infrastructure.Persistence;
using FootballCareerCompanion.Application.Interfaces.Repositories;
using FootballCareerCompanion.Domain.Narratives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Infrastructure.Repositories
{
    public class NarrativeSnapshotRepository : INarrativeSnapshotRepository
    {
        private readonly FootballCareerCompanionDbContext _db;

        public NarrativeSnapshotRepository(FootballCareerCompanionDbContext db)
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
