using FootballCareerCompanion.Application.AI.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.AI.PromptBuilders
{
    public class MatchReportPromptBuilder
    {
        public string Build(MatchNarrativeInput input)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Write a realistic football match report.");
            sb.AppendLine("Do NOT invent players, goals, or events.");
            sb.AppendLine();
            sb.AppendLine($"Competition: {input.CompetitionName}");
            sb.AppendLine($"Team: {input.TeamName}");
            sb.AppendLine($"Opponent: {input.OpponentName}");
            sb.AppendLine($"Venue: {(input.IsHome ? "Home" : "Away")}");
            sb.AppendLine($"Date: {input.PlayedAt:dd MMM yyyy, HH:mm}");
            sb.AppendLine($"Final Score: {input.TeamGoals}-{input.OpponentGoals} ({input.Result})");
            sb.AppendLine();

            if (input.GoalEvents.Any())
            {
                sb.AppendLine("Goal Scorers:");
                foreach (var goal in input.GoalEvents)
                    if (goal.Minute.HasValue)
                        sb.AppendLine($"- {goal.Scorer} {goal.Minute}'");
                    else
                        sb.AppendLine($"- {goal.Scorer}");
                sb.AppendLine();
            }

            sb.AppendLine($"Recent Form: {input.RecentForm}");
            sb.AppendLine("Tone: immersive, matchday journalism style.");

            if (input.RecentHeadToHeadResults.Any())
            {
                sb.AppendLine("Recent meetings against this opponent:");

                foreach (var h2h in input.RecentHeadToHeadResults)
                {
                    sb.AppendLine(
                        $"- {h2h.PlayedAt:dd MMM yyyy} | {h2h.CompetitionName}: " +
                        $"{h2h.TeamGoals}-{h2h.OpponentGoals} ({h2h.Result})"
                    );
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
