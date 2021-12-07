using BoxesLogic.Interfaces;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Implamentations
{
    //Functions to interact with user, grant premission to certain limitations
    class UserInteractions : IUserInteractions
    {
        public bool FinalRequestConfirmation(List<(double x, double y, int amount)> boxes)
        {
            var table = new ConsoleTable("x", "y", "amount");
            boxes.ForEach(b => table.AddRow(b.x, b.y, b.amount));
            Console.WriteLine("order:");
            table.Write(Format.Minimal);
            while (true)
            {
                Console.WriteLine("This is your order, would you like to approve it? \nY/N");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }            
        }
        public bool SizeExceedingConfirmation(List<(double x, double y, int amount)> boxes)
        {
            var table = new ConsoleTable("x", "y", "amount");
            boxes.ForEach(b => table.AddRow(b.x, b.y, b.amount));
            Console.WriteLine("order:");
            table.Write(Format.Minimal);
            while (true)
            {
                Console.WriteLine("Confirmation requested, \n Box size exceeded the limit of 400%\n" +
                            "Confirm or Abort.\n Y/N");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
        }       
        public bool NotEnoughBoxesInStockConfirmation(List<(double x, double y, int amount)> boxes)
        {
            var table = new ConsoleTable("x", "y", "amount");
            boxes.ForEach(b => table.AddRow(b.x, b.y, b.amount));
            Console.WriteLine("order:");
            table.Write(Format.Minimal);
            while (true)
            {
                Console.WriteLine("Confirmation requested,Were sorry, \nNot enough boxes in our stock at the momoent," +
                    " \nHere is what we could get for you,\n Y/N.");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
        }
        public void Notify(string s) => Console.WriteLine(s);       
    }
}
