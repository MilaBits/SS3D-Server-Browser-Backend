using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SS3D_Server_Browser_Server.Data;

namespace SS3D_Server_Browser_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerListController
    {
        //TODO: Re-enable cors 
        // [EnableCors(Startup.ServersListPolicy)]
        [HttpGet]
        public IEnumerable<GameServerData> Get()
        {
            GameServerData[] result = new[]
            {
                new GameServerData("MillyStation",
                    "1.2.3.4", 1124, 4412,
                    12, "playing", 0,
                    "SS3D"),
                new GameServerData("abcStation PVP", "abcStation's PVP server for all the trigger-happy folks",
                    "1.2.3.4", 1124, 4412,
                    8, 16, "playing", 0, "BoxStation", "Free For All",
                    "SS3D", "abcStation", "0.1.4"),
                new GameServerData("abcStation LowRP", "abcStation's low RP server.",
                    "1.2.42.41", 1124, 4412,
                    15, 32, "playing", 0, "BoxStation", "Secret",
                    "SS3D", "abcStation", "0.1.4")
            };

            return result;
        }
    }
}