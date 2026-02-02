using FootballCareerMode.Application.AI.Inputs;
using FootballCareerMode.Application.AI.Inputs.Enums;
using FootballCareerMode.Application.AI.Inputs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Application.AI.PromptBuilders
{
    public sealed class SeasonReportPromptBuilder
    {
        public string Build(SeasonNarrativeInput input)
        {
            var sb = new StringBuilder();

            // ─────────────────────────────────────
            // 1. System framing
            // ─────────────────────────────────────

            sb.AppendLine("You are a football journalist writing a season summary article.");
            sb.AppendLine("Base your writing ONLY on the information provided below.");
            sb.AppendLine("Do NOT assume league positions, tables, or title races.");
            sb.AppendLine("Do NOT invent competitions, players, or results.");
            sb.AppendLine();

            // ─────────────────────────────────────
            // 2. Season context
            // ─────────────────────────────────────

            sb.AppendLine("Season Context:");
            sb.AppendLine($"- Club: {input.ClubName}");
            sb.AppendLine($"- Season: {input.SeasonName}");

            sb.AppendLine(input.InvocationType == SeasonInvocationType.EndOfSeason
                ? "- This summary is written after the season has concluded."
                : "- This summary reflects the season so far and is mid-campaign.");

            sb.AppendLine($"- Matches played: {input.MatchesPlayed}");
            sb.AppendLine();

            // ─────────────────────────────────────
            // 3. Results snapshot
            // ─────────────────────────────────────

            sb.AppendLine("Results Summary:");
            sb.AppendLine($"- Wins: {input.Wins}");
            sb.AppendLine($"- Draws: {input.Draws}");
            sb.AppendLine($"- Losses: {input.Losses}");
            sb.AppendLine($"- Goals scored: {input.GoalsFor}");
            sb.AppendLine($"- Goals conceded: {input.GoalsAgainst}");
            sb.AppendLine($"- Goal difference: {input.GoalDifference}");
            sb.AppendLine();

            // ─────────────────────────────────────
            // 4. Recent form
            // ─────────────────────────────────────

            sb.AppendLine($"Recent Form (last {input.RecentFormMatchCount} matches):");
            AppendFormSnapshot(sb, input.RecentForm);
            sb.AppendLine();

            // ─────────────────────────────────────
            // 5. Goal timing patterns
            // ─────────────────────────────────────

            sb.AppendLine("Goal Timing Patterns (team goals with recorded minutes only):");
            sb.AppendLine($"- Early game (0–30): {input.GoalsScoredByPhase.EarlyGame}");
            sb.AppendLine($"- Mid game (31–60): {input.GoalsScoredByPhase.MidGame}");
            sb.AppendLine($"- Late game (61+): {input.GoalsScoredByPhase.LateGame}");
            sb.AppendLine();

            // ─────────────────────────────────────
            // 6. Top scorers
            // ─────────────────────────────────────

            if (input.TopScorers.Any())
            {
                sb.AppendLine($"Top {input.TopScorers.Count} Goal Scorers:");
                foreach (var scorer in input.TopScorers)
                {
                    sb.AppendLine($"- {scorer.PlayerName}: {scorer.Goals} goals");
                }
                sb.AppendLine();
            }

            // ─────────────────────────────────────
            // 7. Home vs Away
            // ─────────────────────────────────────

            sb.AppendLine("Home Record:");
            sb.AppendLine($"- {input.Home.Wins}W {input.Home.Draws}D {input.Home.Losses}L");

            sb.AppendLine("Away Record:");
            sb.AppendLine($"- {input.Away.Wins}W {input.Away.Draws}D {input.Away.Losses}L");
            sb.AppendLine();

            // ─────────────────────────────────────
            // 8. Writing instructions
            // ─────────────────────────────────────

            sb.AppendLine("Writing Instructions:");
            sb.AppendLine("- Write a cohesive season narrative article, not a list.");
            sb.AppendLine("- Maintain a journalistic tone.");
            sb.AppendLine($"- Overall tone should be: {input.ToneHint}.");
            sb.AppendLine("- Avoid speculation about league standings or future outcomes.");
            sb.AppendLine("- Focus on form, patterns, and key contributors.");
            sb.AppendLine("- Keep the article realistic and grounded.");

            return sb.ToString();
        }

        private static void AppendFormSnapshot(StringBuilder sb, FormSnapshot form)
        {
            sb.AppendLine(
                $"- Record: {form.Wins}W {form.Draws}D {form.Losses}L");
            sb.AppendLine(
                $"- Goals: {form.GoalsFor} scored, {form.GoalsAgainst} conceded");
        }
    }
}
