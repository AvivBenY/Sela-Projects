using BoxesLogic.Interfaces;
using ConsoleTables;
using System;
using System.Linq;

namespace Program.Implamentations
{
    internal class ClientUI : IUiScreen
    {
        //Actions for this screen
        enum Actions
        {
            Purchase_Box_For_Present = 1,
            Back
        }

        //Create table by actions names.
        private Actions GetAction()
        {
            ConsoleTable table = new ConsoleTable("#", "Action");
            int cnt = 1;
            Enum.GetNames(typeof(Actions)).ToList().ForEach(a => table.AddRow(cnt++, a.Replace('_',' ')));
            table.Write(Format.Default);

            Actions action;
            while (!Enum.TryParse<Actions>(Console.ReadLine(),true, out action))
            {
                Console.WriteLine("Invalid");
            }
            return action;
        }

        //Inteface implementation, move from screen or purchase.
        public void Show()
        {
            IUiScreen screen;
            while(true)
            {
                switch (GetAction())
                {
                    case Actions.Purchase_Box_For_Present:
                        screen = new PurchaseBoxForPresentUI();
                        break;
                    case Actions.Back:
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