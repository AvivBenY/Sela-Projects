using System;
using System.Collections.Generic;
using System.Text;

namespace BoxesLogic.Interfaces
{ 
    //User interactions interface
    public interface IUserInteractions
    {
        bool FinalRequestConfirmation(List<(double x, double y, int amount)> boxes);
        bool SizeExceedingConfirmation(List<(double x, double y, int amount)> boxes);
        bool NotEnoughBoxesInStockConfirmation(List<(double x, double y, int amount)> boxes);
        void Notify(string s);
    }
}
