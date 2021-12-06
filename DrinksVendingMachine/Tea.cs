using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    class Tea : Beverage
    {        
        public int EnglishTeaScaldingBag { get; set; }       
        public int LemonTeaScaldingBag { get; set; }       
        public int MinthTeaScaldingBag { get; set; }       
        public int AvivizTeaScaldingBag { get; set; }           
        public Tea()
        {
            SugarTS = 2;
            HotWaterML = 250;
            EnglishTeaScaldingBag = 1;
            HotMilkML = 0;
        }

        public Tea(string name, int price, int sugarTS, int hotWaterML, int englishteascaldingBag 
           ,int lemonteascaldingbag,int minthteascaldingbag, int avivizteascaldingbag)
        {
            Cup = 1;
            SugarTS = sugarTS;
            HotWaterML = hotWaterML;
            EnglishTeaScaldingBag = englishteascaldingBag;                     
            LemonTeaScaldingBag =   lemonteascaldingbag;
            MinthTeaScaldingBag =   minthteascaldingbag;
            AvivizTeaScaldingBag =  avivizteascaldingbag;
            Name = name;
            Price = price;
        }

        public override string Prepare()
        {            
            return "Mixing High Quality Tea Leaf Scalde And Sugar\nAdding Hot Water..." +
                "\nStirring...\n Please Pick Your Cup Carfully";
        }
        public override string ToString()
        {
            return $"Name{Name}, Price{Price}";
        }
    }
}
