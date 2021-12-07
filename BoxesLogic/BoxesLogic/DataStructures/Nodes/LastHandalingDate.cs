using System;
using System.Collections.Generic;
using System.Text;

namespace BoxesLogic
{   //Linked list node defenition.
    class LastHandalingDate
    {
        public double xData { get; set; }
        public double yData { get; set; }
        public DateTime date { get; set; }

        public LastHandalingDate(double xData, double yData)
        {
            this.xData = xData;
            this.yData = yData;
            this.date = DateTime.Now;
        }
    }
}