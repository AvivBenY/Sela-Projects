using BoxesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Program.Implamentations
{
    internal class AddToStock : IUiScreen
    {
        //Interface implementation, get sizes from user and add box through static instance "manager"
        public void Show()
        {
            double x = GetDouble("Please enter box base size:");
            double y = GetDouble("Please enter box height size:");
            int amount = Convert.ToInt32(GetDouble("How many boxes do you want to purchase:"));            
            StaticInstances.LogicManager.AddToStock(x, y, amount);
            Console.WriteLine("Box Added To Stock");
        }

        //Gets data from user
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