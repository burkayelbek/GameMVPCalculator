namespace GameMVPCalculator.Models
{
    public class PointEntity
    {
        // Based on the game the role for this point (guard, center, goal keeper etc)
        public char PositionLetter { get; set; } = default!;
        public string PositionText { get; set; } = default!;
        public Dictionary<string, decimal> Values { get; set; }

    }
}
