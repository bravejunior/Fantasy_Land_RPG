using Models.Images;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Npc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] Portrait { get; set; }




        public int FactionId { get; set; }
        [ForeignKey(nameof(FactionId))]
        public virtual Faction Faction { get; set; }

    }
}
