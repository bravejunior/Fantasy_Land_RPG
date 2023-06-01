using Models.Entities._PlayerCharacter;
using Models.Entities._Profession;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models.Images
{
    public class Portrait
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }




        public int? CharacterClassId { get; set; }
        [JsonIgnore]
        public virtual Profession? CharacterClass { get; set; }

        [JsonIgnore]
        public virtual ICollection<PlayerCharacter> Characters { get; set; }

    }
}
