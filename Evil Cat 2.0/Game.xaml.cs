
using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Evil_Cat_2._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        Canvas _gameBoard;
        DispatcherTimer _timer;
        Button _tuggleTimerBtn;
        bool _isGamePaused;
        List<string> _keys;
        List<ObjectsOnCanvas> _ObjectsOnScreen = new List<ObjectsOnCanvas>();
        List<Projectiles> _EvilShots = new List<Projectiles>();
        Random rand = new Random();
        Random furnitureRand = new Random();
        string[] uriArr = { "/Assets/furniture/sofa1.png", "/Assets/furniture/22.png",
            "/Assets/furniture/1234.png", "/Assets/furniture/123.png","/Assets/furniture/kid1.png",
            "/Assets/furniture/kid2.png", "/Assets/furniture/kid3.png", "/Assets/furniture/kid4.png",
            "/Assets/furniture/laundry1.png", "/Assets/furniture/laundry2.png"};

        string[] healthBarArr = { "/Assets/4.png", "/Assets/HealthBar5.png", "/Assets/HealthBar4.png",
            "/Assets/HealthBar3.png", "/Assets/HealthBar2.png", "/Assets/HealthBar1.png", "/Assets/HealthBar1.png"} ;
        int _healthBarCounter = 0;
        public Game()
        {
            this.InitializeComponent();
            _keys = new List<string>();
            _gameBoard = GameBoard;
            _timer = new DispatcherTimer();
            _tuggleTimerBtn = TuggleTimerButton;            
            Window.Current.CoreWindow.KeyDown += User_KeyDown;
            Window.Current.CoreWindow.KeyUp += User_KeyUp;            

            _isGamePaused = false;
            _timer.Tick += GameLoop;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            _timer.Start();

            _gameBoard.Children.Add(new ObjectsOnCanvas(300, 150, 15, 1150, healthBarArr[0]).GetImage());
        }

        #region GameLoop
        private void GameLoop(object sender, object e)
        {            
            MeterCounter.Text = "Meters :" + StaticVariables._counter.ToString();
            StaticVariables._counter++;

            HandlePlayerControls();

            double top = Canvas.GetTop(EvilCatPlayer);
            if (!isCollidingWithCanvasTop(EvilCatPlayer, top + 5))
            {
                Canvas.SetTop(EvilCatPlayer, top + 10);
            }

            //projectile creation
            if (_keys.Contains("X"))
            {
                _EvilShots.Add(new Projectiles(100, 100, Canvas.GetTop(EvilCatPlayer) + 35, Canvas.GetLeft(EvilCatPlayer) + EvilCatPlayer.Width, "/Assets/projectile.gif"));
                _gameBoard.Children.Add(_EvilShots[_EvilShots.Count - 1].GetImage());
            }

            ProjectileMovment();

            if (StaticVariables._counter % 35 == 0)
            {
                _ObjectsOnScreen.Add(new ObjectsOnCanvas(180, 180, rand.Next(650, 900), 1390, uriArr[rand.Next(0, 10)]));
                _gameBoard.Children.Add(_ObjectsOnScreen[_ObjectsOnScreen.Count - 1].GetImage());
            }

            //movment of the objects (left) and healthbar strikes 
            if (StaticVariables._counter > 20) 
            {
                for (int j = 0; j < _ObjectsOnScreen.Count; j++)
                {
                    double objLeft = Canvas.GetLeft(_ObjectsOnScreen[j].GetImage());
                    if (objLeft >= 0)
                    {
                        if(0 < StaticVariables._counter && StaticVariables._counter < 1000)
                        _ObjectsOnScreen[j].ChangeLeft(25);
                        if (1000 < StaticVariables._counter && StaticVariables._counter < 1500)
                            _ObjectsOnScreen[j].ChangeLeft(35);
                        if (1500 < StaticVariables._counter && StaticVariables._counter < 2300)
                            _ObjectsOnScreen[j].ChangeLeft(45);
                        if (2300 < StaticVariables._counter )
                            _ObjectsOnScreen[j].ChangeLeft(60);
                    }
                    else
                    {
                        _gameBoard.Children.Remove(_ObjectsOnScreen[j].GetImage());
                        _ObjectsOnScreen.Remove(_ObjectsOnScreen[j]);
                        _healthBarCounter++;
                        if(_healthBarCounter == 6)
                        {
                            _timer.Stop();
                            if (StaticVariables._counter > StaticVariables._highScore)
                                StaticVariables._highScore = StaticVariables._counter;
                            StaticVariables._counter = 1;
                            Frame.Navigate(typeof(GameOver));
                        }
                        _gameBoard.Children.Add(new ObjectsOnCanvas(300, 150, 15, 1150, healthBarArr[_healthBarCounter]).GetImage());
                    }
                }
            }                        
        }
        #endregion

        #region Projectile Movment
        //collusion and movment of the projectiles with the objects
        public void ProjectileMovment() 
        {
            for (int n = 0; n < _EvilShots.Count; n++)
            {
                double projLeft = Canvas.GetLeft(_EvilShots[n].GetImage());
                if (projLeft < 1400)
                {
                    _EvilShots[n].ChangeLeft(25);
                }
                else
                {
                    _gameBoard.Children.Remove(_EvilShots[n].GetImage());
                    _EvilShots.Remove(_EvilShots[n]);
                }
                if (_EvilShots.Count > 0 && _ObjectsOnScreen.Count > 0)
                {
                    for (int m = 0; m < _ObjectsOnScreen.Count; m++)
                    {
                        double shotTop = _EvilShots[n].Top;
                        double itemTop = _ObjectsOnScreen[m].Top;
                        double itemHeight = _ObjectsOnScreen[m].Top + _ObjectsOnScreen[m].Height;
                        double shotRight = _EvilShots[n].Left + _EvilShots[n].Width;
                        double itemLeft = _ObjectsOnScreen[m].Left;
                        if (shotTop > itemTop && shotTop < itemHeight && shotRight > itemLeft)
                        {
                            _gameBoard.Children.Remove(_EvilShots[n].GetImage());
                            _gameBoard.Children.Remove(_ObjectsOnScreen[m].GetImage());
                            _EvilShots.Remove(_EvilShots[n]);
                            _ObjectsOnScreen.Remove(_ObjectsOnScreen[m]);
                            n = n - 1;
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region Control Pannel
        public void User_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            _keys.RemoveAll(key => key == args.VirtualKey.ToString());
        }

        private void User_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            _keys.Add(args.VirtualKey.ToString());
        }

        private void HandlePlayerControls()
        {
            double top = Canvas.GetTop(EvilCatPlayer);
            double left = Canvas.GetLeft(EvilCatPlayer);

            if (_keys.Contains("Up"))
            {
                if (!isCollidingWithCanvasTop(EvilCatPlayer, top - 30))
                {
                    Canvas.SetTop(EvilCatPlayer, top - 30);
                }
            }
        }

        private bool isCollidingWithCanvasTop(FrameworkElement objectOnCanvas, double newDirection)
        {
            double canvasHeight = _gameBoard.ActualHeight;

            if (_keys.Contains("Up"))
            {
                return newDirection + Canvas.GetTop(EvilCatPlayer) < 1150;
            }
            return newDirection + objectOnCanvas.ActualHeight > canvasHeight;
        }
        #endregion

        #region timer
        private void TuggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isGamePaused)
            {
                _timer.Start();
                _isGamePaused = false;
                TuggleTimerButton.Content = "Pause";
            }
            else
            {
                _timer.Stop();
                _isGamePaused = true;
                TuggleTimerButton.Content = "Continu";
            }
        }
        #endregion 
    }
}                     