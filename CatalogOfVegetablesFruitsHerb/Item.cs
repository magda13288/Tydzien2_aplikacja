using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogOfVegetablesFruitsHerbs
{
    public class Item
    {
        public int ItemID { get; set; }
        public int IdType { get; set; }
        public int NameId { get; set; }
        public string FullName { get; set; }
        public int GroupId { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public string Opinion { get; set; }
    }
}
