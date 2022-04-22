using System;

namespace CatalogOfVegetablesFruitsHerbs
{
    public class Program
    {
        static void Main(string[] args)
        {

            CatalogService catalogServie = new CatalogService();
            catalogServie.Start();
        }
    }
}
