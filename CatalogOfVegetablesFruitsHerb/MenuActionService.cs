using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogOfVegetablesFruitsHerbs
{
    public class MenuActionService
    {
        private List<MenuAction> menuActions;
        Messages message = new Messages();

        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }

        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menuAction = new MenuAction(id, name) { MenuName = menuName };
            menuActions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionByName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in menuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }

            return result;

        }
        public ConsoleKeyInfo AddNewMenuView(MenuActionService actionService, string menuName, out string name)
        {
            var addNewItemMenu = actionService.GetMenuActionByName(menuName);
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}.{addNewItemMenu[i].Name}");
            }

            var readKey = Console.ReadKey();

            var id = addNewItemMenu.Find(e => e.Id == int.Parse(readKey.KeyChar.ToString()));

            if (id == null)
            {
                Console.WriteLine();
                Console.WriteLine(message._ERROR);
                name = null;
            }
            else
                name = id.Name;

            return readKey;
        }
        public ConsoleKeyInfo LoadMenu(MenuActionService actionService, string message, string menuName, out string name)
        {
            Console.WriteLine(message);
            Console.WriteLine();

            var mainMenu = actionService.GetMenuActionByName(menuName);
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id}.{mainMenu[i].Name}");
            }

            var readKey = Console.ReadKey();
            Console.WriteLine();

            var id = mainMenu.Find(e => e.Id == int.Parse(readKey.KeyChar.ToString()));
            name = id.Name;

            return readKey;
        }
        public ConsoleKeyInfo ShowMenu(MenuActionService actionService, string message, string menuName)
        {
            Console.WriteLine(message);
            Console.WriteLine();
            var mainMenu = actionService.GetMenuActionByName(menuName);
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id}.{mainMenu[i].Name}");
            }

            var readKey = Console.ReadKey();
            Console.WriteLine();

            return readKey;

        }
    }
}
