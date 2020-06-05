using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ss3d_server_browser_shared.Models.Servers;

namespace ss3d_server_browser_servers_microservice.Data
{
    public class GameServerDataContext : DbContext
    {
        public DbSet<GameServerData> GameServerData { get; set; }

        public GameServerDataContext(DbContextOptions<GameServerDataContext> options)
            : base(options)
        {
        }

        public GameServerDataContext()
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
                string connectionString = configuration.GetConnectionString("ServersDatabase");
                optionsBuilder.UseMySql(connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameServerData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.GamePort).IsRequired();
                entity.Property(e => e.QueryPort).IsRequired();
                entity.Property(e => e.Game).IsRequired();
                entity.Property(e => e.Branch).IsRequired();
                entity.Property(e => e.Version).IsRequired();
                entity.Property(e => e.DownloadUrl).IsRequired();
            });
        }
    }
}