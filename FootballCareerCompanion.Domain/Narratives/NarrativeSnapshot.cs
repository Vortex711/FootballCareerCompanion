using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Domain.Narratives
{

    public class NarrativeSnapshot
    {
        public Guid Id { get; private set; }
        public Guid? MatchId { get; private set; }
        public Guid? SeasonId { get; private set; }
        public string Type { get; private set; } = null!;
        public string Content { get; private set; } = null!;
        public string PromptVersion { get; private set; } = null!;
        public string ModelVersion { get; private set; } = null!;
        public DateTime GeneratedAt { get; private set; }

        private NarrativeSnapshot() { }
        public NarrativeSnapshot(
            Guid id,
            Guid? matchId,
            Guid? seasonId,
            string type,
            string content,
            string promptVersion,
            string modelVersion,
            DateTime generatedAt)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("NarrativeSnapshot ID cannot be empty.");

            if (matchId == null && seasonId == null)
                throw new ArgumentException("NarrativeSnapshot must belong to a Match or a Season.");

            if (matchId != null && seasonId != null)
                throw new ArgumentException("NarrativeSnapshot cannot belong to both Match and Season.");

            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Narrative type is required.");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Narrative content is required.");

            Id = id;
            MatchId = matchId;
            SeasonId = seasonId;
            Type = type;
            Content = content;
            PromptVersion = promptVersion;
            ModelVersion = modelVersion;
            GeneratedAt = generatedAt;
        }

        public static NarrativeSnapshot ForMatch(
            Guid matchId,
            string content,
            string promptVersion,
            string modelVersion)
        {
            if (matchId == Guid.Empty)
                throw new ArgumentException("MatchId cannot be empty.");

            return new NarrativeSnapshot(
                id: Guid.NewGuid(),
                matchId: matchId,
                seasonId: null,
                type: "MatchReport",
                content: content,
                promptVersion: promptVersion,
                modelVersion: modelVersion,
                generatedAt: DateTime.UtcNow
            );
        }

        public static NarrativeSnapshot ForSeason(
            Guid seasonId,
            string content,
            string promptVersion,
            string modelVersion)
        {
            return new NarrativeSnapshot(
                id: Guid.NewGuid(),
                matchId: null,
                seasonId: seasonId,
                type: "SeasonReport",
                content: content,
                promptVersion: promptVersion,
                modelVersion: modelVersion,
                generatedAt: DateTime.UtcNow
            );
        }

    }

}

