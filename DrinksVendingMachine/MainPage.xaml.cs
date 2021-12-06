using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DrinksVendingMachine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        VendingMachine _vendingMachine = new VendingMachine(250, 250, 100, 100, 100, 100, 250, 250, 250, 0);
        public Button _payBtn;
        List<Button> DrinksBtn = new List<Button>();        
        bool isClicked = false;
        public TextBlock _communicationPannel;
        public TextBlock _machineoutput;
        public string isMissing;
        int BtnCount = 12;
        public MainPage()
        {
            this.InitializeComponent();
            MenuContent();
            BtnListCreation(BtnCount);
            BtnListDisable();            
            CreateDrinksList();            
            Communication_Pannel.Text = "please insert coin...";
        }
        public void MenuContent()
        {
            Menu.Text =
                "Cappuccino : 5" +
                "\nLatte : 4" +
               "\nAmericano : 2" +
               "\nEspresso : 3" +
               "\nEnglish Tea : 3" +
               "\nLemon Tea : 2" +
               "\nMinth Tea : 3" +
               "\nAviviz Tea : 10" +
               "\nSwiss Chocolate : 4" +
               "\nChocolata : 5" +
               "\nFrench Vanilla : 4" +
               "\nDroz Chocolate : 7";
        }

        public void BtnListCreation(int amount)                                              
        {
            for (int i = 0; i < amount; i++)
            {
                DrinksBtn.Add(Btn1);
                DrinksBtn.Add(Btn2);
                DrinksBtn.Add(Btn3);
                DrinksBtn.Add(Btn4);
                DrinksBtn.Add(Btn5);
                DrinksBtn.Add(Btn6);
                DrinksBtn.Add(Btn7);
                DrinksBtn.Add(Btn8);
                DrinksBtn.Add(Btn9);
                DrinksBtn.Add(Btn10);
                DrinksBtn.Add(Btn11);
                DrinksBtn.Add(Btn12);
            }
        }
        public void BtnListDisable()
        {
            for (int i = 0; i < DrinksBtn.Count; i++)
            {
                DrinksBtn[i].IsEnabled = false;
            }
            
        }
        public void CreateDrinksList()
        {            
            _vendingMachine.AddBeverage(new Coffe("Cappuccino", 5, 2, 2, 20, 150));
            _vendingMachine.AddBeverage(new Coffe("Latte", 4, 1, 2, 0, 130));
            _vendingMachine.AddBeverage(new Coffe("Americano", 2, 0, 2, 220, 0));
            _vendingMachine.AddBeverage(new Coffe("Espresso", 3, 2, 0, 50, 0));
            _vendingMachine.AddBeverage(new Tea("English Tea", 3, 2, 200, 1, 0, 0, 0));
            _vendingMachine.AddBeverage(new Tea("Lemon Tea", 2, 2, 200, 0, 1, 0, 0));
            _vendingMachine.AddBeverage(new Tea("Minth Tea", 3, 2, 200, 0, 0, 1, 0));
            _vendingMachine.AddBeverage(new Tea("Aviviz Tea", 10, 2, 200, 0, 0, 0, 1));
            _vendingMachine.AddBeverage(new Chocolate("Swiss Chocolate", 4, 2, 180, 40, 2, 0));
            _vendingMachine.AddBeverage(new Chocolate("Chocolata", 5, 3, 200, 20, 3, 0));
            _vendingMachine.AddBeverage(new Chocolate("French Vanilla", 4, 2, 180, 40, 0, 2));
            _vendingMachine.AddBeverage(new Chocolate("Droz Chocolate", 7, 6, 200, 20, 6, 0));            
        }
        

        public void RemoveFromDrinkList(string DrinkName)
        {
            _vendingMachine.RemoveFromDrinkList(DrinkName);
            try
            {
                _vendingMachine.RemoveFromDrinkList(DrinkName);
            }
            catch (NameNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }            
        }
        private void HotDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            PAY.IsEnabled = false;
            Button DrinksButton = sender as Button;
            for (int i = 0; i < _vendingMachine.Counter; i++)
            {
                if (DrinksButton.Content.ToString() == _vendingMachine.GetDrinkName(i))
                {
                    if (_vendingMachine.IsInStockForAll(_vendingMachine.DrinkObj(i)) != "All Good")
                    {
                        MachineOutPut.Text = "Please wait, Some ingridiants need refill. \n it may take a few seconds..";
                        System.Threading.Thread.Sleep(600);
                        _vendingMachine.FillVendingMechine(250, 250, 100, 100, 100, 100, 250, 250, 250, 1);                        
                    }
                    _vendingMachine.DrinkBought(_vendingMachine.DrinkObj(i));
                    _vendingMachine.DrinkObj(i).Prepare();
                    Communication_Pannel.Text = _vendingMachine.DrinkObj(i).Prepare().ToString();                
                    int _money = int.Parse(CoinValue.Text);
                    int _price = _vendingMachine.DrinkObj(i).Price;                
                    {
                        if ((_money - _price) > 0) 
                        {
                            MachineOutPut.Text = $"Dont Forget Your Change : {_money - _price}$";
                            break;
                        }
                        if ((_money - _price) == 0)
                        {
                            MachineOutPut.Text = $"Enjoy!!";
                            break;
                        }                    
                    }
                }
            }
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            CoinValue.IsEnabled = false;
            for (int j = 0; j < DrinksBtn.Count; j++)
            {
                DrinksBtn[j].IsEnabled = true;
                DrinksBtn[j].Opacity = 1;
            }            
            int _money;           
            if (int.TryParse(CoinValue.Text, out _money) && _money > 0)
            {
                for (int i = 0; i < _vendingMachine.Counter; i++)
                {
                    if (_money < _vendingMachine.DrinkObj(i).Price)
                    {
                        if (_vendingMachine.DrinkObj(i).Name == DrinksBtn[i].Content.ToString())
                        {
                            DrinksBtn[i].IsEnabled = false;
                            DrinksBtn[i].Opacity = 0.5;
                        }
                    }
                }
            }            
            else
            {                
                PAY.IsEnabled = false;
                CoinValue.Text = "";
                MachineOutPut.Text = "Please enter a VALID coin value (number). Click the reset Button";
            }           
        }
        private void InsertAmount(object sender, RoutedEventArgs e)
        {
            if (!isClicked)
            {
                CoinValue.Text = "";
                isClicked = true;
            }
        }

        private void PickCupButton_Click(object sender, RoutedEventArgs e)
        {
            Communication_Pannel.Text = "";
            MachineOutPut.Text = "";
            CoinValue.Text = "";
            CoinValue.IsEnabled = true;
            PAY.IsEnabled = true;
            BtnListDisable();
        }        

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }

    [Serializable]
    public class NameNotFoundException : Exception
    {
        public NameNotFoundException() { }
        public NameNotFoundException(string message) : base(message) { }
        public NameNotFoundException(string message, Exception inner) : base(message, inner) { }
        
    }
}
