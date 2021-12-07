using BoxesLogic.Interfaces;
using System;
using System.Collections.Generic;

namespace BoxesLogic
{
    public class Manager
    {
        #region App Configuration
        Double_Linked_List<LastHandalingDate> timesList = new Double_Linked_List<LastHandalingDate>();
        internal static Binary_Search_Tree<Width_X> mainTree = new Binary_Search_Tree<Width_X>();        
        readonly IUserInteractions _userInteractions;
        System.Threading.Timer _timer;              
        int boxExperation = 2;
        int maxInStock = 50;
        int maxSizeDiff = 4;
        int minStockAllowed = 5;
        int splitNum = 5;        
        
        public Manager(IUserInteractions userInteractions)
        {
            _userInteractions = userInteractions;
            CountDownTimer();
            Height_Y.MinimumAlert = minStockAllowed;
        }

        #endregion

        //Add or Update given box to stock.
        public void AddToStock(double x, double y, int count)
        {
            Width_X newWidth = new Width_X(x);

            //if data exsist
            if (!mainTree.FindAndUpdate(newWidth, out Width_X widthData))
            {
                //if data exsist
                widthData.YTree = new Binary_Search_Tree<Height_Y>();
            }

            if(!widthData.YTree.FindAndUpdate(new Height_Y(y), out Height_Y heightData))
            {
                heightData.linkedListNodeRef = timesList.AddFirst(new LastHandalingDate(x, y));
            }

            heightData.Count += count;
            if (heightData.Count > maxInStock) heightData.Count = maxInStock;
        }

        //Find and print if possible, if not "data not found".
        public void FindAndPrintBox(double x, double y)
        {
            Width_X newWidth = new Width_X(x);            
            
            if ((!mainTree.Find(newWidth, out Width_X widthData)) || (!widthData.YTree.Find(new Height_Y(y), out Height_Y heightData)))
            {
                Console.WriteLine("Data Not Found");
                return;
            }
            Console.WriteLine($"X = {widthData.X}  Y = {heightData.Y} Amount = {heightData.Count}");
        }
        
        //Buy 1 item.
        public bool BuyPartA(double x, double y, out IEnumerable<string> messages)
        {
         var messagesList = new List<string>();
         Width_X width = new Width_X(x);
         Height_Y height = new Height_Y(y);
         
             while(mainTree.ClosestOrExact(width, out Width_X foundBiggerBase) && foundBiggerBase.X < x * maxSizeDiff)
             {
                 while(foundBiggerBase.YTree.ClosestOrExact(height, out Height_Y foundBox) && foundBox.Y < y * maxSizeDiff)
                 {
                    FinalizeOrder(ref messagesList, (foundBiggerBase, foundBox, 1));
                    
                    messagesList.Add($"Box Details: \n Base - {foundBiggerBase.X}\nHeight - {foundBox.Y} \n Purchase Complete.");                    
                    messages = messagesList;
                    return true ;
                 }
              width.X = foundBiggerBase.X + 0.1;
             }

            messagesList.Add("Were terribly sorry, \n There are no avialable boxs in stock.");
            messages = messagesList;
            return false;
        }

        //buyPartB
        //check boxes count, if good return boxes and finish
        //if not enough change the search for bigger boxes and substract the count of the last search
        //again until finished.
        public bool BuyPartB(double x, double y, int buyAmount, out IEnumerable<string> messages)
        {            
            bool limitExceeded = false;
            Width_X width = new Width_X(x);
            Height_Y height = new Height_Y(y);
            var messagesList = new List<string>();            
            var finalOrderView = new List<(double boxWidth, double boxHeight, int amount)>();
            var finalOrder = new List<(Width_X boxWidth, Height_Y boxHeight, int amount)>();

            //search Xtree
            while (mainTree.ClosestOrExact(width, out Width_X foundBiggerBase))
            {
                if (foundBiggerBase.X < x * maxSizeDiff) limitExceeded = true;
                height.Y = y;
                // found xtree - search y tree inside it
                while (foundBiggerBase.YTree.ClosestOrExact(height, out Height_Y foundBox) && foundBox.Y < y * maxSizeDiff) 
                {                    
                    splitNum++;
                    var minAmountToTake = Math.Min(foundBox.Count, buyAmount);                    
                    finalOrder.Add((foundBiggerBase, foundBox, minAmountToTake));
                    buyAmount -= minAmountToTake;
                    finalOrderView.Add((foundBiggerBase.X, foundBox.Y, minAmountToTake));
                    
                    if (buyAmount <= 0)
                    {
                        if (_userInteractions.FinalRequestConfirmation(finalOrderView))
                        {                            
                            FinalizeOrder(ref messagesList, finalOrder.ToArray());
                            messagesList.Add("Purchase Complete.");
                            messages = messagesList;
                            return true;
                        }
                        else
                        {
                            messagesList.Add("Aborted");
                            messages = messagesList;
                            return false;
                        }                        
                    }
                    
                    if (limitExceeded is true)
                    {
                        messagesList.Add("");
                        if(!_userInteractions.SizeExceedingConfirmation(finalOrderView))
                        {
                            messagesList.Add("Aborted");                                                                                            
                            messages = messagesList;
                            return false;
                        }
                    }                    
                    if (splitNum >= 10)
                    {
                        messagesList.RemoveAll(isString);
                        messagesList.Add("Were sorry, \nYour request is not possible at the moment it takes to much splits, \nhave a remarkable day.");
                        messages = messagesList;
                        return false;
                    }
                    height.Y = foundBox.Y + 0.1;
                }
                width.X = foundBiggerBase.X + 0.1;
            }
            if (_userInteractions.NotEnoughBoxesInStockConfirmation(finalOrderView))
            {
                FinalizeOrder(ref messagesList ,finalOrder.ToArray());
                messagesList.Add("Purchase Complete.");
                messages = messagesList;
                return true;
            }
            else
            {
                messagesList.Add("Aborted");
                messages = messagesList;
                return false;
            }
        }

