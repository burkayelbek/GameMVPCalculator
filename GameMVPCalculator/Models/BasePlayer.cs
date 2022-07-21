namespace GameMVPCalculator.Models
{
    public class BasePlayer
    {
        public string Name { get; set; } = default!;
        // The nickname for the player is unique
        public string Nickname { get; set; } = default!;
        public string Team { get; set; } = default!;
        public string Position { get; set; } = default!;
        public int Number { get; set; }
        public decimal TotalScore { get; set; } = 0;
    }
}
