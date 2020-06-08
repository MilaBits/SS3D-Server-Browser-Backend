using System.Collections.Generic;
using System.Linq;
using ss3d_server_browser_shared.Models.News;

namespace ss3d_server_browser_news_microservice.Data
{
    public class DbInitializer
    {
        public static void Initialize(NewsContext context)
        {
            context.Database.EnsureCreated();

            if (context.News.Any()) return;

            List<News> mockData = new List<News>
            {
                new News
                {
                    Id = 0,
                    BelongingServer = -1,
                    Title = "Title",
                    SubTitle = "Subtitle",
                    Category = "Testing",
                    MarkdownContent = "Beep boop buncha text"
                },
                new News
                {
                    Id = 0,
                    BelongingServer = -1,
                    Title = "Title",
                    SubTitle = "Subtitle",
                    Category = "Testing",
                    MarkdownContent = "Beep boop buncha text"
                },
                new News
                {
                    Id = 0,
                    BelongingServer = -1,
                    Title = "Title",
                    SubTitle = "Subtitle",
                    Category = "Testing",
                    MarkdownContent = "Beep boop buncha text"
                }
            };
            
            context.News.AddRange(mockData);
            context.SaveChanges();
        }
    }
}