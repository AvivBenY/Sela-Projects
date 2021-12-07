using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace HangMan_Project_Aviv
{
    class ImagesOnScreen
    {
        public Image _image { get; set; }
        private double _width;
        private double _height;
        private double _top;
        private double _left;
        private string _uri;

        //Constructor
        public ImagesOnScreen(double width, double height, double top, double left, string uri)
        {
            _image = new Image();
            _width = width;
            _height = height;
            _top = top;
            _left = left;
            _uri = uri;
            _image.Source = new BitmapImage(new Uri($"ms-appx://{uri}"));
            _image.Width = width;
            _image.Height = height;
            Canvas.SetLeft(_image, left);
            Canvas.SetTop(_image, top);
        }

        //Takes image
        public virtual Image GetImage()
        {
            return _image;
        }
    }
}
