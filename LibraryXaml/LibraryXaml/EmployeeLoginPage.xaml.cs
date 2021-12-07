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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryXaml
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeeLoginPage : Page
    {
        DataBaseManager _manager = new DataBaseManager();
        public static string currentUser;
        public EmployeeLoginPage()
        {
            this.InitializeComponent(); 
            passwordBox.IsEnabled = false;           
        }

        private void userNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (userNameTB.Text.Length > 0)
            {
                passwordBox.IsEnabled = true;
            }
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _manager.Login(userNameTB.Text, passwordBox.Password);
            }
            catch (BadLoginException ex)
            {
                DataBaseManager.ErrorLog($"{ex.WrongLoginDetail} Incorrect");
                userText.Text = $"{ex.WrongLoginDetail} Incorrect";
                return;
            }
            Frame.Navigate(typeof(MainPage));
        }
    }
}
