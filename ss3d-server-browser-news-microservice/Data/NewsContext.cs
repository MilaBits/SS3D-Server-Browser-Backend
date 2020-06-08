using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ss3d_server_browser_shared.Models.News;
using ss3d_server_browser_shared.Models.Servers;

namespace ss3d_server_browser_news_microservice.Data
{
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; set; }

        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public NewsContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                string connectionString = configuration.GetConnectionString("NewsDatabase");
                optionsBuilder.UseMySql(connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BelongingServer).IsRequired();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.SubTitle).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.MarkdownContent).IsRequired();
            });
        }
    }
}