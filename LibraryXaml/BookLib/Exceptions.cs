using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib
{
   
    public class BadLoginException : Exception
    {
        public BadLoginException() { }
        public BadLoginException(string message) : base(message) { }
        public BadLoginException(string message, Exception inner) : base(message, inner) { }
        
        public Reason WrongLoginDetail { get; }

        public BadLoginException(Reason detail) :this()
        {
            WrongLoginDetail = detail;            
        }

        public enum Reason
        {
            UserName,
            PassWord,
        }

    }
}
