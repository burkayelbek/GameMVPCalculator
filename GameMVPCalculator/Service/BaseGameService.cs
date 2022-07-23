using GameMVPCalculator.Features.Basketball;
using GameMVPCalculator.Features.Handball;
using GameMVPCalculator.Models;

namespace GameMVPCalculator.Service
{
    public class BaseGameService
    {
        private List<BaseGame> games;

        public BaseGameService()
        {
            games = new List<BaseGame>();
            CreateGames();
            ShowMvps();
        }

        public void CreateGames()
        {
            games.Add(new Basketball());
            games.Add(new Handball());
        }

        public void ShowMvps()
        {
            foreach(var game in games)
            {
                Console.WriteLine($"Game: {game.Name}\t\tBest team: {game.FindWinnerTeam()}");
                Console.WriteLine($"MVP:\n");

                BasePlayer mvpPlayer = game.FindMvp();
                Console.WriteLine($"\tName: {mvpPlayer.Name}\n\t" +
                                  $"Nickname: {mvpPlayer.Nickname}\n\t" +
                                  $"Number: {mvpPlayer.Number}\n\t" +
                                  $"Team: {mvpPlayer.Team}\n\t" +
                                  $"Position: {mvpPlayer.Position}\n\t" +
                                  $"Total score: {mvpPlayer.TotalScore}");

                Console.WriteLine("==================================\n\n\n\n");
            }
        }



    }
}
