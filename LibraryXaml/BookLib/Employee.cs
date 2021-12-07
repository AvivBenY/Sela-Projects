using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib
{
    public class Employee
    {
        public Employee(string name, string userName)
        {
            Name = name;
            UserName = userName;
        }

        public string Name { get; set; } 
        public string UserName { get; set; } 
        
    }
}
