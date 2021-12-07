using BookLib.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib
{
    abstract public class AbstractItem
    {       
        public string Name { get; set; }                    
        public DateTime PrintDate { get; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public decimal PriceAfterDiscount { get { return (decimal)Price - ((decimal)Price * (Discount / 100M)); } }
        public int Stock
        {
            get => _stock;
            set
            {
                _stock = Math.Max(0, value);
            }
        }
        private int _stock;
        public Genres[] Genre { get; private set; }
        public AbstractItem(string name, int price, DateTime printDate, int stock, Genres[] genre)
        {
            Discount = 0;
            Genre = genre;
            Name = name;
            Price = price;
            PrintDate = printDate;
            Stock = stock;
        }

        protected AbstractItem(AbstractItem item, int stock)
        {
            Genre = item.Genre;
            Name = item.Name;
            Price = item.Price;
            PrintDate = item.PrintDate;
            Stock = 1;
        }

        #region Methods
        //Equal
        public override bool Equals(object obj)
        {
            if (obj is AbstractItem item)
            {
                return Name == item.Name;
            }
            throw new ArgumentException("This Object Is Not A !");
        }

        //Get the chosen Genres as strings
        public string GetGenresAsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Genres genre in Genre)
            {
                sb.AppendLine($"{genre}");
            }
            sb.Replace('_', ' ');
            return sb.ToString();
        }

        abstract public override string ToString();

        abstract public AbstractItem CopyItem();
        #endregion
    }
}
