using BoxesLogic.Interfaces;
using System;

namespace Program.Implamentations
{
    //Finds specific box.
    internal class FindBox : IUiScreen
    {
        public void Show()
        {
            double x = GetDouble("Please enter box base size:");
            double y = GetDouble("Please enter box height size:");
            StaticInstances.LogicManager.FindAndPrintBox(x, y);
            Console.WriteLine("Here's what we found.");            
        }
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