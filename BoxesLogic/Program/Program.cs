using BoxesLogic;
using BoxesLogic.Interfaces;
using Program.Implamentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Program
{
    class Program
    {               
        static void Main(string[] args)
        {            
            RunUI();
        }        

        //Generate stock
        private static void RunUI()
        {
            var manager = StaticInstances.LogicManager;
            manager.AddToStock(1, 1, 3);
            manager.AddToStock(3, 1, 3);
            manager.AddToStock(4, 3, 3);
            manager.AddToStock(4, 4, 3);
            new UiWelcomeScreen().Show();
        }
    }
}

