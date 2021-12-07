using System;

namespace HangMan_Project_Aviv
{
    public class Words_Difficulty
    {
        Random rand = new Random();        
        static public string chosenWord;

        //Randomly takes word out of easy array's
        #region Word Choosing
        public void TakeWordOutOfEasyArr(string[] _easyWordsArr)
        {
            chosenWord = _easyWordsArr[rand.Next(0, _easyWordsArr.Length)];
        }

        //Randomly takes word out of easy array's
        public void TakeWordOutOfHardArr(string[] hardWordsArr)
        {
            chosenWord = hardWordsArr[rand.Next(0, hardWordsArr.Length)];
        }
        #endregion
    }
}
