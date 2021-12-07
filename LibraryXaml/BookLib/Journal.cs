using BookLib.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib
{
    public class Journal : AbstractItem
    {        
        public int CopyNum { get; set; } 
        public long ISSN { get; set; }         
        
        public Journal(string name, int price, DateTime printDate, int stock, int copyNum, long iSSN, params Genres[] genre)
            : base(name, price, printDate, stock, genre)
        {                       
            CopyNum = copyNum;
            ISSN = iSSN;            
        }

        public Journal(Journal item, int stock) : base(item, stock)
        {
            CopyNum = item.CopyNum;
            ISSN = item.ISSN;
        }

        public override AbstractItem CopyItem()
        {
            return new Journal(this, 1);
        }

        public override string ToString()
        {
            return $"Name : {Name} \n " +
                $"Price : {Price} \n " +                
                $"Copy : {CopyNum} \n " +                
                $"Print Date : {PrintDate} \n " +             
                $"ISSN : {ISSN} \n " +             
                $"Genres :\n{GetGenresAsString()} \n " +
                $"Stock : {Stock}";
        }
    }    
}
