using BoxesLogic.Interfaces;
using ConsoleTables;
using System;
using System.Linq;

namespace Program.Implamentations
{
    internal class StockShow : IUiScreen
    {
        //Interface implementation..
        public void Show()
        {           
            ShowStock();
        }

        //Create table and insert stock data.
        private void ShowStock()
        {
            Console.WriteLine("Our Stock:");
            var table = new ConsoleTable("x", "y", "amount", "Last Handling Date");            
            StaticInstances.LogicManager.Stock.ToList().ForEach(b => table.AddRow(b.boxWidth, b.boxHeight, b.amount, b.date));
            table.Write();
        }
    }
}