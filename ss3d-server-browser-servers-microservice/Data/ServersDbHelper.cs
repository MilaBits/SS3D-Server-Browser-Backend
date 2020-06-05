using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ss3d_server_browser_shared.Models.Servers;

namespace ss3d_server_browser_servers_microservice.Data
{
    public class ServersDbHelper
    {
        private ILogger _logger;

        public ServersDbHelper(ILogger logger) => this._logger = logger;

        public GameServerData[] Get(RpcDataServersRequest request) => Get(request.StartIndex, request.Count);

        public GameServerData[] Get(int startIndex, int count)
        {
            using (var context = new GameServerDataContext())
            {
                try
                {
                    var query = context.GameServerData
                        .OrderByDescending(x => x.Players)
                        .Skip(startIndex).Take(count);

                    return query.ToArray();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "[x] Failed to get data from db");
                }
            }

            return null;
        }
    }
}