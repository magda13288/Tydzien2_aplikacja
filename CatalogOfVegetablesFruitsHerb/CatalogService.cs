using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogOfVegetablesFruitsHerbs
{
    public class CatalogService
    {
        public void Start()
        {
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            ItemService vegetableService = new ItemService();
            ItemService fruitsService = new ItemService();
            ItemService herbsService = new ItemService();

            Messages message = new Messages();

            ConsoleKeyInfo keyInfoPlantMain, readKey;
            string name;

            Console.WriteLine(message._WELCOME_MESSAGE);
            Console.WriteLine();

            while (true)
            {
                readKey = actionService.ShowMenu(actionService, message._WHAT_DO, message._MAIN);

                switch (readKey.KeyChar)
                {
                    case '1':

                        Console.WriteLine();
                        Console.WriteLine(message._WHAT_ADD);
                        Console.WriteLine();
                        //IdType /Vege/Fruit/Herb
                        keyInfoPlantMain = actionService.AddNewMenuView(actionService, message._PLANT_MENU, out name);
                        Console.WriteLine();

                        switch (keyInfoPlantMain.KeyChar)
                        {
                            case '1':
                                
                                vegetableService.AddItem(actionService,vegetableService, name, keyInfoPlantMain, message._VEGE_WHAT, message._VEGE_NAME);

                                break;
                            case '2':

                                fruitsService.AddItem(actionService, fruitsService, name, keyInfoPlantMain, message._FRUIT_WHAT, message._FRUIT_NAME);

                                break;
                            case '3':
                
                                herbsService.AddItem(actionService, herbsService, name, keyInfoPlantMain, message._HERB_WHAT, null);
                                break;
                        }

                        break;

                    case '2':

                        Console.WriteLine();
                        Console.WriteLine(message._WHAT_EDIT);
                        Console.WriteLine();

                        keyInfoPlantMain = actionService.AddNewMenuView(actionService, message._PLANT_MENU, out name);
                        Console.WriteLine();

                        switch (keyInfoPlantMain.KeyChar)
                        {
                            case '1':

                                vegetableService.Edit();

                                break;
                            case '2':

                                fruitsService.Edit();

                                break;
                            case '3':

                                herbsService.Edit();
                                break;                      
                        }

                        break;

                    case '3':

                        Console.WriteLine();
                        Console.WriteLine(message._WHAT_REMOVE);
                        Console.WriteLine();

                        keyInfoPlantMain = actionService.AddNewMenuView(actionService, message._PLANT_MENU, out name);
                        Console.WriteLine();

                        switch (keyInfoPlantMain.KeyChar)
                        {
                            case '1':

                                vegetableService.Remove();

                                break;
                            case '2':

                                fruitsService.Remove();

                                break;
                            case '3':

                                herbsService.Remove();
                                break;                      
                        }
                   
                        break;

                    case '4':

                        Console.WriteLine();
                        Console.WriteLine(message._WHAT_SEARCH);
                        Console.WriteLine();

                        keyInfoPlantMain = actionService.AddNewMenuView(actionService, message._PLANT_MENU, out name);
                        Console.WriteLine();

                        switch (keyInfoPlantMain.KeyChar)
                        {
                            case '1':

                                vegetableService.SearchByName();

                                break;
                            case '2':

                                fruitsService.SearchByName();

                                break;
                            case '3':

                                herbsService.SearchByName();
                                break;                           
                        }
                        break;
                        
                    case '5':

                        Console.WriteLine();
                        Console.WriteLine(message._WHAT_SEARCH);
                        Console.WriteLine();

                        keyInfoPlantMain = actionService.AddNewMenuView(actionService, message._PLANT_MENU, out name);
                        Console.WriteLine();

                        switch (keyInfoPlantMain.KeyChar)
                        {
                            case '1':

                                vegetableService.ShowAllItems(actionService, message._VEGE_SEARCH, name, message._VEGE_NAME_SEARCH, keyInfoPlantMain);
  
                                break;
                            case '2':

                                fruitsService.ShowAllItems(actionService, message._FRUIT_SEARCH, name, message._FRUIT_NAME_SEARCH, keyInfoPlantMain);
                                break;
                            case '3':
                                
                                herbsService.ShowAllItems(actionService, message._HERB_SEARCH,name, null, keyInfoPlantMain);

                                break;
                            default:
                                Console.WriteLine(message._ERROR);
                                Console.WriteLine();
                                break;
                        }
                        break;                
                }
            }
        }
        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add", "Main");
            actionService.AddNewAction(2, "Edit", "Main");
            actionService.AddNewAction(3, "Remove", "Main");
            actionService.AddNewAction(4, "Search by name", "Main");
            actionService.AddNewAction(5, "View all", "Main");

            actionService.AddNewAction(1, "Vegetable", "PlantMenu");
            actionService.AddNewAction(2, "Fruit", "PlantMenu");
            actionService.AddNewAction(3, "Herb", "PlantMenu");

            actionService.AddNewAction(1, "Nightshade", "Vegetable");
            actionService.AddNewAction(2, "Cucurbits", "Vegetable");
            actionService.AddNewAction(3, "Legumes", "Vegetable");
            actionService.AddNewAction(4, "Cruciferous", "Vegetable");
            actionService.AddNewAction(5, "Leafy", "Vegetable");
            actionService.AddNewAction(6, "Onion", "Vegetable");
            actionService.AddNewAction(7, "Root", "Vegetable");
            actionService.AddNewAction(8, "Turnip greens", "Vegetable");


            actionService.AddNewAction(1, "Tomato", "Nightshade");
            actionService.AddNewAction(2, "Pepper", "Nightshade");
            actionService.AddNewAction(3, "Potato", "Nightshade");
            actionService.AddNewAction(4, "Eggplant", "Nightshade");
            actionService.AddNewAction(5, "Other", "Nightshade");

            actionService.AddNewAction(1, "Cucumber", "Cucurbits");
            actionService.AddNewAction(2, "Zucchini", "Cucurbits");
            actionService.AddNewAction(3, "Pumpkin", "Cucurbits");
            actionService.AddNewAction(4, "Patison", "Cucurbits");
            actionService.AddNewAction(5, "Other", "Cucurbits");

            actionService.AddNewAction(1, "Beans", "Legumes");
            actionService.AddNewAction(2, "Pea", "Legumes");
            actionService.AddNewAction(3, "Lentils", "Legumes");
            actionService.AddNewAction(4, "Broad bean", "Legumes");
            actionService.AddNewAction(5, "Other", "Legumes");

            actionService.AddNewAction(1, "Cabbage", "Cruciferous");
            actionService.AddNewAction(2, "Brussels sprouts", "Cruciferous");
            actionService.AddNewAction(3, "Broccoli", "Cruciferous");
            actionService.AddNewAction(4, "Cauliflower", "Cruciferous");
            actionService.AddNewAction(5, "Kohlrabi", "Cruciferous");
            actionService.AddNewAction(6, "Other", "Cruciferous");

            actionService.AddNewAction(1, "Lettuce", "Leafy");
            actionService.AddNewAction(2, "Spinach", "Leafy");
            actionService.AddNewAction(3, "Leaf parsley", "Leafy");
            actionService.AddNewAction(4, "Other", "Leafy");

            actionService.AddNewAction(1, "Onion", "Onion");
            actionService.AddNewAction(2, "Garlic", "Onion");
            actionService.AddNewAction(3, "Leek", "Onion");
            actionService.AddNewAction(4, "Other", "Onion");

            actionService.AddNewAction(1, "Carrot", "Root");
            actionService.AddNewAction(2, "Root parsley", "Root");
            actionService.AddNewAction(3, "Beetroot", "Root");
            actionService.AddNewAction(4, "Root celery", "Root");
            actionService.AddNewAction(5, "Other", "Root");

            actionService.AddNewAction(1, "Radish", "Turnip greens");
            actionService.AddNewAction(2, "Rutabaga", "Turnip greens");
            actionService.AddNewAction(3, "Turnip", "Turnip greens");
            actionService.AddNewAction(4, "Other", "Turnip greens");

            actionService.AddNewAction(1, "Pitted", "Fruit");
            actionService.AddNewAction(2, "Berry", "Fruit");
            actionService.AddNewAction(3, "Pome", "Fruit");
            actionService.AddNewAction(4, "Citrus", "Fruit");
            actionService.AddNewAction(5, "Exotic", "Fruit");

            actionService.AddNewAction(1, "Cherries", "Pitted");
            actionService.AddNewAction(2, "Peach", "Pitted");
            actionService.AddNewAction(3, "Plum", "Pitted");
            actionService.AddNewAction(4, "Apricot", "Pitted");
            actionService.AddNewAction(5, "Other", "Pitted");

            actionService.AddNewAction(1, "Strawberry", "Berry");
            actionService.AddNewAction(2, "Blackberries", "Berry");
            actionService.AddNewAction(3, "Blueberries", "Berry");
            actionService.AddNewAction(4, "Raspberries", "Berry");
            actionService.AddNewAction(5, "Currants", "Berry");
            actionService.AddNewAction(6, "Berries", "Berry");
            actionService.AddNewAction(7, "Other", "Berry");

            actionService.AddNewAction(1, "Apple", "Pome");
            actionService.AddNewAction(2, "Pear", "Pome");
            actionService.AddNewAction(3, "Quince", "Pome");
            actionService.AddNewAction(4, "Pomegranate ", "Pome");
            actionService.AddNewAction(5, "Other", "Pome");

            actionService.AddNewAction(1, "Lemon", "Citrus");
            actionService.AddNewAction(2, "Tangerine", "Citrus");
            actionService.AddNewAction(3, "Orange", "Citrus");
            actionService.AddNewAction(4, "Grapefruit", "Citrus");
            actionService.AddNewAction(5, "Other", "Citrus");

            actionService.AddNewAction(1, "Banana", "Exotic");
            actionService.AddNewAction(2, "Pineapple", "Exotic");
            actionService.AddNewAction(3, "Lychee", "Exotic");
            actionService.AddNewAction(4, "Other", "Exotic");

            actionService.AddNewAction(1, "Healing", "Herb");
            actionService.AddNewAction(2, "Spicy", "Herb");
            actionService.AddNewAction(3, "Essential oil", "Herb");

            return actionService;
        }
    }
}
