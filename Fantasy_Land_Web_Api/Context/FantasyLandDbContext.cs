using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entities;
using Models.Entities.Abilities;
using Models.Entities.Characters;
using Models.Entities.Classes;
using Models.Entities.Token_management;
using Models.Images;

namespace Fantasy_Land_Web_Api.Context
{
    public class FantasyLandDbContext : IdentityDbContext<User>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<PlayerCharacter> Characters { get; set; }

        public DbSet<Profession> CharacterClasses { get; set; }

        public DbSet<Portrait> Portraits { get; set; }

        public DbSet<Npc> Npcs { get; set; }

        public DbSet<PlayerCharacterCapability> PlayerCharacterCapabilities { get; set; }

        public DbSet<Capability> Capabilities { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }



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

            modelBuilder.Entity<PlayerCharacterCapability>()
                .HasKey(pc => new { pc.PlayerCharacterID, pc.CapabilityID });
            modelBuilder.Entity<PlayerCharacterCapability>()
                .HasOne(pc => pc.PlayerCharacter)
                .WithMany(pc => pc.PlayerCharacterCapabilities)
                .HasForeignKey(pc => pc.PlayerCharacterID);
            modelBuilder.Entity<PlayerCharacterCapability>()
                .HasOne(pc => pc.Capability)
                .WithMany(pc => pc.PlayerCharacterCapabilities)
                .HasForeignKey(pc => pc.CapabilityID);

            modelBuilder.Entity<PlayerCharacterAbility>()
                .HasKey(pa => new { pa.PlayerCharacterID, pa.AbilityID });
            modelBuilder.Entity<PlayerCharacterAbility>()
                .HasOne(pa => pa.PlayerCharacter)
                .WithMany(pa => pa.PlayerCharacterAbilities)
                .HasForeignKey(pa => pa.PlayerCharacterID);
            modelBuilder.Entity<PlayerCharacterAbility>()
                .HasOne(pa => pa.Ability)
                .WithMany(pa => pa.PlayerCharacterAbilities)
                .HasForeignKey(pa => pa.AbilityID);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Knight>().HasData(new Knight { Id = 1, Name = "Knight", Description = "Default knight", CharismaBonus = 1 });
            //modelBuilder.Entity<Guardian>().HasData(new Guardian { Id = 2, Name = "Guardian", Description = "Defensive knight", DefenceBonus = 1, DamagePenalty = -1 });
            //modelBuilder.Entity<Berserker>().HasData(new Berserker { Id = 3, Name = "Berserker", Description = "Offensive knight", DamageBonus = 1, DefencePenalty = -1 });

            modelBuilder.Entity<PlayerCharacter>()
                .HasOne(c => c.Portrait)
                .WithMany(p => p.Characters)
                .HasForeignKey(c => c.PortraitId);

            modelBuilder.Entity<PlayerCharacter>()
                .HasOne(c => c.CharacterClass)
                .WithMany(p => p.Characters)
                .HasForeignKey(c => c.CharacterClassId)
                .IsRequired(true);

            modelBuilder.Entity<Npc>()
                .HasOne(n => n.Portrait)
                .WithMany()
                .HasForeignKey(n => n.PortraitId);

            modelBuilder.Entity<Portrait>()
                .HasOne(p => p.CharacterClass)
                .WithMany(c => c.Portraits)
                .HasForeignKey(p => p.CharacterClassId)
                .IsRequired(false);
        }
    }
}
