using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ss3d_server_browser_shared.Models.News;

namespace ss3d_server_browser_news_microservice.Data
{
    public class NewsDbHelper
    {
        private ILogger _logger;

        public NewsDbHelper(ILogger logger) => _logger = logger;

        public News[] Get(RpcDataNewsRequest request)
        {
            IQueryable<News> query = null;

            News[] result = null;

            try
            {
                using (var context = new NewsContext())
                {
                    query = context.News.Where(x => x.Id != -1);

                    if (!string.IsNullOrWhiteSpace(request.Category))
                        query = query.Where(x => x.Category == request.Category);
                    if (request.Server >= 0)
                        query = context.News.Where(x => x.BelongingServer == request.Server);
                    query = query.OrderByDescending(x => x.Date)
                        .Skip(request.StartIndex).Take(request.Count);

                    result = query.ToArray();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[x] failed to get news");
            }

            return result;
        }
    }
}