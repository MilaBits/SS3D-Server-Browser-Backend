namespace ss3d_server_browser_shared.Models.Servers
{
    public class GameServerData
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string TagLine { get; set; }

        public virtual string Address { get; set; }
        public virtual int GamePort { get; set; }
        public virtual int QueryPort { get; set; }

        public virtual int Players { get; set; }
        public virtual int MaxPlayers { get; set; }

        public virtual string RoundStatus { get; set; }
        public virtual int RoundStartTime { get; set; }

        public virtual string Map { get; set; }
        public virtual string Gamemode { get; set; }

        public virtual string Game { get; set; }
        public virtual string Branch { get; set; }
        public virtual string Version { get; set; }

        public virtual string DownloadUrl { get; set; }

        public GameServerData(int id, string name, string tagLine, string address, int gamePort, int queryPort,
            int players, int maxPlayers, string roundStatus, int roundStartTime, string map, string gamemode,
            string game, string branch, string version, string downloadUrl)
        {
            Id = id;
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
            DownloadUrl = downloadUrl;
        }
    }
}