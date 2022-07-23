using GameMVPCalculator.Models;

namespace GameMVPCalculator.Features.Basketball
{
    public class Basketball : BaseGame
    {
        public Basketball() : base("Basketball",
            $"{Directory.GetCurrentDirectory()}/Data/basketball_players.txt",
            $"{Directory.GetCurrentDirectory()}/Data/basketball_points.csv")
        {

        }

        public override decimal CalculateMvp(BasePlayer basePlayer, PointEntity pointToUse)
        {
            BasketballPlayer player = (BasketballPlayer)basePlayer;
            return (pointToUse.Values["scored point"] * player.ScoredPoint) +
                    (pointToUse.Values["rebound"] * player.Rebound) +
                    (pointToUse.Values["assist"] * player.Assist);
        }

        public override decimal WinnerTeamMetric(BasePlayer basePlayer)
        {
            return ((BasketballPlayer)basePlayer).ScoredPoint;
        }

        public override BasketballPlayer MapPlayerToObject(string[] line)
        {
            return new BasketballPlayer
            {
                Name = line[0],
                Nickname = line[1],
                Number = int.Parse(line[2]),
                Team = line[3],
                Position = char.Parse(line[4]),
                ScoredPoint = int.Parse(line[5]),
                Rebound = int.Parse(line[6]),
                Assist = int.Parse(line[7]),
            };
        }


    }
}
