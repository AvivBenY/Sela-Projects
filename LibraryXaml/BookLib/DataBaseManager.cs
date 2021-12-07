using BookLib.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BookLib
{
    public class DataBaseManager
    {
        DataBase _TheDataBase;
        List<AbstractItem> _dataBase;
        public string currentUser { get; private set;}
        private static string _logFileName;

        
        public DataBaseManager()
        {
            _TheDataBase = new DataBase();
            _dataBase = new List<AbstractItem>();
            _logFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "myLog.txt");

        }

        //Error Log 
        public static void ErrorLog(string logMessage)
        {
            File.AppendAllText(_logFileName, $"[{DateTime.Now}]\t[{logMessage}]\n");
        }

        //Add to the DataBase
    public bool AddToItemDataBase(AbstractItem item)
        {
            if (!_TheDataBase.IsInData(item))
            {
                _TheDataBase.AddToDataBase(item);
                return false;
            }
            else return true;
        }

        //Remove from the databse
        public void RemoveFromData(AbstractItem item)
        {
            for (int i = 0; i < _TheDataBase.Get_dataBaseView().Length; i++)
            {
                AbstractItem listItem = _TheDataBase.Get_dataBaseView()[i];
                if (listItem == item) _TheDataBase.RemoveFromDataBase(listItem);
            }
        }

        //Access to database
        public DataBase GetDatabaseClass()
        {
            return _TheDataBase;
        }

        //Get all Authors list
        public List<string> GetAuthor()
        {
            return _TheDataBase.AuthorList();
        }

        //Filter By Author
        public AbstractItem[] ArrByAuthor(string a)
        {
            return _TheDataBase.CreateListByAuthor(a);        
        }

        //Filter By ISBN
        public AbstractItem[] GetBookByISBN(long isbnNum)
        {
            return _TheDataBase.BookByISBN(isbnNum);
        }

        //Filter By ISSN
        public AbstractItem[] GetJournalByISSN(long issnNum)
        {
            return _TheDataBase.JournalByISSN(issnNum);
        }

        //Filter By CopyNum
        public AbstractItem[] GetJournalByCopy(int copy)
        {
            return _TheDataBase.JournalByCopyNum(copy);
        }

        //Filter by max price
        public AbstractItem[] ItemsArrByPrice(int price, AbstractItem[] chosenArr)
        {
            return _TheDataBase.GetItemsByPrice(price, chosenArr);
        }

        //Get Item List
        public AbstractItem[] GetItemDataBase()
        {
            return _TheDataBase.Get_dataBaseView();            
        }        

        //Get Books List
        public AbstractItem[] GetBooksDataBase()
        {
            return _TheDataBase.Get_BooksdataBaseView();
        }

        //Get Journals List
        public AbstractItem[] GetJournalsDataBase()
        {
            return _TheDataBase.Get_JournalsdataBaseView();
        }

        //Get the list of items in the Cart
        public List<AbstractItem> GetPurchaseListView()
        {
            return _TheDataBase.ReturnPurchaseList();
        }

        //Filter single item by name
        public AbstractItem[] GetItemByName(string name, AbstractItem[] itemTypeArr)
        {
            return _TheDataBase.GetsingleItemByName(name, itemTypeArr);
        }

        //Get Data Base ByGenre
        public AbstractItem[] GetDataBaseByGenre(string genre, AbstractItem[] itemTypeArr)
        {
            return _TheDataBase.CreateArrByGenre(genre, itemTypeArr);
        }

        //return Obj
        public AbstractItem GetItemObj(string bookName)
        {
            for (int i = 0; i < _dataBase.Count; i++)
            {
                if (bookName == _dataBase[i].Name) return _dataBase[i];
            }
            return null;
        }
                
        //Replace NEW Data from list's created with the OLD Data from the main database
        public void ReplaceDataBaseObjects(List<AbstractItem> DataToReplace)
        {
            for (int i = 0; i < _dataBase.Count; i++)
            {
                for (int j = 0; j < DataToReplace.Count; j++)
                {
                    if(DataToReplace[j].Name == _dataBase[i].Name)
                    {
                        _dataBase[i] = DataToReplace[j];
                    }
                }
            }
        }

   

        // "employee discount" For item
        public AbstractItem GetEmployeeDiscount(AbstractItem item)
        {
           for (int i = 0; i < _TheDataBase.Get_dataBaseView().Length; i++)
           {
               if (item.Name == _TheDataBase.Get_dataBaseView()[i].Name)
               {
                   _TheDataBase.EmployeeDiscount(item);
                   return item;
               }
           }
            return null;
        }       

        //Add a Setted discount to item
        public AbstractItem GetSetDiscount(AbstractItem item, int discount)
        {
            for (int i = 0; i < _TheDataBase.Get_dataBaseView().Length; i++)
            {
                if (item.Name == _TheDataBase.Get_dataBaseView()[i].Name)
                {
                    _TheDataBase.SetDiscount(item,discount);
                    return item;
                }
            }
            return null;
        }

        
        //use this to Purchase
        public bool Purchase(AbstractItem item)
        {
            for (int i = 0; i < _TheDataBase.Get_dataBaseView().Length; i++)
            {
                AbstractItem _dataBaseItem = _TheDataBase.Get_dataBaseView()[i];
                if (_dataBaseItem.Equals(item))
                {
                    if (_dataBaseItem.Stock == 0) return false;
                    _dataBaseItem.Stock -= 1;
                    return true;
                }                
            }
            return false;
        }

        //Use this to return
        public bool Return(AbstractItem item)
        {
            for (int i = 0; i < _TheDataBase.Get_dataBaseView().Length; i++)
            {
                AbstractItem _dataBaseItem = _TheDataBase.Get_dataBaseView()[i];
                if (_dataBaseItem.Equals(item))
                {                    
                    _dataBaseItem.Stock += 1;
                    return true;
                }
            }
            return false;
        }

        
        public List<string> GetUserNames()
        {
            return _TheDataBase.GetEmployeesUserNames();
        }

        //Use this to check employees names
        public List<string> GetNames()
        {
            return _TheDataBase.GetEmployeesNames();
        }

        //Login
        public void Login(string username, string password)
        {
            if (_TheDataBase.GetEmployeesUserNames().Contains(username))
            {
                if (password == "123") 
                {
                    currentUser = _TheDataBase.GetEmployeeByName(username).Name;
                }
                else throw new BadLoginException(BadLoginException.Reason.PassWord);
            }      
            else
            {
                throw new BadLoginException(BadLoginException.Reason.UserName);
            }           
            
        }        
    }
}
