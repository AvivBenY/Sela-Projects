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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LibraryXaml
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {        
        EmployeeLoginPage loginPage;
        DataBaseManager _manager;
        public MainPage()
        {
            this.InitializeComponent();            
            loginPage = new EmployeeLoginPage();            
        }
        
        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReportsManagment), _manager);
        }

        private void WelcomeMessage()
        {
            Welcome_MessageBox.Text = $"Welcome {_manager.currentUser}";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is DataBaseManager mng)
            {
                _manager = mng;
            }
            else _manager = new DataBaseManager();            
            base.OnNavigatedTo(e);
            WelcomeMessage();
        }

        private void Return_ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), _manager);
        }

        private void AllBooksManagmentButton_Click(object sender, RoutedEventArgs e)
        {
                Frame.Navigate(typeof(AllBooksManagment), _manager);            
        }
    }
}
