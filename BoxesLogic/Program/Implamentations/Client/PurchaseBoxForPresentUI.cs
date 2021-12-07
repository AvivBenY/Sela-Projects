using BoxesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Program.Implamentations
{
    internal class PurchaseBoxForPresentUI : IUiScreen
    {
        //Interface implementation for this screen
        //Get information from user and activate requested function through the manager
        public void Show()
        {
            double x = GetDouble("Please enter box base size:");
            double y = GetDouble("Please enter box height size:");
            int amount = Convert.ToInt32(GetDouble("How many boxes do you want to purchase:"));

            IEnumerable<string> errors;
            bool res = false;
            if (amount == 1) res = StaticInstances.LogicManager.BuyPartA(x, y, out errors);
            else res = StaticInstances.LogicManager.BuyPartB(x, y, amount, out errors);
            errors.ToList().ForEach(Console.WriteLine);
        }

        //Get sizes from user
        private double GetDouble(string message)
        {
            double size;
            Console.WriteLine(message);
            while (!double.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Invalid");
            }
            return size;
        }
    }
}