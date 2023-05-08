using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;

namespace Fantasy_Land_Web_Api.Context
{
    public class FantasyLandDbContext : IdentityDbContext<User>
    {

        public DbSet<Character> Characters { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public FantasyLandDbContext(DbContextOptions<FantasyLandDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("SqlConnection");
                optionsBuilder.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
