using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ss3d_server_browser_shared.Models.News;
using Utf8Json;

namespace ss3d_server_browser_gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController
    {
        //TODO: Re-enable cors 
        // [EnableCors(Startup.ElectronClientPolicy)]
        [HttpGet]
        public IEnumerable<News> Get()
        {
            RpcClient rpcClient = new RpcClient();

            Console.WriteLine(" [x] Requesting news");

            RpcDataNewsRequest requestObject = new RpcDataNewsRequest
            {
                Server = -1,
                Category = "",
                StartIndex = 0,
                Count = 10
            };
            string request = JsonSerializer.ToJsonString(requestObject);
            string response = rpcClient.Call(request, "rpc.getnews");

            RpcDataNewsResponse rpcDataNews;
            try
            {
                rpcDataNews = JsonSerializer.Deserialize<RpcDataNewsResponse>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine($" [.] failed to parse json: {e.Message}");
                return null;
            }

            Console.WriteLine($" [.] Got '{rpcDataNews.News}'");

            rpcClient.Close();
            return rpcDataNews.News;
        }
    }
}