﻿// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using ss3d_server_browser_shared;
//
// namespace ss3d_server_browser_servers_microservice.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class ServersList : ControllerBase
//     {
//         private static readonly string[] Summaries = new[]
//         {
//             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//         };
//
//         private readonly ILogger<ServersList> _logger;
//
//         public ServersList(ILogger<ServersList> logger)
//         {
//             _logger = logger;
//         }
//
//         [HttpGet]
//         public IEnumerable<GameServerData> Get()
//         {
//             var rng = new Random();
//             return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//                 {
//                     Date = DateTime.Now.AddDays(index),
//                     TemperatureC = rng.Next(-20, 55),
//                     Summary = Summaries[rng.Next(Summaries.Length)]
//                 })
//                 .ToArray();
//         }
//     }
// }