using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ooplab3GMAP
{
    class Route : MapObjectBase
    {
        public List<PointLatLng> points = new List<PointLatLng>();

        public Route(string name, List<PointLatLng> Points):base(name)

        {
            this.points = Points;
        }

        public override double getDistance(PointLatLng point)
        {
            // точки в формате System.Device.Location 
            GeoCoordinate c1 = new GeoCoordinate(point.Lat, point.Lng);
            GeoCoordinate c2 = new GeoCoordinate(point.Lat, point.Lng);

            // вычисление расстояния между точками в метрах 
            double distance = c1.GetDistanceTo(c2);

            return distance;
        }

        //public PointLatLng getFocus()
        //{
        //    return 0;
        //}
        public override PointLatLng getFocus() => points.Last();


        public override GMapMarker getMarker()
        {
            GMapMarker marker = new GMapRoute(points)
            {
                Shape = new Path
                {
                    Stroke = Brushes.Black, // стиль обводки         
                    Fill = Brushes.Violet, // стиль заливки         
                    Opacity = 0.7, // прозрачность  
                    StrokeThickness = 4, // толщина обводки 
                    ToolTip = name,
                }
            };

            return marker;
        }
    }
}
