using BoxesLogic.Interfaces;
using ConsoleTables;
using System;
using System.Linq;

namespace Program.Implamentations
{
    internal class WarehouseUI : IUiScreen
    {
        //Actions in the current screen.
        enum Actions
        {
            Stock = 1,
            AddToStock,
            FindBox,
            Back
        }

        //Create table by actions names.
        private Actions GetAction()
        {
            ConsoleTable table = new ConsoleTable("#", "Action");
            int cnt = 1;
            Enum.GetNames(typeof(Actions)).ToList().ForEach(a => table.AddRow(cnt++, a.Replace('_', ' ')));
            table.Write(Format.Default);

            Actions action;
            while (!Enum.TryParse<Actions>(Console.ReadLine(), true, out action))
            {
                Console.WriteLine("Invalid");
            }
            return action;
        }

        //Interface implementation
        public void Show()
        {
            IUiScreen screen;
            while (true)
            {
                switch (GetAction())
                {
                    case Actions.Stock:
                        screen = new StockShow(); break;
                    case Actions.AddToStock:
                        screen = new AddToStock(); break;
                    case Actions.FindBox:
                        screen = new FindBox(); break;
                    case Actions.Back:
                        return;
                    default:
                        Console.WriteLine("Invalid"); continue;
                }
                screen.Show();
            }            
        }
    }
}