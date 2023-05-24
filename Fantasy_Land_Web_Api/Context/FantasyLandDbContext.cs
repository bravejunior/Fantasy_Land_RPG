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

        public DbSet<CharacterClass> CharacterClasses { get; set; }

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

            modelBuilder.Entity<Knight>().HasData(new Knight {Id = 1, Name = "Knight", Description = "Default knight", CharismaBonus = 1 });
            modelBuilder.Entity<Guardian>().HasData(new Guardian {Id = 2, Name = "Guardian", Description = "Defensive knight", DefenceBonus = 1, DamagePenalty = -1 });
            modelBuilder.Entity<Berserker>().HasData(new Berserker {Id = 3, Name = "Berserker", Description = "Offensive knight", DamageBonus = 1, DefencePenalty = -1 });

            modelBuilder.Entity<CharacterClass>()
                .HasMany(c => c.Characters)
                .WithOne(e => e.CharacterClass)
                .IsRequired();

            //modelBuilder.Entity<CharacterClass>().ToTable("CharacterClasses");

            //modelBuilder.Entity<Character>()
            //    .HasOne(c => c.Owner)
            //    .WithMany(c => c.Characters)
            //    .HasForeignKey(p => p.OwnerId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
