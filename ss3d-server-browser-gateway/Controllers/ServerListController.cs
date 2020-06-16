using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ss3d_server_browser_shared.Models.Servers;
using Utf8Json;

namespace ss3d_server_browser_gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerListController
    {
        //TODO: Re-enable cors 
        // [EnableCors(Startup.ElectronClientPolicy)]
        [HttpGet]
        public IEnumerable<GameServerData> Get()
        {
            RpcClient rpcClient = new RpcClient();

            Console.WriteLine(" [x] Requesting game servers");

            RpcDataServersRequest requestObject = new RpcDataServersRequest {StartIndex = 0, Count = 15};
            string request = JsonSerializer.ToJsonString(requestObject);
            string response = rpcClient.Call(request, "rpc.getservers");

            RpcDataServersResponse rpcDataServers;
            try
            {
                rpcDataServers = JsonSerializer.Deserialize<RpcDataServersResponse>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine($" [.] failed to parse json: {e.Message}");
                return null;
            }

            Console.WriteLine($" [.] Got '{rpcDataServers.GameServers}'");

            rpcClient.Close();
            return rpcDataServers.GameServers;
        }
    }
}