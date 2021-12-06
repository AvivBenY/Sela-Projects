using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace DrinksVendingMachine
{    
    class VendingMachine
    {
        private int SugarTS { get; set; }
        private int CoffeBeans { get; set; }
        private int EnglishteascaldingBag{ get; set; }
        private int Lemonteascaldingbag{ get; set; }
        private int Minthteascaldingbag{ get; set; }
        private int Avivizteascaldingbag{ get; set; }
        private int ChocolateMixPowderTS { get; set; }
        private int FrenchVanillaPowderTS { get; set; }
        private int MilkML { get; set; }
        private int Cups { get; set; }
        
        public int Counter { get; private set; }

        List<Beverage> _drinksList;

        public VendingMachine(int sugarTS, int coffeBeans, int englishteascaldingBag,int lemonteascaldingbag, int minthteascaldingbag,
            int avivizteascaldingbag, int chocolateMixPowderTS, int frenchVanillaPowderTS, int milkML, int cups)
        {
            SugarTS = sugarTS;
            CoffeBeans = coffeBeans;
            EnglishteascaldingBag = englishteascaldingBag;
            Lemonteascaldingbag = lemonteascaldingbag;
            Minthteascaldingbag = minthteascaldingbag;
            Avivizteascaldingbag = avivizteascaldingbag;
            ChocolateMixPowderTS = chocolateMixPowderTS;
            FrenchVanillaPowderTS = frenchVanillaPowderTS;
            MilkML = milkML;
            Cups = cups;
            _drinksList = new List<Beverage>();
            Counter = 0;
        }

        
        public void FillVendingMechine(int sugar, int coffee, int englishTea, int lemonTea, int minthTea, int avivizTea,
            int chocolatePowder, int vanillaPowder, int milkml, int cups)
        {
            SugarTS = 250;
            CoffeBeans = 250;
            EnglishteascaldingBag = 100;
            Lemonteascaldingbag = 100;
            Minthteascaldingbag = 100;
            Avivizteascaldingbag = 100;
            ChocolateMixPowderTS = 250;
            FrenchVanillaPowderTS = 250;
            MilkML = 200;
            Cups = 250;
        }
                        
        public Beverage DrinkObj(int index)
        {            
            return _drinksList[index];            
        }

        public string GetDrinkName(int index)
        {            
            return _drinksList[index].Name;                       
        }
        public int GetDrinkPrice(int index)
        {
            return _drinksList[index].Price;
        }

        public void AddBeverage(Beverage drink)
        {           
            _drinksList.Add(drink);            
            Counter++;
            
        }
        public void RemoveFromDrinkList(string drink)
        {
            for (int i = 0; i < _drinksList.Count; i++)
            {                
                if (drink == _drinksList[i].Name) _drinksList.Remove(_drinksList[i]);
                if (drink != _drinksList[i].Name)
                {
                    Exception e = new NameNotFoundException("Requested Beverage Name Not Found");
                    throw e;
                }                        
            }            
        }

        public void DrinkBought(Beverage drink)
        {
            Cups--;
            if (drink.GetType() == typeof(Coffe))
            {
                Coffe coffeDrink = drink as Coffe;
                CoffeBeans -= coffeDrink.CoffeTS;
                SugarTS -= coffeDrink.SugarTS;
                MilkML -= coffeDrink.HotMilkML;
            }
            if (drink.GetType() == typeof(Tea))
            {
                Tea teaDrink = drink as Tea;
                SugarTS -= teaDrink.SugarTS;
                EnglishteascaldingBag -= teaDrink.EnglishTeaScaldingBag;
                Lemonteascaldingbag -= teaDrink.LemonTeaScaldingBag;
                Minthteascaldingbag -= teaDrink.MinthTeaScaldingBag;
                Avivizteascaldingbag -= teaDrink.AvivizTeaScaldingBag;
            }
            if (drink.GetType() == typeof(Chocolate))
            {
                Chocolate chocolateDrink = drink as Chocolate;
                SugarTS -= chocolateDrink.SugarTS;
                MilkML -= chocolateDrink.HotMilkML;
                ChocolateMixPowderTS -= chocolateDrink.ChocolatePowderTS;
                FrenchVanillaPowderTS -= chocolateDrink.FrenchVanillaPowderTS;
            }
        }

        public string IsInStockForAll(Beverage drink) 
        {
            if (Cups < 0) return "Refill Machine";
            if ((MilkML - drink.HotMilkML) <= 0) return "Refill Machine";            
            if ((SugarTS - drink.SugarTS) <= 0) return "Refill Machine";
            if ((Cups - drink.Cup) <= 0) return "Refill Machine";
            if (drink.GetType() == typeof(Coffe))
            {
                Coffe coffedrink = drink as Coffe;
                if ((CoffeBeans - coffedrink.CoffeTS) <= 0) return "Refill Machine";                
            }
            if(drink.GetType() == typeof(Tea))
            {
                Tea teaDrink = drink as Tea;
                if ((EnglishteascaldingBag - teaDrink.EnglishTeaScaldingBag) <= 0) return "Refill Machine";
                if ((Lemonteascaldingbag - teaDrink.LemonTeaScaldingBag) <= 0) return "Refill Machine";                
                if ((Minthteascaldingbag - teaDrink.MinthTeaScaldingBag) <= 0) return "Refill Machine";                
                if ((Avivizteascaldingbag - teaDrink.AvivizTeaScaldingBag) <= 0) return "Refill Machine";
            }
            if(drink.GetType() == typeof(Chocolate))
            {
                Chocolate chocoDrink = drink as Chocolate;
                if ((ChocolateMixPowderTS - chocoDrink.ChocolatePowderTS) <= 0) return "Refill Machine";
                if ((FrenchVanillaPowderTS - chocoDrink.FrenchVanillaPowderTS) <= 0) return "Refill Machine";
            }
            return "All Good";
        }                 
    }      
}