        //for every height reduce the amount and ask if we need to delete the node/Xtree
        //activate when we finish and buy.
        private void FinalizeOrder(ref List<string> messagesList, params (Width_X boxWidth, Height_Y boxHeight, int amount)[] finalOrder)
        {

            for (int i = 0; i < finalOrder.Length; i++)
            {                
                finalOrder[i].boxHeight.Count -= finalOrder[i].amount;
                finalOrder[i].boxHeight.linkedListNodeRef.data.date = DateTime.Now;
                if (finalOrder[i].boxHeight.Count <= 0)
                {                    
                    finalOrder[i].boxWidth.YTree.DeleteNode(finalOrder[i].boxHeight);
                    if (finalOrder[i].boxWidth.YTree.IsEmpty) mainTree.DeleteNode(finalOrder[i].boxWidth);
                    timesList.RemoveNode(finalOrder[i].boxHeight.linkedListNodeRef);
                    messagesList.Add("You purchased the last box, 0 boxes left, Stock for this box is now empty.");
                }   
                else
                {
                    timesList.MoveToFirst(finalOrder[i].boxHeight.linkedListNodeRef);
                    if(finalOrder[i].boxHeight.Count <= minStockAllowed)
                    { 
                     messagesList.Add($"Box Stock running out, only {finalOrder[i].boxHeight.Count} boxes left!");                      
                    }
                }                                               
            }
        }
        private static bool isString(string s)
        {
            return s is string;
        }
       
        //Find expired links and delete.
        public void DeleteExpired()
        {            
            foreach (var link in ExpirationCollector())
            {
                Width_X xtree = new Width_X(link.xData);
                Height_Y ytree = new Height_Y(link.yData);
                mainTree.ClosestOrExact(xtree, out Width_X founXData);
                founXData.YTree.FindAndUpdate(ytree, out Height_Y foundBox);
                if (foundBox.Count <= 0) mainTree.DeleteNode(founXData);
                else founXData.YTree.DeleteNode(foundBox);
                timesList.RemoveNode(foundBox.linkedListNodeRef);
            }            
        }


        //Delete expired boxes.
        private IEnumerable<LastHandalingDate> ExpirationCollector()
        {
            //define experation
            //loop from end to the experation defined
            //each loop check date and collect data
            //get IEnumerable of data to delete later on
            var tmp = timesList.end;
            List<LastHandalingDate> expiredLinkList = new List<LastHandalingDate>();
            var ExpirationTime = DateTime.Now.Subtract(TimeSpan.FromDays(boxExperation));
            while (tmp != null && ExpirationTime >= tmp.data.date.Date ) //3
            {
                expiredLinkList.Add(tmp.data);
                tmp = tmp.previews;
            }
            return expiredLinkList;
        }       
        public IEnumerable<(double boxWidth, double boxHeight, int amount, DateTime date)> Stock
        {
            get
            {
                var res = new List<(double boxWidth, double boxHeight, int amount, DateTime date)>();
                mainTree.ScanInOrder(a => a.YTree.ScanInOrder(b => res.Add((a.X, b.Y, b.Count, b.linkedListNodeRef.data.date))));
                return res;
            }
        }
        public void CountDownTimer()
        {            
            TimeSpan dueTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1).Subtract(DateTime.Now);
            TimeSpan period = TimeSpan.FromDays(1);
            _timer = new System.Threading.Timer(ExperationCaller, null, dueTime, period);   
            
            _userInteractions.Notify($"Timer initialized, First callback in {dueTime.Hours} Houres and {dueTime.Minutes} Minutes");
            _userInteractions.Notify($"Deletion Sequence Will Delete all Boxes Older then - {DateTime.Now.Subtract(TimeSpan.FromDays(boxExperation)).ToShortDateString()}\n");
        }
        public void ExperationCaller(object state)
        {
            _userInteractions.Notify($"Deletion Sequence Started, Deleting all Boxes Older then - {DateTime.Now.Subtract(TimeSpan.FromDays(boxExperation)).ToShortDateString()}");
            DeleteExpired();
        }

        //Configuration show.
        public void ShowConfigurations()
        {
            Console.WriteLine($"Experation period for boxes : {boxExperation} Days\n");  
            Console.WriteLine($"Max boxes allowed in stock per size : {maxInStock}\n");  
            Console.WriteLine($"Max base size allowed for a box : {maxSizeDiff}00 (%)\n");  
            Console.WriteLine($"Minnimum stock allowed before alerting : {minStockAllowed}\n");  
            Console.WriteLine($"Maximum times to split order due to size exeption : {splitNum}\n");  
        }
    }
}
