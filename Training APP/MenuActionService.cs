using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Training_APP
{
    public class MenuActionService
    {
        private List<MenuAction> menuActions;
        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }

        public void AddNewAction(int id, string name)
        {
            MenuAction menuAction = new MenuAction() { Id = id, Name = name };
            menuActions.Add(menuAction);
        }
        public List<MenuAction> MenuService()
        {
            foreach(var  menuAction in menuActions)
            {
                Console.WriteLine($"{menuAction.Id}{"."}{menuAction.Name}");
            }
            return menuActions;
        }
    }
}
