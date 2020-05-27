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
using System.Threading;
using System.Windows;

namespace ooplab3GMAP
{
    class Car : MapObjectBase
    {
        PointLatLng point = new PointLatLng();
        
        List<Human> passengers = new List<Human>();
        public MapRoute route { get; private set; }
        GMapMarker marker;

        Human human;

        // событие прибытия 
        public event EventHandler Arrived;
        public event EventHandler Follow;

        public Car(string name, PointLatLng Point) : base(name)
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
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/car.png")) // картинка
                }
            };
            return marker;
        }


        //taxi  
        public MapRoute moveTo(PointLatLng endpoint)
        {
            // провайдер навигации
            RoutingProvider routingProvider = GMapProviders.OpenStreetMap;
            // определение маршрута 
             route = routingProvider.GetRoute(
                point, // начальная точка маршрута 
                endpoint, // конечная точка маршрута 
                false, // поиск по шоссе (false - включен) 
                false, // режим пешехода (false - выключен) 
                15);
            // получение точек маршрута 

            Thread newThread = new Thread(MoveByRoute);
            newThread.Start();
            return route;
        }

        // метод перемещения по маршруту
        private void MoveByRoute()
        {
            // последовательный перебор точек маршрута 
            foreach (var point in route.Points)
            {
                    // делегат, возвращающий управление в главный поток 
                    Application.Current.Dispatcher.Invoke(delegate
                        {
                            this.point = point;
                        // изменение позиции маркера 
                        marker.Position = point;

                            if (human != null) 
                            {
                                human.marker.Position = point;
                                Follow?.Invoke(this, null);
                            }
                        });
                    // задержка 500 мс 
                    Thread.Sleep(500);
            }

            if (human == null)
                // отправка события о прибытии после достижения последней точки маршрута 
                Arrived?.Invoke(this, null);
                else
                {
                    MessageBox.Show("so, here we are!");
                    human = null;
                    Arrived?.Invoke(this, null);
                }
        }

        public void inTocar(object sender, EventArgs args)
        {
            human = (Human)sender;
            moveTo(human.destinationPoint);
            human.point = point;
            (sender as Human).seated -= inTocar;
        }
    }
}
