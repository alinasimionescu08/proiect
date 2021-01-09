using SQLite;

namespace proiect
{
    public class ShopList
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }





    }
}
