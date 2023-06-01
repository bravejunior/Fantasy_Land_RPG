using Models.Entities._Item;

namespace Models.Entities._PlayerCharacter
{
    public class Equipment
    {
        public int Id { get; set; }


        //item id
        public int ItemId { get; set; }
        public Item Item { get; set; }


        //character id
        public string PlayerCharacterId { get; set; }
        public PlayerCharacter PlayerCharacter { get; set; }


        //equipment slot id
        public int EquipmentSlotId { get; set; }
        public EquipmentSlot EquipmentSlot { get; set; }

    }
}
