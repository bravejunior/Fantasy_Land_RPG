using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entities;
using Models.Entities.Classes;
using Models.Entities.Token_management;

namespace Fantasy_Land_Web_Api.Context
{
    public class FantasyLandDbContext : IdentityDbContext<User>
    {

        public DbSet<Character> Characters { get; set; }

        public DbSet<Knight> Knights { get; set; }

        public DbSet<Berserker> Berserkers { get; set; }

        public DbSet<Guardian> Guardians { get; set; }

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
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CharacterClass>()
                .HasMany(c => c.Characters)
                .WithOne(e => e.CharacterClass)
                .IsRequired();

            modelBuilder.Entity<CharacterClass>().ToTable("CharacterClasses");

            //modelBuilder.Entity<Character>()
            //    .HasOne(c => c.Owner)
            //    .WithMany(c => c.Characters)
            //    .HasForeignKey(p => p.OwnerId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
