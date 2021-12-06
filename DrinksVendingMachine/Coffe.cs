using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    class Coffe : Beverage
    {                
        public int CoffeTS { get; set; }                      
        
        public Coffe()
        {
            SugarTS = 1;
            CoffeTS = 2;
            HotWaterML = 200;
            HotMilkML = 50;
        }


        public Coffe(string name, int price, int sugarTS, int coffeTS, int hotWaterML, int hotmilkml)     
        {
            Cup = 1;
            SugarTS = sugarTS;
            CoffeTS = coffeTS;
            HotWaterML = hotWaterML;
            HotMilkML = hotmilkml;
            Name = name;
            Price = price;
        }

        public override string Prepare()
        {
            return "Mix & Grind High Quality Coffe Beans And Sugar\nAdding Hot Water..." +
                "\nAdd Hot Milk\nStirring...\nPlease Pick Your Cup Carfully";                    
        }
        public override string ToString()
        {
            return $"Name{Name}, Price{Price}";
        }
    }
}
