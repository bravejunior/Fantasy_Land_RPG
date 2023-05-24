using Models.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Character
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public string Id { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public string CharacterName { get; set; }
        public string Gender { get; set; }
        public int Strength { get; set; }
        public int Constitution { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public bool IsSelected { get; set; }


        public virtual CharacterClass CharacterClass { get; set; }
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

    }
}
