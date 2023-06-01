using Models.Entities;
using Models.Entities._Ability;

namespace Models.DTOs
{
    public class CharacterCreationDto
    {
        public string CharacterName { get; set; }
        public string Gender { get; set; }
        public List<string> AttributeNames { get; set; }
        public Dictionary<string, int> AttributePoints { get; set; }
        public List<string> CapabilityNames { get; set; }
        public Dictionary<string, int> CapabilityPoints { get; set; }
        public List<string> SkillNames { get; set; }
        public Dictionary<string, int> SkillPoints { get; set; }

        public virtual ICollection<PlayerCharacterCapability> PlayerCharacterCapabilities { get; set; }
        public virtual ICollection<PlayerCharacterAttribute> PlayerCharacterAttributes { get; set; }
        public virtual ICollection<Ability> Skills { get; } = new List<Ability>();

        public virtual Faction? Faction { get; set; }




        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public string ProfessionName { get; set; }
        public string Username { get; set; }
        public int CurrentPerseverance { get; set; }
        public int MaxPerseverance { get; set; }
        public byte[] Portrait { get; set; }
    }
}
