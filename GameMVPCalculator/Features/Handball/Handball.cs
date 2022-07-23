using GameMVPCalculator.Models;

namespace GameMVPCalculator.Features.Handball
{
    public class Handball : BaseGame
    {
        public Handball() : base("Handball",
            $"{Directory.GetCurrentDirectory()}/Data/handball_players.txt",
            $"{Directory.GetCurrentDirectory()}/Data/handball_points.csv")
        {
        }

        public override decimal CalculateMvp(BasePlayer basePlayer, PointEntity pointToUse)
        {
            HandballPlayer player = (HandballPlayer)basePlayer;
            return (pointToUse.Values["initial rating points"]) +
                    (pointToUse.Values["goal made"] * player.GoalsMade) -
                    (pointToUse.Values["goal received"] * player.GoalsReceived);
        }


        public override BasePlayer MapPlayerToObject(string[] line)
        {
            return new HandballPlayer
            {
                Name = line[0],
                Nickname = line[1],
                Number = int.Parse(line[2]),
                Team = line[3],
                Position = char.Parse(line[4]),
                GoalsMade = int.Parse(line[5]),
                GoalsReceived = int.Parse(line[6])
            };
        }

        public override decimal WinnerTeamMetric(BasePlayer basePlayer)
        {
            return ((HandballPlayer)basePlayer).GoalsMade;
        }
    }
}
