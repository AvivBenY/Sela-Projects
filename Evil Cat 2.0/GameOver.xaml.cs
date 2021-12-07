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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Evil_Cat_2._0
{
    public sealed partial class GameOver : Page
    {
        Canvas _gameOver;
        TextBlock _meterCounter;
        public GameOver()
        {
            this.InitializeComponent();
            _gameOver = GameOverBoard;
            _meterCounter = new TextBlock();
            Canvas.SetLeft(_meterCounter, 425);
            Canvas.SetTop(_meterCounter, 579);
            _meterCounter.Width = 111;
            _meterCounter.Height = 385;
            _meterCounter.FontSize = 55;                
            _meterCounter.Text = $"{StaticVariables._highScore}";
            _gameOver.Children.Add(_meterCounter);
        }

        private void ExitGame_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void BackToMain_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
