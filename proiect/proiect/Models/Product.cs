using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace proiect.Models
{

    public class Burger //defineste un model Product care va fi folosit pentru a adauga produse in lista de cumparaturi
        {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string Name { get; set; }
             public float Price { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }

        [OneToMany] // pentru a modela relatia de tip 1-n cu ListProduct
            public List<ListProduct> ListProducts { get; set; }
       
        }
    
}
