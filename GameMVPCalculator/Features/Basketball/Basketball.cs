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

        public override BasketballPlayer FindMvp()
        {
            // This function will be implemented for each sport.

            if (!Players.Any())
                throw new Exception("Can't find MVP since there are no players");

            foreach (BasketballPlayer player in Players)
            {

                PointEntity pointToUse = Points.First(p => p.PositionLetter == player.Position);

                player.TotalScore = (pointToUse.Values["scored point"] * player.ScoredPoint) +
                                    (pointToUse.Values["rebound"] * player.Rebound) +
                                    (pointToUse.Values["assist"] * player.Assist);
            }

            return Players.MaxBy(p => p.TotalScore) as BasketballPlayer;
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
