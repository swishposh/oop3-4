using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;

namespace ooplab3GMAP
{
    class Human : MapObjectBase
    {
        public PointLatLng point { get; set; }
        public PointLatLng destinationPoint { get; set; }
        public GMapMarker marker { get; private set; }

        public event EventHandler seated;

        public Human(string name, PointLatLng Point):base(name)
        {
            this.point = Point;
        }

        public override double getDistance(PointLatLng point1)
        {
            // точки в формате System.Device.Location 
            GeoCoordinate c1 = new GeoCoordinate(point.Lat, point.Lng);
            GeoCoordinate c2 = new GeoCoordinate(point1.Lat, point1.Lng);

            // вычисление расстояния между точками в метрах 
            double distance = c1.GetDistanceTo(c2);
            return distance;
        }

        //public PointLatLng getFocus()
        //{
        //    return 0;
        //}
        public override PointLatLng getFocus() => point;

        public override GMapMarker getMarker()
        {
            marker = new GMapMarker(point)
            {
                Shape = new Image
                {
                    Width = 32, // ширина маркера
                    Height = 32, // высота маркера
                    ToolTip = name, // всплывающая подсказка 
                    Margin = new System.Windows.Thickness(-16, -16, 0, 0), // отступы 
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/human.png")) // картинка
                }
            };
            return marker;
        }


        //taxi
        // обработчик события прибытия такси 
        public void CarArrived(object sender, EventArgs args)
        {
            MessageBox.Show("the taxi came for you");
            seated?.Invoke(this, EventArgs.Empty);
            (sender as Car).Arrived -= CarArrived;
        }
    }
}
