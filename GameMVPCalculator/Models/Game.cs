namespace GameMVPCalculator.Models
{
    public abstract class Game<T> where T : BasePlayer
    {
        public Game(string gameName, string playersFilePath, string gamePointsFilePath)
        {
            Name = gameName;
            Players = ReadAllPlayersFromFile(playersFilePath);
            Points = ReadAllRulesFromFile(gamePointsFilePath);
        }


        public string Name { get; set; } = default!;
        public List<T> Players { get; set; }
        public List<PointEntity> Points { get; set; }


        private List<T> ReadAllPlayersFromFile(string path)
        {
            return new List<T>();
        }

        private List<PointEntity> ReadAllRulesFromFile(string path)
        {
            return new List<PointEntity>();
        }

        public abstract T FindMvp();

    }
}
