using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.Narratives
{

    public class NarrativeSnapshot
    {
        public Guid Id { get; private set; }
        public Guid? MatchId { get; private set; }
        public Guid? SeasonId { get; private set; }
        public string Type { get; private set; }
        public string Content { get; private set; }
        public string PromptVersion { get; private set; }
        public string ModelVersion { get; private set; }
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
    }

}

