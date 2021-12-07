using System;
using System.Collections.Generic;
using System.Text;

namespace BoxesLogic
{
    class Width_X: IComparable<Width_X>
    {
        public double X { get; set; }

        public Binary_Search_Tree<Height_Y> YTree { get; set; }

        /// <summary>
        /// Dummy
        /// </summary>
        /// <param name="x"></param>
        public Width_X(double x)
        {
            X = x;
        }


        public int CompareTo(Width_X other)
        {
            return X.CompareTo(other.X);
        }
    }
}
