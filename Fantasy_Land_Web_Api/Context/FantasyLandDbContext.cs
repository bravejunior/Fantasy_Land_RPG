using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entities;
using Models.Entities._Ability;
using Models.Entities._Item;
using Models.Entities._PlayerCharacter;
using Models.Entities._Profession;
using Models.Entities.Token_management;
using Models.Images;

namespace Fantasy_Land_Web_Api.Context
{
    public class FantasyLandDbContext : IdentityDbContext<User>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<PlayerCharacter> Characters { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Npc> Npcs { get; set; }
        public DbSet<Models.Entities._Ability.Attribute> Attributes { get; set; }
        public DbSet<PlayerCharacterCapability> PlayerCharacterCapabilities { get; set; }
        public DbSet<PlayerCharacterAttribute> PlayerCharacterAttributes { get; set; }
        public DbSet<PlayerCharacterSkill> PlayerCharacterSkills { get; set; }
        public DbSet<Capability> Capabilities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemLocation> ItemLocations { get; set; }
        public DbSet<ItemRequirement> ItemRequirements { get; set; }
        public DbSet<ItemStat> ItemStats { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentSlot> EquipmentSlots { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ProfessionProgression> ProfessionProgressions { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Portrait> Portraits { get; set; }


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

            modelBuilder.Entity<Ability>()
                .HasOne(a => a.ProfessionProgression)
                .WithOne(pp => pp.Ability)
                .HasForeignKey<Ability>(a => a.ProfessionProgressionId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Profession>().HasData(new Profession { Id = 1, Name = "", Description = "" });
            //modelBuilder.Entity<Profession>().HasData(new Profession { Id = 1, Name = "", Description = "" });

        }
    }
}
