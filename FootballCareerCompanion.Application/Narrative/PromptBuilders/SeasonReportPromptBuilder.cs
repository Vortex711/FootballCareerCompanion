using FootballCareerCompanion.Application.AI.Inputs;
using FootballCareerCompanion.Application.AI.Inputs.Enums;
using FootballCareerCompanion.Application.AI.Inputs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.AI.PromptBuilders
{
    public sealed class SeasonReportPromptBuilder
    {
        public string Build(SeasonNarrativeInput input)
        {
            //var sb = new StringBuilder();

            //// ─────────────────────────────────────
            //// 1. System framing
            //// ─────────────────────────────────────

            //sb.AppendLine("You are a football journalist writing a season summary article.");
            //sb.AppendLine("Base your writing ONLY on the information provided below.");
            //sb.AppendLine("Do NOT assume league positions, tables, or title races.");
            //sb.AppendLine("Do NOT invent competitions, players, or results.");
            //sb.AppendLine();

            //// ─────────────────────────────────────
            //// 2. Season context
            //// ─────────────────────────────────────

            //sb.AppendLine("Season Context:");
            //sb.AppendLine($"- Club: {input.ClubName}");
            //sb.AppendLine($"- Season: {input.SeasonName}");
            //sb.AppendLine($"- Manager: {input.ManagerName}");
            //sb.AppendLine($"- Board Expectation: {input.Expectation}");

            //sb.AppendLine(input.InvocationType == SeasonInvocationType.EndOfSeason
            //    ? "- This summary is written after the season has concluded."
            //    : "- This summary reflects the season so far and is mid-campaign.");

            //sb.AppendLine($"- Matches played: {input.MatchesPlayed}");
            //sb.AppendLine();

            //// ─────────────────────────────────────
            //// 3. Results snapshot
            //// ─────────────────────────────────────

            //sb.AppendLine("Results Summary:");
            //if (input.LeaguePosition != null)
            //    sb.AppendLine($"- League Position: {input.LeaguePosition}");
            //sb.AppendLine($"- Wins: {input.Wins}");
            //sb.AppendLine($"- Draws: {input.Draws}");
            //sb.AppendLine($"- Losses: {input.Losses}");
            //sb.AppendLine($"- Goals scored: {input.GoalsFor}");
            //sb.AppendLine($"- Goals conceded: {input.GoalsAgainst}");
            //sb.AppendLine($"- Goal difference: {input.GoalDifference}");
            //sb.AppendLine();

            //// ─────────────────────────────────────
            //// 4. Recent form
            //// ─────────────────────────────────────

            //sb.AppendLine($"Recent Form (last {input.RecentFormMatchCount} matches):");
            //AppendFormSnapshot(sb, input.RecentForm);
            //sb.AppendLine();

            //// ─────────────────────────────────────
            //// 5. Goal timing patterns
            //// ─────────────────────────────────────

            //sb.AppendLine("Goal Timing Patterns (team goals with recorded minutes only):");
            //sb.AppendLine($"- Early game (0–30): {input.GoalsScoredByPhase.EarlyGame}");
            //sb.AppendLine($"- Mid game (31–60): {input.GoalsScoredByPhase.MidGame}");
            //sb.AppendLine($"- Late game (61+): {input.GoalsScoredByPhase.LateGame}");
            //sb.AppendLine();

            //// ─────────────────────────────────────
            //// 6. Top scorers
            //// ─────────────────────────────────────

            //if (input.TopScorers.Any())
            //{
            //    sb.AppendLine($"Top {input.TopScorers.Count} Goal Scorers:");
            //    foreach (var scorer in input.TopScorers)
            //    {
            //        sb.AppendLine($"- {scorer.PlayerName}: {scorer.Goals} goals");
            //    }
            //    sb.AppendLine();
            //}

            //// ─────────────────────────────────────
            //// 7. Home vs Away
            //// ─────────────────────────────────────

            //sb.AppendLine("Home Record:");
            //sb.AppendLine($"- {input.Home.Wins}W {input.Home.Draws}D {input.Home.Losses}L");

            //sb.AppendLine("Away Record:");
            //sb.AppendLine($"- {input.Away.Wins}W {input.Away.Draws}D {input.Away.Losses}L");
            //sb.AppendLine();

            //// ─────────────────────────────────────
            //// 8. Notable Matches
            //// ─────────────────────────────────────

            //if (input.NotableMatches.Any())
            //{
            //    sb.AppendLine($"Notable Matches:");
            //    foreach (var match in input.NotableMatches)
            //    {
            //        sb.AppendLine($"{match.ContextLabel}: vs {match.OpponentName} ({match.TeamGoals} - {match.OpponentGoals})");
            //    }
            //}

            //// ─────────────────────────────────────
            //// 9. Writing instructions
            //// ─────────────────────────────────────

            //sb.AppendLine("Writing Instructions:");
            //sb.AppendLine("- Write a cohesive season narrative article, not a list.");
            //sb.AppendLine("- Maintain a journalistic tone.");
            //sb.AppendLine($"- Overall tone should be: {input.ToneHint}.");
            //sb.AppendLine("- Avoid speculation about league standings or future outcomes.");
            //sb.AppendLine("- Focus on form, patterns, and key contributors.");
            //sb.AppendLine("- Keep the article realistic and grounded.");

            //return sb.ToString();

            var sb = new StringBuilder();

            // ─────────────────────────────────────
            // 1. System framing
            // ─────────────────────────────────────

            sb.AppendLine("You are a football journalist writing a season narrative article.");
            sb.AppendLine("Use the information provided below as background context.");
            sb.AppendLine("Do NOT assume league tables, title races, or competitions that are not provided.");
            sb.AppendLine("Do NOT invent players, matches, or results.");
            sb.AppendLine();

            // IMPORTANT: Tell the model it can interpret instead of listing
            sb.AppendLine("Editorial Rules:");
            sb.AppendLine("- Treat the data below as background information, not a checklist.");
            sb.AppendLine("- You do NOT need to mention every statistic or section.");
            sb.AppendLine("- Focus on the most meaningful storylines from the season so far.");
            sb.AppendLine("- Avoid listing statistics mechanically or breaking numbers into segments.");
            sb.AppendLine("- Do not describe goal timing phases explicitly (e.g. '0–30 minutes', '31–60 minutes').");
            sb.AppendLine("- Use statistics only when they naturally support the narrative.");
            sb.AppendLine("- Prefer interpretation over enumeration.");
            sb.AppendLine();

            // ─────────────────────────────────────
            // 2. Season context
            // ─────────────────────────────────────

            sb.AppendLine();
            sb.AppendLine("Season Context:");
            sb.AppendLine($"- Club: {input.ClubName}");
            sb.AppendLine($"- Season: {input.SeasonName}");
            sb.AppendLine($"- Manager: {input.ManagerName}");
            sb.AppendLine($"- Board Expectation: {input.Expectation}");

            sb.AppendLine(input.InvocationType == SeasonInvocationType.EndOfSeason
                ? "- The season has concluded."
                : "- The season is currently in progress.");

            sb.AppendLine($"- Matches played: {input.MatchesPlayed}");
            sb.AppendLine();

            // ─────────────────────────────────────
            // 3. Results snapshot
            // ─────────────────────────────────────

            sb.AppendLine("Results Snapshot (context only):");
            if (input.LeaguePosition != null)
                sb.AppendLine($"- League Position: {input.LeaguePosition}");
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

            sb.AppendLine("Goal Timing Data (background context only):");
            sb.AppendLine($"- Early game (0–30): {input.GoalsScoredByPhase.EarlyGame}");
            sb.AppendLine($"- Mid game (31–60): {input.GoalsScoredByPhase.MidGame}");
            sb.AppendLine($"- Late game (61+): {input.GoalsScoredByPhase.LateGame}");
            sb.AppendLine();

            // ─────────────────────────────────────
            // 6. Top scorers
            // ─────────────────────────────────────

            if (input.TopScorers.Any())
            {
                sb.AppendLine("Top Scorers (context):");
                foreach (var scorer in input.TopScorers)
                {
                    sb.AppendLine($"- {scorer.PlayerName}: {scorer.Goals} goals");
                }

                sb.AppendLine();
                sb.AppendLine("Important:");
                sb.AppendLine("- Only highlight individual players if their contribution clearly stands out.");
                sb.AppendLine("- If several players have similar totals, describe the scoring as shared across the squad.");
                sb.AppendLine("- Do not list players purely because they appear in the data.");
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
            // 8. Notable Matches
            // ─────────────────────────────────────

            if (input.NotableMatches.Any())
            {
                sb.AppendLine("Notable Matches:");
                foreach (var match in input.NotableMatches)
                {
                    sb.AppendLine($"{match.ContextLabel}: vs {match.OpponentName} ({match.TeamGoals} - {match.OpponentGoals})");
                }
            }

            // ─────────────────────────────────────
            // 9. Writing instructions
            // ─────────────────────────────────────

            sb.AppendLine();
            sb.AppendLine("Writing Instructions:");
            sb.AppendLine("- Write a cohesive season narrative article, not a list.");
            sb.AppendLine("- Focus on 2–3 key storylines rather than summarizing all statistics.");
            sb.AppendLine("- Integrate numbers naturally instead of presenting them as breakdowns.");
            sb.AppendLine("- Avoid analytical-stat-report language.");
            sb.AppendLine($"- Overall tone should be: {input.ToneHint}.");
            sb.AppendLine("- Keep the article realistic and grounded.");
            sb.AppendLine("- Prioritize narrative themes such as momentum, identity under the manager, or key performances.");

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