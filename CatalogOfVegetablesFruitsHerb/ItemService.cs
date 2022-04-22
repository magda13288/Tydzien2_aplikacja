using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogOfVegetablesFruitsHerbs
{
    public class ItemService
    {
        private List<Item> items;
        public ItemService()
        {
            items = new List<Item>();
        }

        Item item;
        int keyId;
        string name, outName;
        ConsoleKeyInfo readKeyItemGroupMenu, readKeyItemName;
        Messages message = new Messages();
        public void AddItem(MenuActionService actionService, ItemService itemService, string menuName, ConsoleKeyInfo key, string messageWhat, string messageName )
        {
            keyId = int.Parse(key.KeyChar.ToString());
          
            Console.WriteLine();
            //GroupId /psianka,dyniowate itd
            readKeyItemGroupMenu = actionService.LoadMenu(actionService, messageWhat, menuName, out name);
            Console.WriteLine();

            if (messageName == null)
            {
                AddNewItem(keyId, readKeyItemGroupMenu, readKeyItemName, null);
            }
            else
            {
                //NameId
                readKeyItemName = actionService.LoadMenu(actionService, messageName, name, out outName);

                AddNewItem(keyId, readKeyItemGroupMenu, readKeyItemName, outName);
            }            
        }
        public void AddNewItem(int keyTypeId, ConsoleKeyInfo keyGroupId, ConsoleKeyInfo keyNameId, string itemName)
        {
            item = new Item();
            item.ItemID = items.Count +1;
            item.IdType = keyTypeId;           
            item.GroupId = int.Parse(keyGroupId.KeyChar.ToString());

            if (keyNameId.KeyChar == '0')
                item.NameId = 0;
            else
            {
                item.NameId = int.Parse(keyNameId.KeyChar.ToString());
            }

            Console.Write("Enter name:");
            item.FullName = Console.ReadLine();

            if (item.IdType == 1)
            {
                if (itemName == "Tomato")
                {
                    Console.Write("Type (tall/dwarf/self-ending/coctail):");
                    item.Type = Console.ReadLine();
                }
                if (itemName == "Pepper")
                {
                    Console.Write("Type (round/oblong):");
                    item.Type = Console.ReadLine();
                }
                else
                {
                    item.Type = null;
                }

                Console.Write("Destination(ground/under cowers/pots):");
                item.Destination = Console.ReadLine();
            }
            if (item.IdType == 2)
            {
                Console.Write("Type (bush/tree/climbing/hanging):");
                item.Type = Console.ReadLine();
                Console.Write("Destination(ground/under cowers/pots):");
                item.Destination = Console.ReadLine();
            }

            if (item.IdType == 3)
            {
                Console.Write("Type (shrub,vine,root):");
                item.Type = Console.ReadLine();
                Console.Write("Destination(ground/under cowers/pots):");
                item.Destination = Console.ReadLine();
            }
            Console.Write("Color:");
            item.Color = Console.ReadLine();
            Console.Write("Description:");
            item.Description = Console.ReadLine();
            Console.Write("Please share your opinion about this plant with another users:");
            item.Opinion = Console.ReadLine();

            items.Add(item);
           
            Console.WriteLine("Plant added.");
            Console.WriteLine();

        }

        public void ShowAllItems(MenuActionService actionService, string messageWhat, string menuName, string messageItemName, ConsoleKeyInfo key)
        {           
            if (key.KeyChar == '3')
            {
                readKeyItemGroupMenu = actionService.ShowMenu(actionService, messageWhat, menuName);

                var find = items.FindAll(e => e.GroupId == int.Parse(readKeyItemGroupMenu.KeyChar.ToString()));

                if (find.Count != 0)
                {
                    findAllItems(find);
                }
                else
                    Console.WriteLine(message._EMPTY);
            }
            else
            {
                readKeyItemGroupMenu = actionService.LoadMenu(actionService, messageWhat, menuName, out name);

                readKeyItemName = actionService.LoadMenu(actionService, messageItemName, name, out name);


                var find = items.FindAll(e => e.GroupId == int.Parse(readKeyItemGroupMenu.KeyChar.ToString()) && e.NameId == int.Parse(readKeyItemName.KeyChar.ToString()));

                if (find.Count != 0)
                {
                    findAllItems(find);
                }
                else
                    Console.WriteLine(message._EMPTY);
            }
            Console.WriteLine();
        }

        public void SearchByName()
        {
            Console.Write("Enter name:");
            string name = Console.ReadLine();

            var find = items.Find(e => e.FullName == name);

            if (find != null)
            {
                Console.WriteLine();
                Console.WriteLine($"ID:{find.ItemID}");
                Console.WriteLine($"Name:{find.FullName}");
                Console.WriteLine($"Type:{find.Type}");
                Console.WriteLine($"Color:{find.Color}");
                Console.WriteLine($"Destination:{find.Destination}");
                Console.WriteLine($"Description:{find.Description}");
                Console.WriteLine($"Opinion:{find.Opinion}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(message._NO_RESULTS);
            }

            Console.WriteLine();
        }

        public void findAllItems(List<Item> find)
        {
            for (int i = 0; i < find.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"ID:{find[i].ItemID}");
                Console.WriteLine($"Name:{find[i].FullName}");
                Console.WriteLine($"Type:{find[i].Type}");
                Console.WriteLine($"Color:{find[i].Color}");
                Console.WriteLine($"Destination:{find[i].Destination}");
                Console.WriteLine($"Description:{find[i].Description}");
                Console.WriteLine($"Opinion:{find[i].Opinion}");
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        public void Remove()
        {
            Console.Write("Enter ID or name of plant what you want to remove:");
            string value = Console.ReadLine();
            Console.WriteLine();
            int id;

            if (int.TryParse(value, out id) == true)
            {
                var find = items.Find(e => e.ItemID == id);

                if (find == null)
                    Console.WriteLine(message._NO_RESULT_FIND);
                else
                {
                    items.Remove(find);
                    Console.WriteLine("Plant removed");
                }
            }
            else
            {
                var find = items.Find(e => e.FullName == value);
                if (find == null)
                    Console.WriteLine(message._NO_RESULT_FIND);
                else
                {
                    items.Remove(find);
                    Console.WriteLine("Plant removed");
                  
                }
            }
            Console.WriteLine();
        }
        public void Edit()
        {
            Console.Write("Enter ID or name of plant what you want to edit:");
            string value = Console.ReadLine();
            Console.WriteLine();
            int id;

            if (int.TryParse(value, out id) == true)
            {
                var find = items.Find(e => e.ItemID == id);
             
               EditItem(find);
                   
            }
            else
            {
                var find = items.Find(e => e.FullName == value);

                EditItem(find);               
            }
            Console.WriteLine();
        }
        public void EditItem(Item item)
        {
            if (item == null)
                Console.WriteLine(message._NO_RESULT_FIND);
            else
            {
                Console.Write("Enter name:");
                item.FullName = Console.ReadLine();
                if (item.IdType == 1)
            {
                if (item.NameId == 1)
                {
                    Console.Write("Type (tall/dwarf/self-ending/coctail):");
                    item.Type = Console.ReadLine();
                }
                if (item.NameId == 2)
                {
                    Console.Write("Type (round/oblong):");
                    item.Type = Console.ReadLine();
                }
                else
                {
                    item.Type = null;
                }

                Console.Write("Destination(ground/under cowers/pots):");
                item.Destination = Console.ReadLine();
            }
            if (item.IdType == 2)
            {
                Console.Write("Type (bush/tree/climbing/hanging):");
                item.Type = Console.ReadLine();
                Console.Write("Destination(ground/under cowers/pots):");
                item.Destination = Console.ReadLine();
            }

            if (item.IdType == 3)
            {
                Console.Write("Type (shrub,vine,root):");
                item.Type = Console.ReadLine();
                Console.Write("Destination(ground/under cowers/pots):");
                item.Destination = Console.ReadLine();
            }
            Console.Write("Color:");
            item.Color = Console.ReadLine();
            Console.Write("Description:");
            item.Description = Console.ReadLine();
            Console.Write("Enter your opinion about this plant:");
            item.Opinion = Console.ReadLine();

            Console.WriteLine("Plant edited");
            Console.WriteLine();
            }          
        }
    }
}
