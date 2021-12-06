using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    class Chocolate : Beverage
    {        
        public int ChocolatePowderTS { get; set; }
        public int FrenchVanillaPowderTS { get; set; }
        public Chocolate()
        {
            SugarTS = 0;
            HotWaterML = 200;
            HotMilkML = 50;
            ChocolatePowderTS = 2; 
        }
        public Chocolate(string name, int price, int sugarTS, int hotWaterML, int hotMilkML, int chocolatePowderTS, int frenchvanillapowderts)             
        {
            Cup = 1;
            SugarTS = sugarTS;
            HotWaterML = hotWaterML;
            HotMilkML = hotMilkML;
            ChocolatePowderTS = chocolatePowderTS;
            FrenchVanillaPowderTS = frenchvanillapowderts;
            Name = name;
            Price = price;
        }

        public override string Prepare()
        {            
            return $"Adding High Quality Chocolate...\nAdding Hot Water..." +
                $"\nStirring...\n Please Pick Your Cup Carfully \n ";            
        }

        public override string ToString()
        {         
            return $"Name{Name}, Price{Price}";
        }
    
    }
}
