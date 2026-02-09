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

            //sb.AppendLine("Write a realistic football match report.");
            //sb.AppendLine("Do NOT invent players, goals, or events.");
            //sb.AppendLine();
            //sb.AppendLine($"Competition: {input.CompetitionName}");
            //sb.AppendLine($"Team: {input.TeamName}");
            //sb.AppendLine($"Opponent: {input.OpponentName}");
            //sb.AppendLine($"Venue: {(input.IsHome ? "Home" : "Away")}");
            //sb.AppendLine($"Date: {input.PlayedAt:dd MMM yyyy, HH:mm}");
            //sb.AppendLine($"Final Score: {input.TeamGoals}-{input.OpponentGoals})");
            //sb.AppendLine();

            //if (input.GoalEvents.Any())
            //{
            //    sb.AppendLine("Goal Scorers:");
            //    foreach (var goal in input.GoalEvents)
            //        if (goal.Minute.HasValue)
            //            sb.AppendLine($"- {goal.Scorer} {goal.Minute}'");
            //        else
            //            sb.AppendLine($"- {goal.Scorer}");
            //    sb.AppendLine();
            //}

            //sb.AppendLine($"Recent Form: {input.RecentForm}");
            //sb.AppendLine("Tone: immersive, matchday journalism style.");

            //if (input.RecentHeadToHeadResults.Any())
            //{
            //    sb.AppendLine("Recent meetings against this opponent:");

            //    foreach (var h2h in input.RecentHeadToHeadResults)
            //    {
            //        sb.AppendLine(
            //            $"- {h2h.PlayedAt:dd MMM yyyy} | {h2h.CompetitionName}: " +
            //            $"{h2h.TeamGoals}-{h2h.OpponentGoals} ({h2h.Result})"
            //        );
            //    }

            //    sb.AppendLine();
            //}

            //// ROLE & WORLDVIEW
            //sb.AppendLine("You are a football journalist writing a post-match article for a mainstream sports outlet.");
            //sb.AppendLine("Your writing is grounded, observant, and restrained.");
            //sb.AppendLine("You focus on how the match unfolded and what it means, not on hype or dramatization.");
            //sb.AppendLine("You do not write as a fan, pundit, or tactician.");
            //sb.AppendLine();

            //// CORE CONSTRAINTS
            //sb.AppendLine("Constraints:");
            //sb.AppendLine("- Do NOT invent players, goals, cards, chances, or events.");
            //sb.AppendLine("- Do NOT speculate about opponent goal timing or circumstances if they are not provided.");
            //sb.AppendLine("- Avoid overused football phrases (e.g. \"dominant display\", \"hard-fought\", \"clinical\", \"end-to-end\", \"edge of their seats\").");
            //sb.AppendLine("- Vary sentence length and rhythm; avoid formulaic paragraph structure.");
            //sb.AppendLine();

            //// INTERPRETATION RULES
            //sb.AppendLine("Interpretation rules:");
            //sb.AppendLine("- Infer control, tension, or balance from the scoreline itself.");
            //sb.AppendLine("- Do not exaggerate narrow wins or draws.");
            //sb.AppendLine("- Do not assume a high-scoring match was chaotic or entertaining.");
            //sb.AppendLine("- Let home or away context subtly influence tone without stating it explicitly.");
            //sb.AppendLine("- Use team goal timing (if available) to infer momentum or decisive phases.");
            //sb.AppendLine("- Do not narrate goals chronologically.");
            //sb.AppendLine("- Do not describe opponent scoring moments.");
            //sb.AppendLine("- Use recent form lightly to frame context.");
            //sb.AppendLine("- Do not explicitly label form as \"good\" or \"poor\" unless strongly implied.");
            //sb.AppendLine("- Avoid stock phrases about runs of form.");
            //sb.AppendLine("- If recent head-to-head meetings exist, allow them to add narrative weight without exaggeration.");
            //sb.AppendLine("- If league position changes, describe the consequence without exaggerating its scale.");
            //sb.AppendLine("- If league position does not change, do not assume the match lacked importance.");
            //sb.AppendLine("- Do not reference points gaps or league tables beyond position movement.");
            //sb.AppendLine();

            //// STRUCTURAL GUIDANCE
            //sb.AppendLine("Structural guidance:");
            //sb.AppendLine("- Opening context: setting, form, and stakes.");
            //sb.AppendLine("- Match flow: key phases and shifts, not minute-by-minute action.");
            //sb.AppendLine("- Decisive moments: goals framed by impact, not occurrence.");
            //sb.AppendLine("- Implications: what this result changes or reinforces.");
            //sb.AppendLine("- Do not explicitly label sections.");
            //sb.AppendLine();

            //// MATCH DATA
            //sb.AppendLine("Match data:");
            //sb.AppendLine($"Competition: {input.CompetitionName}");
            //sb.AppendLine($"Team: {input.TeamName}");
            //sb.AppendLine($"Opponent: {input.OpponentName}");
            //sb.AppendLine($"Venue: {(input.IsHome ? "Home" : "Away")}");
            //sb.AppendLine($"Date: {input.PlayedAt:dd MMM yyyy, HH:mm}");
            //sb.AppendLine();
            //sb.AppendLine($"Final Score: {input.TeamGoals}-{input.OpponentGoals}");
            //sb.AppendLine();

            //if (input.GoalEvents.Any())
            //{
            //    sb.AppendLine("Team goal events:");
            //    foreach (var goal in input.GoalEvents)
            //    {
            //        if (goal.Minute.HasValue)
            //            sb.AppendLine($"- {goal.Scorer} {goal.Minute}'");
            //        else
            //            sb.AppendLine($"- {goal.Scorer}");
            //    }
            //    sb.AppendLine();
            //}

            //sb.AppendLine($"Recent form (last 5 matches): {input.RecentForm}");
            //sb.AppendLine();

            //if (input.RecentHeadToHeadResults.Any())
            //{
            //    sb.AppendLine("Recent head-to-head meetings:");
            //    foreach (var h2h in input.RecentHeadToHeadResults)
            //    {
            //        sb.AppendLine(
            //            $"- {h2h.PlayedAt:dd MMM yyyy} | {h2h.CompetitionName}: " +
            //            $"{h2h.TeamGoals}-{h2h.OpponentGoals}"
            //        );
            //    }
            //    sb.AppendLine();
            //}

            //sb.AppendLine("League position:");
            //sb.AppendLine($"- Before match: {input.LeaguePositionBefore}");
            //sb.AppendLine($"- After match: {input.LeaguePositionAfter}");
            //sb.AppendLine();

            //// OUTPUT REQUIREMENTS
            //sb.AppendLine("Output requirements:");
            //sb.AppendLine("- Write a single post-match article.");
            //sb.AppendLine("- Medium length (approximately 4–7 paragraphs).");
            //sb.AppendLine("- Neutral, authoritative tone.");
            //sb.AppendLine("- Focus on interpretation, not listing data.");

            // ROLE & WORLDVIEW
            sb.AppendLine("You are a football journalist writing a post-match narrative article for a mainstream sports outlet.");
            sb.AppendLine("The article should feel credible, grounded, and context-aware.");
            sb.AppendLine("It is written for readers following the season, not just the individual match.");
            sb.AppendLine("Avoid hype, fan language, or exaggerated drama.");
            sb.AppendLine();

            // CORE CONSTRAINTS
            sb.AppendLine("Core constraints:");
            sb.AppendLine("- Do NOT invent players, goals, cards, chances, or events.");
            sb.AppendLine("- Do NOT invent quotes, emotions, or touchline behavior.");
            sb.AppendLine("- Do NOT speculate about events not supported by the data.");
            sb.AppendLine("- Avoid overused football clichés and generic phrasing.");
            sb.AppendLine("- Vary sentence length and rhythm.");
            sb.AppendLine();

            // INTERPRETATION RULES
            sb.AppendLine("Interpretation rules:");
            sb.AppendLine("- Infer control, balance, or tension from the scoreline itself.");
            sb.AppendLine("- Do not exaggerate narrow wins or routine results.");
            sb.AppendLine("- High-margin wins do not automatically imply dominance throughout.");
            sb.AppendLine("- Let home or away context subtly influence tone without stating it explicitly.");
            sb.AppendLine("- Use team goal timing (if available) to infer momentum or decisive phases.");
            sb.AppendLine("- Do not narrate goals chronologically.");
            sb.AppendLine("- Do not describe opponent scoring moments.");
            sb.AppendLine("- Use recent form lightly to frame context.");
            sb.AppendLine("- Avoid labeling form as \"good\" or \"poor\" unless strongly implied.");
            sb.AppendLine("- Do not rely on stock phrases about runs of results.");
            sb.AppendLine("- If recent head-to-head meetings exist, allow them to add familiarity or expectation.");
            sb.AppendLine("- Do not exaggerate dominance or rivalry.");
            sb.AppendLine("- Describe league position consequences without overstating importance.");
            sb.AppendLine("- No movement does not imply lack of significance.");
            sb.AppendLine("- Do not reference points gaps or the wider table.");
            sb.AppendLine("- Use board expectations to frame scrutiny and evaluation, not stakes.");
            sb.AppendLine("- Higher expectations increase restraint in praise and analytical distance.");
            sb.AppendLine("- Lower expectations soften judgment without removing ambition.");
            sb.AppendLine("- Do not treat expectations as guarantees or requirements.");
            sb.AppendLine("- The manager’s name may be used to frame continuity or direction.");
            sb.AppendLine("- Mention the manager sparingly and only where it adds narrative clarity.");
            sb.AppendLine("- Do not invent emotional reactions, quotes, or intent.");
            sb.AppendLine();

            // STRUCTURAL GUIDANCE
            sb.AppendLine("Structural guidance:");
            sb.AppendLine("- Pre-match context and expectation.");
            sb.AppendLine("- Match flow and key phases.");
            sb.AppendLine("- Decisive or defining moments.");
            sb.AppendLine("- What the result reinforces or leaves open.");
            sb.AppendLine("- Do not label sections explicitly.");
            sb.AppendLine("- Do not attempt minute-by-minute narration.");
            sb.AppendLine();

            // MATCH DATA
            sb.AppendLine("Match data:");
            sb.AppendLine($"Competition: {input.CompetitionName}");
            sb.AppendLine($"Team: {input.TeamName}");
            sb.AppendLine($"Opponent: {input.OpponentName}");
            sb.AppendLine($"Venue: {(input.IsHome ? "Home" : "Away")}");
            sb.AppendLine($"Date: {input.PlayedAt:dd MMM yyyy}");
            sb.AppendLine();
            sb.AppendLine($"Final Score: {input.TeamGoals}-{input.OpponentGoals}");
            sb.AppendLine();

            if (input.GoalEvents.Any())
            {
                sb.AppendLine("Team goal events:");
                foreach (var goal in input.GoalEvents)
                {
                    if (goal.Minute.HasValue)
                        sb.AppendLine($"- {goal.Scorer} {goal.Minute}'");
                    else
                        sb.AppendLine($"- {goal.Scorer}");
                }
                sb.AppendLine();
            }

            sb.AppendLine($"Recent Form (last 5): {input.RecentForm}");
            sb.AppendLine();

            if (input.RecentHeadToHeadResults.Any())
            {
                sb.AppendLine("Recent head-to-head results:");
                foreach (var h2h in input.RecentHeadToHeadResults)
                {
                    sb.AppendLine(
                        $"- {h2h.PlayedAt:dd MMM yyyy} | {h2h.CompetitionName}: " +
                        $"{h2h.TeamGoals}-{h2h.OpponentGoals}"
                    );
                }
                sb.AppendLine();
            }

            sb.AppendLine("League position:");
            sb.AppendLine($"- Before match: {input.LeaguePositionBefore}");
            sb.AppendLine($"- After match: {input.LeaguePositionAfter}");
            sb.AppendLine();

            sb.AppendLine($"Board Expectation: {input.Expectation}");
            sb.AppendLine($"Team Manager: {input.TeamManagerName}");
            sb.AppendLine();

            // OUTPUT REQUIREMENTS
            sb.AppendLine("Output requirements:");
            sb.AppendLine("- Write a single post-match narrative article.");
            sb.AppendLine("- Medium length.");
            sb.AppendLine("- Neutral, authoritative tone.");
            sb.AppendLine("- Focus on interpretation and context, not listing data.");

            return sb.ToString();
        }
    }
}
