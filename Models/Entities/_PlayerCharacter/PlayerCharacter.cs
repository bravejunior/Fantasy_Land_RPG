using Models.Entities.Abilities;
using Models.Entities.Classes;
using Models.Images;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Characters
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





        public virtual ICollection<PlayerCharacterCapability> PlayerCharacterCapabilities { get; set; }
        public virtual ICollection<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }
        public virtual ICollection<Skill> Skills { get; } = new List<Skill>();


        public virtual Portrait Portrait { get; set; }
        public int PortraitId { get; set; }


        public int ProfessionId { get; set; }
        [ForeignKey(nameof(ProfessionId))]
        public virtual Profession Profession { get; set; }


        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

    }
}
