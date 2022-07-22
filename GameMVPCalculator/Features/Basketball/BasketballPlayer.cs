using GameMVPCalculator.Models;

namespace GameMVPCalculator.Features.Basketball
{
    public class BasketballPlayer : BasePlayer
    {
        public int ScoredPoint { get; set; }
        public int Rebound { get; set; }
        public int Assist { get; set; }
    }
}
