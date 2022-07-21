using GameMVPCalculator.Models;

namespace GameMVPCalculator.Service
{
    public class BaseGameService
    {
        private List< Game<BasePlayer> > games;

        public BaseGameService()
        {

        }

        public void CreateGames()
        {
            games = new List< Game<BasePlayer> >();

            games.Add( new Game<BasketballPlayer>("Basketball", "....players.csv", "....gamePoints.csv" ) );
        }




        // Calculate point function, how to make it dynamic ?


    }
}
