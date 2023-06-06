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
        public string Gender { get; set; }
        public byte[] ImageData { get; set; }

    }
}
