using System;
using System.Collections.Generic;
using System.Text;

namespace BoxesLogic
{
    class Height_Y: IComparable<Height_Y>
    {
        public double Y { get; set; }
        public int Count { get; set; }
        public static int MinimumAlert { get; set; }
        public Double_Linked_List<LastHandalingDate>.Node linkedListNodeRef { get; set; }

        public Height_Y(double y, int count)
        {
            Y = y;
            Count = count;
        }

        public Height_Y(double y)
        {
            Y = y;
        }

        public bool isInStock(int min)
        {
            return (Count > min);
        }

        public int CompareTo(Height_Y other)
        {
            return Y.CompareTo(other.Y);
        }          
    }
}
