namespace SS3D_Server_Browser_Server.Data
{
    public class GameServerData
    {
        public string Name { get; set; }
        public string TagLine { get; set; }

        public string Address { get; set; }
        public int GamePort { get; set; }
        public int QueryPort { get; set; }

        public int Players { get; set; }
        public int MaxPlayers { get; set; }

        public string RoundStatus { get; set; }
        public int RoundStartTime { get; set; }

        public string Map { get; set; }
        public string Gamemode { get; set; }

        public string Game { get; set; }
        public string Branch { get; set; }
        public string Version { get; set; }

        public GameServerData(string name, string address, int gamePort, int queryPort, int players,
            string roundStatus, int roundStartTime, string game)
        {
            Name = name;
            Address = address;
            GamePort = gamePort;
            QueryPort = queryPort;
            Players = players;
            RoundStatus = roundStatus;
            RoundStartTime = roundStartTime;
            Game = game;
        }


        public GameServerData(string name, string tagLine, string address, int gamePort, int queryPort, int players,
            int maxPlayers, string roundStatus, int roundStartTime, string map, string gamemode, string game,
            string branch, string version)
        {
            Name = name;
            TagLine = tagLine;
            Address = address;
            GamePort = gamePort;
            QueryPort = queryPort;
            Players = players;
            MaxPlayers = maxPlayers;
            RoundStatus = roundStatus;
            RoundStartTime = roundStartTime;
            Map = map;
            Gamemode = gamemode;
            Game = game;
            Branch = branch;
            Version = version;
        }
    }
}