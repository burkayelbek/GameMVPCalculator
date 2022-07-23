namespace GameMVPCalculator.Models
{
    public abstract class BaseGame
    {
        public BaseGame(string gameName, string playersFilePath, string gamePointsFilePath)
        {
            Name = gameName;
            StoreAllRulesFromFile(gamePointsFilePath);
            StoreAllPlayersFromFile(playersFilePath);
        }


        public string Name { get; set; } = default!;
        public List<BasePlayer> Players { get; set; } = new List<BasePlayer>();
        public List<PointEntity> Points { get; set; } = new List<PointEntity>();


        private void StoreAllPlayersFromFile(string path)
        {
            string fileRoute = path;
            char splitCharacter = ';';

            using (StreamReader reader = new StreamReader(fileRoute))
            {
                string? playerLine;
                while ((playerLine = reader.ReadLine()) is not null)
                {
                    string[] playerParameters = playerLine.Split(splitCharacter);

                    Players.Add(MapPlayerToObject(playerParameters));
                }
            }

        }

        private void StoreAllRulesFromFile(string path)
        {
            string fileRoute = path;
            char splitCharacter = ',';

            using (StreamReader reader = new StreamReader(fileRoute))
            {
                string? ruleLine;
                // The header line holds the titles for the rules, we know that the first index is empty
                string[]? headerLines = reader.ReadLine()?.Split(',');
                while ((ruleLine = reader.ReadLine()) is not null)
                {
                    string[] ruleParameters = ruleLine.Split(splitCharacter);

                    // The letter of the position which is used to identify the position of the player in the "players" file. (the position is stored as single character such as G for goal keeper)
                    int indexOfPositionChar = ruleParameters[0].IndexOf('(') + 1;
                    Dictionary<string, decimal> positionPoints = new Dictionary<string, decimal>();

                    // Store all of the points as dictionary for the position
                    for (int i = 1; i < ruleParameters.Count(); i++)
                    {
                        positionPoints.Add(headerLines[i].ToLower(), Decimal.Parse(ruleParameters[i]));
                    }

                    Points.Add(new PointEntity
                    {
                        PositionText = ruleParameters[0],
                        PositionLetter = ruleParameters[0].ElementAt(indexOfPositionChar),
                        Values = positionPoints
                    });
                }
            }
        }

        
        public abstract BasePlayer MapPlayerToObject(string[] line);
        public abstract BasePlayer FindMvp();

    }
}
