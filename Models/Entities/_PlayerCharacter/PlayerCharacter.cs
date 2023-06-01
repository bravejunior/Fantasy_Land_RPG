using Models.Entities._Ability;
using Models.Entities._Profession;
using Models.Images;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities._PlayerCharacter
{
    public class PlayerCharacter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int CurrentPerseverance { get; set; }
        public int MaxPerseverance { get; set; }
        public byte[] Portrait { get; set; }





        public virtual ICollection<PlayerCharacterCapability> PlayerCharacterCapabilities { get; set; }
        //public virtual ICollection<ProfesssionAbility> PlayerCharacterAbilities { get; set; }
        public virtual ICollection<PlayerCharacterAttribute> PlayerCharacterAttributes { get; set; }

        public virtual ICollection<PlayerCharacterSkill> PlayerCharacterSkills { get; set; }
        //public virtual ICollection<Ability> Skills { get; } = new List<Ability>();

        public int FactionId { get; set; }
        [ForeignKey(nameof(FactionId))]
        public virtual Faction Faction { get; set; }

        public int ProfessionId { get; set; }
        [ForeignKey(nameof(ProfessionId))]
        public virtual Profession Profession { get; set; }


        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

    }
}
