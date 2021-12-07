using BoxesLogic;
using Program.Implamentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    //Define static manager in order to activate functions using the UI system
    static class StaticInstances
    {
        public static Manager LogicManager { get;}        
        static StaticInstances()
        {
            LogicManager = new Manager(new UserInteractions());
        }
    }
}
