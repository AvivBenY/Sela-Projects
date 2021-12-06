using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Transcoding;
using Windows.UI.Xaml.Documents;

namespace DrinksVendingMachine
{
    abstract class Beverage
    {
        public int SugarTS { get; set; }        
        public int HotWaterML { get; set; }
        public int HotMilkML { get; set; }        
        public string Name { get; set; }
        public int Price { get; set; }
        public int Cup { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Beverage drink)
            {
                return Name == drink.Name;                
            }
            if (obj.GetType() != typeof(Beverage))
            {
                throw new ArgumentException("This Object Is Not A Beverage!");                                
            }
            return false;
        }        

        //7:29:00 in recording
        abstract public string Prepare();

        abstract public override string ToString();        
    }
}
