using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Evil_Cat_2._0
{
    public class Projectiles : ObjectsOnCanvas
    {
    

        public Projectiles(double width, double height, double top, double left, string uri)
                : base(width, height, top, left, uri)
        {
           
        } 

        public override void ChangeLeft(int speed)
        {
            Canvas.SetLeft(_image, Left + speed);            
            Left = Left + speed;
        }        
    }
}
