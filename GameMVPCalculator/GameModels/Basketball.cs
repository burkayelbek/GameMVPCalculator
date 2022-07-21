using GameMVPCalculator.Models;

namespace GameMVPCalculator.GameModels
{
    public class Basketball : Game<BasePlayer>
    {
        public Basketball() : base("Basketball", "....players.csv", "....rules.csv")
        {

        }

        public override BasePlayer FindMvp()
        {
            // This function will be implemented for each sport.

            decimal maxScore = Players.FirstOrDefault().TotalScore ?? (decimal);

            foreach (var player in Players)
            {

                PointEntity? pointToUse = Points.Where(p => p.DisplayName == player.Name && p.Position == player.Position).FirstOrDefault();

                // If nothing was found, select the first point that does not match our criteria
                if (pointToUse is null)
                    pointToUse = Points.Where(p => !(p.DisplayName == player.Name && p.Position == player.Position)).FirstOrDefault();

                if (pointToUse is null)
                    throw new Exception($"Could not find any point to use for calculation. For player with nickname: {player.Nickname}");

                player.TotalScore += pointToUse.Value;
            }

            return Players.FirstOrDefault(p => p.TotalScore == maxScore);


        }
    }
}
