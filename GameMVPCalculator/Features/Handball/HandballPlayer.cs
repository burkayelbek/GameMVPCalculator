using GameMVPCalculator.Models;

namespace GameMVPCalculator.Features.Handball
{
    public class HandballPlayer : BasePlayer
    {
        public int GoalsMade { get; set; }
        public int GoalsReceived { get; set; }
    }
}
