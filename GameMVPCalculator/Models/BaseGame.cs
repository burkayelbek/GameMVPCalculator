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

        public BasePlayer FindMvp()
        {
            if (!Players.Any())
                throw new Exception("Can't find MVP since there are no players");

            foreach (BasePlayer player in Players)
            {
                PointEntity pointToUse = Points.First(p => p.PositionLetter == player.Position);
                player.TotalScore = CalculateMvp(player, pointToUse);
            }

            return Players.MaxBy(p => p.TotalScore);
        }

        public string FindWinnerTeam()
        {
            var groupedTeams = Players.GroupBy(p => new
            {
                p.Team
            }).Select(g => new
            {
                Team = g.Key.Team,
                Metric = g.Sum(player => WinnerTeamMetric(player))
            }).ToList();

            return groupedTeams.MaxBy(gt => gt.Metric).Team.ToString();

        }

        /// <summary>
        /// Map the array of player parameters to the object.
        /// </summary>
        /// <param name="line"></param>
        /// <returns>mapped Baseplayer object</returns>
        public abstract BasePlayer MapPlayerToObject(string[] line);
        /// <summary>
        /// Sets the metric that will be used for determining which team should be the winner
        /// </summary>
        /// <param name="basePlayer"></param>
        /// <returns>decimal value to compare to the other teams</returns>
        public abstract decimal WinnerTeamMetric(BasePlayer basePlayer);
        /// <summary>
        /// Sets the formula that will be used for each player to calculate whom should be MVP
        /// </summary>
        /// <param name="basePlayer"></param>
        /// <param name="pointToUse"></param>
        /// <returns></returns>
        public abstract decimal CalculateMvp(BasePlayer basePlayer, PointEntity pointToUse);

    }
}
