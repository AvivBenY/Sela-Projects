using BoxesLogic.Interfaces;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Implamentations
{
    class UiWelcomeScreen : IUiScreen
    {
        //Welcome screen message
        void TitleMessage()
        {
            Console.WriteLine("Hello & Welcome to Avivi's Box Factory!");
        }

        //Actions for this screen
        enum Actions
        {
            Client = 1,
            Expired_Boxes_Manual_Deletion,
            Warehouse_Manager,
            Show_Configuration,
            Quit
        }

        //Create table by actions names.
        private Actions GetAction()
        {
            ConsoleTable table = new ConsoleTable("#", "Action");
            int cnt = 1;
            Enum.GetNames(typeof(Actions)).ToList().ForEach(a => table.AddRow(cnt++, a.Replace('_', ' ')));
            table.Write(Format.Alternative);            
            Actions action;
            while(!Enum.TryParse<Actions>(Console.ReadLine(), out action))
            {
                Console.WriteLine("Invalid");
            }
            return action;
        }

        //Inteface implementation, move to requested screens or quit.
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.White;
            IUiScreen screen;
            while (true)
            {
                TitleMessage();
                switch (GetAction())
                {
                    case Actions.Client:
                        screen = new ClientUI(); 
                        break;
                    case Actions.Expired_Boxes_Manual_Deletion:
                        StaticInstances.LogicManager.ExperationCaller(null); continue;
                    case Actions.Warehouse_Manager:
                        screen = new WarehouseUI();
                        break;
                    case Actions.Show_Configuration:
                        screen = new ShowConfiguration();
                        break;
                    case Actions.Quit:
                        return;
                    default:
                        Console.WriteLine("Invalid Action"); 
                        continue;
                }
                
                screen.Show();
            }
        }        
    }
}
