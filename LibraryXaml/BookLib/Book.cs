using BookLib.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib
{
    public class Book : AbstractItem
    {       
        public string ShortCut { get; private set; }        
        public string Author { get; private set; }        
        public long ISBN { get; private set; }        
        
        public Book(string name, int price, string author, DateTime printDate, int stock, string shortCut, long isbn, params Genres[] genre)
            : base(name, price, printDate, stock, genre)
        {                        
            ShortCut = shortCut;
            ISBN = isbn;
            Author = author;
        }

        public Book(Book item, int stock) : base(item, stock)
        {
            ShortCut = item.ShortCut;
            ISBN = item.ISBN;
            Author = item.Author;
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   base.Equals(obj) &&
                   ISBN == book.ISBN;
        }

        public override AbstractItem CopyItem()
        {
            return new Book(this, 1);
        }

        public override string ToString()
        {
            return $"Name : {Name} \n " +
                $"Price : {Price} \n " +
                $"Author : {Author} \n " +
                $"Print Date : {PrintDate} \n " +
                $"Summery : {ShortCut} \n " +
                $"ISBN : {ISBN} \n " +
                $"Genres :\n{GetGenresAsString()} \n " +
                $"Stock : {Stock}";
        }
    }    
}
