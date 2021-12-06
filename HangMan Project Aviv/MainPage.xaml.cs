
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HangMan_Project_Aviv
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static public Canvas _canvas;
        TextBlock _SecretWord;
        Words_Difficulty _takeWordOut = new Words_Difficulty();
        string _secretWordHandler = "";
        string _letter;
        char _letterChar;                
        int _guessesToLose = 9;
        private int _wrongGuessCounter = 0;  
        
        public MainPage()
        {
            this.InitializeComponent();                        
            _SecretWord = SecretBlock;            
            _canvas = Canvas;
            _takeWordOut.TakeWordOutOfEasyArr(WordBank._easyWordsArr);
            _secretWordHandler = "";
            for (int i = 0; i < Words_Difficulty.chosenWord.Length; i++)
            {
                _secretWordHandler += "_";
            }
            DisplayCopySecretWord();
        }

        #region Difficulty                   
        private void DisplayCopySecretWord()
        {
            _SecretWord.Text = "";
            for (int i = 0; i < _secretWordHandler.Length; i++)
            {
                _SecretWord.Text += _secretWordHandler.Substring(i, 1);
                _SecretWord.Text += " ";
            }
        }

        //Choosing hard difficulty and changing number of letters.
        private void HardMode_Click(object sender, RoutedEventArgs e)
        {
            _SecretWord.Text = "";
            _secretWordHandler = "";
            _takeWordOut.TakeWordOutOfHardArr(WordBank._hardWordsArr);            
            for (int i = 0; i < Words_Difficulty.chosenWord.Length; i++)
            {
                _secretWordHandler += "_";
            }
            DisplayCopySecretWord();
        }

        //Choosing easymode
        private void EasyMode_Click(object sender, RoutedEventArgs e)
        {
            _SecretWord.Text = "";
            _secretWordHandler = "";
            _takeWordOut.TakeWordOutOfEasyArr(WordBank._easyWordsArr);
            for (int i = 0; i < Words_Difficulty.chosenWord.Length; i++)
            {
                _secretWordHandler += "_";
            }
            DisplayCopySecretWord();
        }
        #endregion

        #region Letters_Check
        //Finding and definning which letter button is clicked
        private void Letter_Button_Click(object sender, RoutedEventArgs e)
        {
            EasyMode.IsEnabled = false;
            HardMode.IsEnabled = false;
            Button x = sender as Button;
            x.Opacity = 0.5;
            x.IsEnabled = false;
            _letter = x.Content.ToString();
            _letterChar = char.Parse(_letter);
            isLetterInWord(_letterChar);
            if (isLetterInWord(_letterChar) == false) WrongGuess();
            else ShowSecretWord(_letterChar);                                    
        }

        //Finding if the letter picked is in the secret word
        public bool isLetterInWord(char letter)
        {
            for (int i = 0; i < Words_Difficulty.chosenWord.Length; i++)
            {
                if (letter == Words_Difficulty.chosenWord[i])
                    return true;             
            }
            return false;
        }

        // Revealing the secret word or winning the game.
        public void ShowSecretWord(char letter)
        {
            char[] _changedCharArr = _secretWordHandler.ToCharArray();
            char[] chosenWordCharArr = Words_Difficulty.chosenWord.ToCharArray();
            for (int i = 0; i < chosenWordCharArr.Length; i++)
            {
                if (letter == chosenWordCharArr[i])
                    _changedCharArr[i] = letter;
            }
            _secretWordHandler = new string (_changedCharArr);
            if (_secretWordHandler == Words_Difficulty.chosenWord)
            {                
                Frame.Navigate(typeof(MainPage));
            }
            DisplayCopySecretWord();
        }

        //Add hangman images if player guessed wrong & move to gameover.
        public void WrongGuess()
        {
            if (_wrongGuessCounter < _guessesToLose)
            {
                _wrongGuessCounter++;
                _canvas.Children.Add(new ImagesOnScreen(575, 790, 120, 0, $"/Assets/projectHangPic{_wrongGuessCounter}.png")._image);
            }
            else GameIsOver();
        }
        #endregion

        #region Navigation
        //Restart Game.
        private void Restart_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        //Navigate to GameOver page.
        public void GameIsOver()
        {
            Frame.Navigate(typeof(GameOver));    
        }

        //Exit game.
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        #endregion 
    }
}