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
    public sealed partial class ReportsManagment : Page
    {
        public string[] Genres
        {
            get
            {
                List<string> GenresList = new List<string>(Enum.GetNames(typeof(Genres)));
                GenresList.Insert(0, "All Genres");
                return GenresList.ToArray();
            }           
        }
        public List<Genres> newItemGenres = new List<Genres>();
        DataBaseManager _manager;        

        public ReportsManagment()
        {
            this.InitializeComponent();            
        }

        private void WelcomeMessage()
        {
            Welcome_MessageBox.Text = $"Welcome {_manager.currentUser}";
        }

        #region Filters    

        #region For All
        //By Type(All)
        private void All_Click(object sender, RoutedEventArgs e)
        {
            PriceTextBlock.Visibility = Visibility.Visible;
            CBGenre.Visibility = Visibility.Visible;
            //TypePick_DropDown.Content = "All Types";
            BookTypeSP.Visibility = Visibility.Collapsed;
            JournalTypeSP.Visibility = Visibility.Collapsed;
            DataList.ItemsSource = _manager.GetItemDataBase();
        }

        //By Name(Single Item)
        private void TextBox_ByName_TextChanged(object sender, TextChangedEventArgs e)
        {                 
            DataList.ItemsSource = _manager.GetItemByName(ByName.Text.ToUpper(), _manager.GetItemDataBase());
        }

        //All Items By Price
        private void TextBox_ByPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            int _money;
            if (int.TryParse(ByPrice.Text, out _money) && _money > 0)
            {
                DataList.ItemsSource = _manager.ItemsArrByPrice(_money, _manager.GetItemDataBase());
            }
        }

        //All Items By Genre
        private void ItemGenre_Click(object sender, SelectionChangedEventArgs e)
        {
            DataList.ItemsSource = _manager.GetDataBaseByGenre(CBGenre.SelectedItem.ToString(), _manager.GetItemDataBase());
            if (CBGenre.SelectedIndex == 0)
            {
                DataList.ItemsSource = _manager.GetItemDataBase();
            }
        }
        #endregion

        #region Book Type Only
        //By Type(Book)
        private void Book_Click(object sender, RoutedEventArgs e)
        {
            CBGenre.Visibility = Visibility.Collapsed;
            PriceTextBlock.Visibility = Visibility.Collapsed;
            ByPrice.Visibility = Visibility.Collapsed;
            //TypePick_DropDown.Content = "Book";
            BookTypeSP.Visibility = Visibility.Visible;
            JournalTypeSP.Visibility = Visibility.Collapsed;
            DataList.ItemsSource = _manager.GetDatabaseClass().CreateListByType(1);
        }

        //By Price (Book)
        private void TextBox_BookByPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            int _money;
            if (int.TryParse(BookByPrice.Text, out _money) && _money > 0)
            {
                DataList.ItemsSource = _manager.ItemsArrByPrice(_money, _manager.ItemsArrByPrice(_money, _manager.GetBooksDataBase()));
            }
        }

        //By Author(Books Only)
        private void TextBox_ByAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_manager.GetAuthor().Contains(TextBox_ByAuthor.Text.ToUpper()))
            {
                DataList.ItemsSource = _manager.ArrByAuthor(TextBox_ByAuthor.Text.ToUpper());
            }
        }

        //By ISBN (Book Only)
        private void TextBox_ByISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            long _isbn;
            if (long.TryParse(TextBox_ISBN.Text, out _isbn) && _isbn > 0)
            {
                DataList.ItemsSource = _manager.GetBookByISBN(_isbn);
            }
        }

        //Books By Genre (Books Only)
        private void BooksGenre_Click(object sender, SelectionChangedEventArgs e)
        {
            DataList.ItemsSource = _manager.GetDataBaseByGenre(CBBooksGenre.SelectedItem.ToString(), _manager.GetBooksDataBase());
            if (CBGenre.SelectedIndex == 0)
            {
                DataList.ItemsSource = _manager.GetBooksDataBase();
            }
        }

        #endregion

        #region Journal Type Only
        //By Type(Journal)
        private void Journal_Click(object sender, RoutedEventArgs e)
        {
            CBGenre.Visibility = Visibility.Collapsed;
            PriceTextBlock.Visibility = Visibility.Collapsed;
            ByPrice.Visibility = Visibility.Collapsed;
            BookTypeSP.Visibility = Visibility.Collapsed;
            //TypePick_DropDown.Content = "Journal";
            JournalTypeSP.Visibility = Visibility.Visible;
            DataList.ItemsSource = _manager.GetDatabaseClass().CreateListByType(2);
        }

        //By Price(Journals Only)
        private void TextBox_JournalByPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            int _money;
            if (int.TryParse(JournalByPrice.Text, out _money) && _money > 0)
            {
                DataList.ItemsSource = _manager.ItemsArrByPrice(_money, _manager.ItemsArrByPrice(_money, _manager.GetJournalsDataBase()));
            }
        }

        //By ISSN Number (Journal Only)
        private void TextBox_ByISSN_TextChanged(object sender, TextChangedEventArgs e)
        {
            long _issn;
            if (long.TryParse(TextBox_ByISSN.Text, out _issn) && _issn > 0)
            {                
                DataList.ItemsSource = _manager.GetJournalByISSN(_issn);
            }
        }

        //By Copy Number (Journal Only)
        private void TextBox_ByCopyNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            int _copyNum;
            if (int.TryParse(TextBox_CopyNum.Text, out _copyNum) && _copyNum > 0)
            {
                DataList.ItemsSource = _manager.GetJournalByCopy(_copyNum);
            }
        }

        //Journals By Genre (Journal Only)
        private void JournalsGenre_Click(object sender, SelectionChangedEventArgs e)
        {
            DataList.ItemsSource = _manager.GetDataBaseByGenre(CBJournalsGenre.SelectedItem.ToString(), _manager.GetJournalsDataBase());
            if (CBGenre.SelectedIndex == 0)
            {
                DataList.ItemsSource = _manager.GetJournalsDataBase();
            }
        }

        #endregion

        #endregion

        //Save information when moving Between Pages
        #region saveInfo
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is DataBaseManager mng)
            {
                _manager = mng;
            }
            else _manager = new DataBaseManager();
            DataList.ItemsSource = _manager.GetItemDataBase();
            base.OnNavigatedTo(e);
            WelcomeMessage();
        }

        private void Return_ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), _manager);
        }
        #endregion
    }
}
