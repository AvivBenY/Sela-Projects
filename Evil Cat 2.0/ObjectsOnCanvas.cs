using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Evil_Cat_2._0
{
    public class ObjectsOnCanvas
    {
        public Image _image { get; set; }
        public double Width { get; set; } 
        public double Height { get; set; } 
        public double Top { get; set; } 
        public double Left { get; set; }         
        public string Uri { get; set; }

        public ObjectsOnCanvas( double width, double height, double top, double left, string uri)
        {
            _image = new Image();
            Width = width;
            Height = height;
            Top = top;
            Left = left;            
            Uri = uri;
            _image.Source = new BitmapImage(new Uri($"ms-appx://{uri}"));
            _image.Width = width;
            _image.Height = height;
            Canvas.SetLeft(_image, left);
            Canvas.SetTop(_image, top);            
        }

        public virtual Image GetImage()
        {
            return _image;
        }

        public virtual void ChangeLeft (int speed)
        {
            Canvas.SetLeft(_image, Left - speed);
            Left = Left - speed;
        }

        public void SetImage(string uri)
        {
           _image.Source = new BitmapImage(new Uri($"ms-appx://{uri}"));            
        }
    }
}
    

