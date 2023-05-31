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



        public int PortraitId { get; set; }
        public virtual Portrait Portrait { get; set; }


    }
}
