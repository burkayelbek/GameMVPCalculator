using GameMVPCalculator.Features.Basketball;
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
        }

        public void ShowMvps()
        {
            foreach(var game in games)
            {
                Console.WriteLine($"Game: {game.Name}");
                Console.WriteLine($"MVP:\n");

                BasePlayer mvpPlayer = game.FindMvp();
                Console.WriteLine($"\tName: {mvpPlayer.Name}\n\t" +
                                  $"Nickname: {mvpPlayer.Nickname}\n\t" +
                                  $"Number: {mvpPlayer.Number}\n\t" +
                                  $"Team: {mvpPlayer.Team}\n\t" +
                                  $"Position: {mvpPlayer.Position}");

                Console.WriteLine("==================================\n\n\n\n");
            }
        }



    }
}
