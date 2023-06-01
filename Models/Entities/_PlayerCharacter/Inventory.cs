namespace Models.Entities._PlayerCharacter
{
    public class Inventory
    {
        public int Id { get; set; }
        public float WeightLimit { get; set; }
        public int Quantity { get; set; }



        //character id
        public string PlayerCharacterId { get; set; }
        public PlayerCharacter PlayerCharacter { get; set; }


        public int ItemId { get; set; }
        public _Item.Item Item { get; set; }
    }
}
