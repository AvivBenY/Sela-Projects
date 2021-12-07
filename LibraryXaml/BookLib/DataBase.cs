using BookLib.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLib
{
    public class DataBase
    {
        List<AbstractItem> _dataBase;
        List<Employee> _dataBaseEmployees;        
        AbstractItem[] _dataBaseBooks;
        List<AbstractItem> purchaseListView;
        AbstractItem[] _dataBaseJournals;
        public DataBase()
        {
            _dataBase = new List<AbstractItem>();
            _dataBaseEmployees = new List<Employee>();
            purchaseListView = new List<AbstractItem>();
            DataBaseCreation();
            EmployeeDataBase();
            _dataBaseBooks = CreateListByType(1);
            _dataBaseJournals = CreateListByType(2);
        }

        //Contain the lists of data
        #region The Data
        public void DataBaseCreation()
        {
            AddToDataBase(new Journal("HOW TO BE LIKE YOU", 25, new DateTime(2020, 2, 8), 50, 415, 123123,
                Genres.Cookbook));
            AddToDataBase(new Journal("YOU GIVE'S AN TO YOURSELF", 25, new DateTime(2020, 2, 8), 50, 415, 123123,
                Genres.Cookbook));
            AddToDataBase(new Book("WHERE IS PLUTO", 40, "LEA GOLDBERG", new DateTime(1992, 11, 04), 2, "dog lost his way"
                , 23543534, Genres.Adventure, Genres.Childrens));
            AddToDataBase(new Book("COW EATER", 55, "DROR NATHAN", new DateTime(2005,1,15), 50, "Dror Eats a Whole Cow",
                66666666, Genres.Horror, Genres.Romance));
            AddToDataBase(new Journal("COOKING WITH BABISH", 25, new DateTime(2020, 2, 8), 50, 415, 123123,
                Genres.Cookbook));
            AddToDataBase(new Journal("NOOR GOING TO THE BEACH", 150, new DateTime(2020, 8, 27), 50, 1850, 654123, Genres.Adventure,
                Genres.Autobiography, Genres.Fairytale));
            AddToDataBase(new Book("ENJOY LIFE", 65, "Aviv Ben Yedidia", new DateTime(1992, 11, 04), 2, "LOVE LIFE"
                , 123213123, Genres.Adventure, Genres.Childrens));
            AddToDataBase(new Book("COW SHITTER", 55, "DROR NATHAN", new DateTime(2005, 1, 15), 50, "Dror LOVE a Whole God Dam Cow",
                66666666, Genres.Horror, Genres.Romance));
            AddToDataBase(new Journal("COOKING WITH TOMER", 25, new DateTime(2020, 2, 8), 50, 415, 123123,
                Genres.Cookbook));
            AddToDataBase(new Journal("NOOR TEACHES DESIGN", 150, new DateTime(2020, 8, 27), 50, 1850, 654123, Genres.Adventure,
                Genres.Autobiography, Genres.Fairytale));
        }

        //Employees
        public void EmployeeDataBase()
        {
            AddEmployee(new Employee("Aviv", "Aviv"));
            AddEmployee(new Employee("Dror", "Dror"));
            AddEmployee(new Employee("Tomer", "Tomer"));           
        }
        #endregion

        #region Methods For Item Data

        //Get _dataBase
        public AbstractItem[] Get_dataBaseView()
        {
            return _dataBase.ToArray(); ;
        }

        //Get _dataBaseBooks
        public AbstractItem[] Get_BooksdataBaseView()
        {
            return _dataBaseBooks.ToArray(); ;
        }

        //Get _dataBaseJournals
        public AbstractItem[] Get_JournalsdataBaseView()
        {
            return _dataBaseJournals.ToArray(); ;
        }

        //Get list of Item that were added to the shopping cart
        public List<AbstractItem> ReturnPurchaseList()
        {
            return purchaseListView;
        }

        //Add To _dataBase
        public void AddToDataBase(AbstractItem newitem)
        {
            _dataBase.Add(newitem);            
        }
            
        
        //Check if the requested item is in the data base
        public bool IsInData(AbstractItem newItem)
        {
            for (int i = 0; i < _dataBase.Count; i++)
            {
                if (_dataBase[i].Equals(newItem))
                {
                    return true;
                }               
            }
            return false;
        }

        //Remove From _dataBase
        public void RemoveFromDataBase(AbstractItem item)
        {
            _dataBase.Remove(item);
        }
        
        public AbstractItem[] GetsingleItemByName(string name, AbstractItem[] itemsArr)
        {
            List<AbstractItem> SingleitemList = new List<AbstractItem>();
            for (int i = 0; i < _dataBase.Count; i++)
            {
                if (_dataBase[i].Name == name)
                {
                    SingleitemList.Add(_dataBase[i]);
                    return SingleitemList.ToArray();
                }
            }
            return null;
        }

        //method  that create a list of AbstractItems which fit the genres entered to the method
        public AbstractItem[] CreateArrByGenre(string genre, AbstractItem[] itemArr) 
            //=> _dataBase.Where(x => x.Genre.Contains(genre)).ToArray();
        {
            List<AbstractItem> _listByGenre = new List<AbstractItem>();
            for (int i = 0; i < itemArr.Length; i++)
            {
                for (int j = 0; j < _dataBase[i].Genre.Length; j++)
                {
                    if (_dataBase[i].Genre[j].ToString() == genre)
                    {
                        _listByGenre.Add(_dataBase[i]);
                    }
                }
            }
            return _listByGenre.ToArray();
        }

        //method  that create a list of AbstractItems by Type(book / jounrnal)
        public AbstractItem[] CreateListByType(int type)
        {
            List<AbstractItem> _listByItemType = new List<AbstractItem>();
            if (type == 1)
            {
                for (int i = 0; i < _dataBase.Count; i++)
                {
                    if (_dataBase[i] is Book)
                    {
                        _listByItemType.Add(_dataBase[i]);
                    }
                }
            }
            if (type == 2)
            {
                for (int i = 0; i < _dataBase.Count; i++)
                {
                    if (_dataBase[i] is Journal)
                    {
                        _listByItemType.Add(_dataBase[i]);
                    }
                }
            }
            return _listByItemType.ToArray();
        }

        //method  that create a list of Books by Author
        public AbstractItem[] CreateListByAuthor(string author)        
        {
            Book book;
            List<Book> _listByAuthor = new List<Book>();            
                for (int i = 0; i < _dataBaseBooks.Length; i++)
                {
                book = _dataBaseBooks[i] as Book;
                 if (book.Author == author) _listByAuthor.Add(book);
                }
            return _listByAuthor.ToArray();
            //=> (from item in _dataBaseBooks where item.Author.Equals(author) select item).ToArray();
            //_dataBaseBooks.Where(x => x.Author.Equals(author)).ToArray();
        }

        //All Books Authors List (String)
        public List<string> AuthorList()
        {
            Book book;
            List<string> _authors = new List<string>();
            for (int i = 0; i < _dataBaseBooks.Length; i++)
            {
                book = _dataBaseBooks[i] as Book;
                _authors.Add(book.Author);
            }
            return _authors;
        }
        

        //Get Book By ISBN
        public AbstractItem[] BookByISBN(long isbn)
        {
            Book book;
            List<AbstractItem> SingleBookList = new List<AbstractItem>();
            for (int i = 0; i < _dataBaseBooks.Length; i++)
            {
                book = _dataBaseBooks[i] as Book;
                if (book.ISBN == isbn)
                {
                    SingleBookList.Add(book);
                }
            }
            return SingleBookList.ToArray();
        }

        //Get Single Item By Price
        public AbstractItem[] GetItemsByPrice(int price, AbstractItem[] chosenArr)
        {
            List<AbstractItem> ItemsByPrice = new List<AbstractItem>();
            for (int i = 0; i < chosenArr.Length; i++)
            {
                if (_dataBase[i].Price <= price) ItemsByPrice.Add(_dataBase[i]);
            }
            return ItemsByPrice.ToArray();
        }


        //Get Single Item By ISSN
        public AbstractItem[] JournalByISSN(long issn)
        {
            Journal journal;
            List<AbstractItem> SingleJournalList = new List<AbstractItem>();
            for (int i = 0; i < _dataBaseJournals.Length; i++)
            {
                journal = _dataBaseJournals[i] as Journal;
                if (journal.ISSN == issn)
                {
                    SingleJournalList.Add(journal);
                }
            }
            return SingleJournalList.ToArray();
        }

        //Get single Journal by filter of CopyNum
        public AbstractItem[] JournalByCopyNum(int copy)
        {
            Journal journal;
            List<AbstractItem> SingleJournalList = new List<AbstractItem>();
            for (int i = 0; i < _dataBaseJournals.Length; i++)
            {
                journal = _dataBaseJournals[i] as Journal;
                if (journal.CopyNum == copy)
                {
                    SingleJournalList.Add(journal);
                }
            }
            return SingleJournalList.ToArray();
        }
        #endregion

        #region Discount

        //Employee discount (5%)
        public AbstractItem EmployeeDiscount(AbstractItem item)
        {            
            item.Discount = 5;
            return item;
        }

        //Set your own discount
        public AbstractItem SetDiscount(AbstractItem item,int discount)
        {
            item.Discount = discount;
            return item;
        }
        #endregion

        #region Employee

        //Creates a list of the employees User-Names.
        public List<string> GetEmployeesUserNames()
        {
            List<string> employeesNames = new List<string>();

            for (int i = 0; i < _dataBaseEmployees.Count; i++)
            {
                employeesNames.Add(_dataBaseEmployees[i].UserName);
            }
            return employeesNames;
        }
        //Get Employee Name
        public List<string> GetEmployeesNames()
        {
            List<string> employeesNames = new List<string>();

            for (int i = 0; i < _dataBaseEmployees.Count; i++)
            {
                employeesNames.Add(_dataBaseEmployees[i].Name);
            }
            return employeesNames;
        }

        //Get employee by name
        public Employee GetEmployeeByName(string username)
        {
            for (int i = 0; i < _dataBaseEmployees.Count; i++)
            {
                if (_dataBaseEmployees[i].UserName == username)
                    return _dataBaseEmployees[i];
            }
            return null;
        }

        //Add new employee to the system.
        public void AddEmployee(Employee employeeDetails)
        {
            _dataBaseEmployees.Add(employeeDetails);
        }


        //Remove employee from system.
        public void RemoveEmployee(string userName)
        {
            for (int i = 0; i < _dataBaseEmployees.Count; i++)
            {
                if (_dataBaseEmployees[i].UserName == userName) _dataBaseEmployees.Remove(_dataBaseEmployees[i]);
            }
        }
        #endregion
    }
}
