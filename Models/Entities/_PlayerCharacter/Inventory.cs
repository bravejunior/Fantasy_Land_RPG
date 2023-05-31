using Models.Entities.Characters;
using Models.Entities.Item;

namespace Models.Entities.Character
{
    public class Inventory
    {
        public int Id { get; set; }
        //item id
        public int Quantity { get; set; }



        //character id
        public int PlayerCharacterId { get; set; }
        public PlayerCharacter PlayerCharacter { get; set; }


        public int ItemId { get; set; }
        public Models.Entities.Item.Item Item { get; set; }
    }
}
