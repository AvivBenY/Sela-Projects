using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BookLib;
using BookLib.Enum;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryXaml
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllBooksManagment : Page
    {
        public String[] Genres
        {
            get
            {
                List<string> GenresList = new List<string>(Enum.GetNames(typeof(Genres)));
                GenresList.Insert(0, "All Genres");
                return GenresList.ToArray();
            }
        }
        DataBaseManager _manager;
        int typeClicked = 0;
        public List<Genres> newItemGenres = new List<Genres>();

        public AllBooksManagment()
        {
            this.InitializeComponent();            
        }


        private void WelcomeMessage()
        {
            Welcome_MessageBox.Text = $"Welcome {_manager.currentUser}";
        }

        #region Add New Item
        //Method that takes the inputs for creating an item the user.
        public AbstractItem CreateNewAbstractItem()
        {
            long _isbn;
            if (!long.TryParse(AddBook_ISBNeTBox.Text, out _isbn) && _isbn > 0)
                return null;
            int _money;
            if (!int.TryParse(AddBook_PriceTBox.Text, out _money) && _money > 0)
                return null;
            if (!Calender.Date.HasValue)
                return null;
            int _stock;
            if (!int.TryParse(AddBook_ISBNeTBox.Text, out _stock) && _isbn > 0)
                return null;
            if (typeClicked == 1)
            {
                Book newItem = new Book(AddBook_NameTBox.Text, _money, AddBook_AuthorTBox.Text, Calender.Date.Value.DateTime, _stock, AddBook_ShortCutTBox.Text, _isbn, newItemGenres.ToArray());
                return newItem;
            }
            if (typeClicked == 2)
            {
                int copyNum;
                if (!int.TryParse(AddBook_CopyNumTBox.Text, out copyNum) && copyNum > 0)
                    return null;
                Journal newItem = new Journal(AddBook_NameTBox.Text, _money, Calender.Date.Value.DateTime, _stock, copyNum, _isbn, newItemGenres.ToArray());
                return newItem;
            }
            return null;
        }

        //filtering the inputs for book only
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            typeClicked = 1;
            AddItemSP.Visibility = Visibility.Visible;
            AddItemSP.Visibility = Visibility.Visible;
            AddBook_AuthorTB.Visibility = Visibility.Visible;
            AddBook_AuthorTBox.Visibility = Visibility.Visible;
            AddBook_ShortCutTB.Visibility = Visibility.Visible;
            AddBook_ShortCutTBox.Visibility = Visibility.Visible;
            AddBook_CopyNumTB.Visibility = Visibility.Collapsed;
            AddBook_CopyNumTBox.Visibility = Visibility.Collapsed;
        }

        //filtering the inputs for Journal only
        private void AddJournal_Click(object sender, RoutedEventArgs e)
        {
            typeClicked = 2;
            AddItemSP.Visibility = Visibility.Visible;
            AddItemSP.Visibility = Visibility.Visible;
            AddBook_AuthorTB.Visibility = Visibility.Collapsed;
            AddBook_AuthorTBox.Visibility = Visibility.Collapsed;
            AddBook_ShortCutTB.Visibility = Visibility.Collapsed;
            AddBook_ShortCutTBox.Visibility = Visibility.Collapsed;
            AddBook_CopyNumTB.Visibility = Visibility.Visible;
            AddBook_CopyNumTBox.Visibility = Visibility.Visible;
        }

        //Genre DropButton
        private void AddItemGenre_Click(object sender, SelectionChangedEventArgs e)
        {
            Genres selectedGenre = (Genres)Enum.Parse(typeof(Genres), e.AddedItems[0].ToString());
            if (newItemGenres.Contains(selectedGenre)) return;
            newItemGenres.Add(selectedGenre);
            GenresPicked.Text += $"{selectedGenre} / ";
        }

        //Add Book Button and logic
        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (_manager.AddToItemDataBase(CreateNewAbstractItem()))
            {
                GenresPicked.Text = "Item Exist Data Base!";
                return;
            }

            else
            {
                GenresPicked.Text = "Item Added To The Data Base!";
                DataList.ItemsSource = default;
                DataList.ItemsSource = _manager.GetItemDataBase();
            }
        }

        #endregion

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if(DataList.SelectedItem is AbstractItem item)
            {

                if (!_manager.Purchase(item))
                {
                    BuyRemove.Visibility = Visibility.Visible;
                    BuyRemove.Text = "Out Of Stock";
                    return;
                }
                AbstractItem var = (_manager.GetPurchaseListView().FirstOrDefault(ListItem => ListItem.Equals(item)));
                if (var == default)
                {
                    _manager.GetPurchaseListView().Add(item.CopyItem());
                }
                else var.Stock++;
            }            
            DataList.ItemsSource = _manager.GetItemDataBase();
            Purchase.ItemsSource = default;
            Purchase.ItemsSource = _manager.GetPurchaseListView();            
        }

        //Remove Completly
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataList.SelectedItem is AbstractItem item)
            {
                _manager.RemoveFromData(item);

                DataList.ItemsSource = _manager.GetItemDataBase();
            }            
        }

        //Fill stock for chosen item
        private void FillStockButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataList.SelectedItem is AbstractItem item)
            {
                item.Stock += 50;                
                DataList.ItemsSource = _manager.GetItemDataBase();
            }
        }

        //Show book info
        private void ShowBookkButton_Click(object sender, RoutedEventArgs e )
        {
            ItemDetailsSP.Visibility = Visibility.Visible;
           
            if (DataList.SelectedItem is AbstractItem item)
            {
                ItemDetails.Text = item.ToString();
            }
        }

        //Close book info
        private void CloseBookShowTB_Click(object sender, RoutedEventArgs e)
        {

            ItemDetailsSP.Visibility = Visibility.Collapsed;
            
        }

        //Checkout
        private void CheckOutButton_Click(object sender, RoutedEventArgs e)
        {
            if (Purchase.SelectedItem is AbstractItem item)
            {
                _manager.RemoveFromData(item);
                _manager.GetPurchaseListView();
                Purchase.ItemsSource = _manager.GetPurchaseListView();
            }
            CheckoutSP.Visibility = Visibility.Visible;
        }

        //Close window
        private void ContinuShopping_Click(object sender, RoutedEventArgs e)
        {
            _manager.GetPurchaseListView().Clear();
            Purchase.ItemsSource = default;
            Purchase.ItemsSource = _manager.GetPurchaseListView();
            CheckoutSP.Visibility = Visibility.Collapsed;
        }

        //Remove from cart
        private void RemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            if (Purchase.SelectedItem is AbstractItem item)
            {
                _manager.GetPurchaseListView().Remove(item);
                if (_manager.Return(item))
                {
                    BuyRemove.Visibility = Visibility.Visible;
                    Purchase.ItemsSource = default;
                    Purchase.ItemsSource = _manager.GetPurchaseListView();
                    DataList.ItemsSource = _manager.GetItemDataBase();
                }
            }            
        }

        //Use employee discount
        private void EmployeeDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (Purchase.SelectedItem is AbstractItem item)
            {
                _manager.GetEmployeeDiscount(item);               
            }
            Purchase.ItemsSource = default;
            Purchase.ItemsSource = _manager.GetPurchaseListView();
        }

        //Set your own discount
        private void SetNewDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (Purchase.SelectedItem is AbstractItem item)
            {
                DiscountSetter.Visibility = Visibility.Visible;
                DiscountApprove.Visibility = Visibility.Visible;
            }                 
        }

        //Set the discount
        private void SetDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(DiscountSetter.Text, out int discount) && discount < 0) return;
            if (Purchase.SelectedItem is AbstractItem item)
            {
                _manager.GetSetDiscount(item, discount);
            }
            Purchase.ItemsSource = default;
            Purchase.ItemsSource = _manager.GetPurchaseListView();
        }

        //Save information when moving Between Pages
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _manager = e.Parameter as DataBaseManager;
            base.OnNavigatedTo(e);
            DataList.ItemsSource = _manager.GetItemDataBase();
            WelcomeMessage();
        }

        private void Return_ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), _manager);
        }         
    }
}
