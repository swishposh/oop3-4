using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;

namespace ooplab3GMAP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //добавление маркеров на карте
        //добавление имени
        //координаты

        List<PointLatLng> pointsofarea = new List<PointLatLng>();
        List<MapObjectBase> mapObjects = new List<MapObjectBase>();

        static PointLatLng startPoint;
        static PointLatLng endPoint;

        public MainWindow()
        {
            InitializeComponent();

            Bcallcar.IsEnabled = false;

            CBobjects.IsEnabled = false;
            Baddname.IsEnabled = false;
            Breset.IsEnabled = false;
            TBname.IsEnabled = false;
            Ladd.IsEnabled = false;

            TBsearch.IsEnabled = false;
            Bfound.IsEnabled = false;
            LBresultofsearch.IsEnabled = false;
            Lresult.IsEnabled = false;
            Lsearch.IsEnabled = false;
        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
            // настройка доступа к данным     
            GMaps.Instance.Mode = AccessMode.ServerAndCache;          
            // установка провайдера карт     
            Map.MapProvider = OpenStreetMapProvider.Instance;          
            // установка зума карты     
            Map.MinZoom = 2;     
            Map.MaxZoom = 17;     
            Map.Zoom = 15; 

            // установка фокуса карты     
            Map.Position = new PointLatLng(55.012823, 82.950359);          
            // настройка взаимодействия с картой 
            
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter; 
            Map.CanDragMap = true; 
            Map.DragButton = MouseButton.Left;
        }


        private void Breset_Click(object sender, RoutedEventArgs e)
        {
            pointsofarea = new List<PointLatLng>();
            Lx.Content = "0";
            Ly.Content = "0";
        }

        
        private void Baddname_Click(object sender, RoutedEventArgs e)
        {
            bool exsist = false;
            if ((TBname.Text == "") & (CBobjects.SelectedIndex < 0))
                MessageBox.Show("choose a marker and enter the object name");
            else if (TBname.Text == "")
            {
                MessageBox.Show("enter the object name");
            }
            else
            {
                foreach (MapObjectBase obj in mapObjects)
                {
                    if (obj.getName() == TBname.Text)
                    {
                        MessageBox.Show("name already exist");
                        exsist = true;
                    }
                }
                if (!exsist)
                {
                    Lx.Content = "0";
                    Ly.Content = "0";
                    addMarker(CBobjects.SelectedIndex, pointsofarea);
                    pointsofarea = new List<PointLatLng>();
                }
            }
        }

        private void RBcreate_Checked(object sender, RoutedEventArgs e)
        {
            CBobjects.IsEnabled = true;
            Baddname.IsEnabled = true;
            Breset.IsEnabled = true;
            Ladd.IsEnabled = true;
            TBname.IsEnabled = true;
            Bcallcar.IsEnabled = true;

            TBsearch.IsEnabled = false;
            Bfound.IsEnabled = false;
            LBresultofsearch.IsEnabled = false;
            Lresult.IsEnabled = false;
            Lsearch.IsEnabled = false;
        }

        private void RBsearchforthenearest_Checked(object sender, RoutedEventArgs e)
        {
            TBsearch.IsEnabled = true;
            Bfound.IsEnabled = true;
            LBresultofsearch.IsEnabled = true;
            Lresult.IsEnabled = true;
            Lsearch.IsEnabled = true;

            CBobjects.IsEnabled = false;
            Baddname.IsEnabled = false;
            Breset.IsEnabled = false;
            TBname.IsEnabled = false;
            Ladd.IsEnabled = false;
        }


        private void LBresultofsearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (MapObjectBase obj_1 in mapObjects)
            {
                if (obj_1.getName() == (string)LBresultofsearch.SelectedItem)
                {
                   Map.Position = obj_1.getFocus();
                }
            }
        }

        private void Bfound_Click(object sender, RoutedEventArgs e)
        {
            int ch = 0;
            LBresultofsearch.Items.Clear();
            if (TBsearch.Text == "")
                MessageBox.Show("enter the object name");

            foreach (MapObjectBase obj in mapObjects)
            {
                if (obj.name.Contains(TBsearch.Text))
                {
                    LBresultofsearch.Items.Add(obj.name);
                    ch++;
                }
            }
            if (ch == 0) MessageBox.Show("the object is not found");
        }

        private void CBobjects_Loaded(object sender, RoutedEventArgs e)
        {
            CBobjects.Items.Add("area");
            CBobjects.Items.Add("car");
            CBobjects.Items.Add("human");
            CBobjects.Items.Add("location");
            CBobjects.Items.Add("route");
        }
       
        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pointsofarea.Add(Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y));
            Lx.Content = pointsofarea.Last().Lat;
            Ly.Content = pointsofarea.Last().Lng;
        }

        public void addMarker(int index, List<PointLatLng> points)
        {
            if (CBobjects.SelectedIndex < 0)
            {
                MessageBox.Show("choose a marker");
            }

            MapObjectBase mapObject = null; 
            
            switch (index)
            {
                case 0:
                    { 
                        if (points.Count < 3)
                        {
                            MessageBox.Show("select three points");
                            return;
                        }
                        mapObject = new Area(TBname.Text, points);
                        TBname.Clear();
                        break;
                    }
                case 1:
                    {
                        if (points.Count < 1)
                        {
                            MessageBox.Show("select one point");
                            return;
                        }
                        mapObject = new Car(TBname.Text, points.Last());
                        TBname.Clear();
                        break;
                        
                    }
                case 2:
                    {
                        if (points.Count < 1)
                        {
                            MessageBox.Show("select one point");
                            return;
                        }
                        mapObject = new Human(TBname.Text, points.Last());
                        TBname.Clear();
                        break;
                    }
                case 3:
                    {
                        if (points.Count < 1)
                        {
                            MessageBox.Show("select one point");
                            return;
                        }
                        mapObject = new Location(TBname.Text, points.Last());
                        TBname.Clear();
                        break;
                    }
                case 4:
                    {
                        if (points.Count < 2)
                        {
                            MessageBox.Show("select two points");
                            return;
                        }
                        mapObject = new Route(TBname.Text, points);
                        TBname.Clear();
                        break;
                    }
            }
            if (mapObject != null)
            {
                mapObjects.Add(mapObject);
                Map.Markers.Add(mapObject.getMarker());
            }
        }
            
        //taxi
        private void Bcallcar_Click(object sender, RoutedEventArgs e)
        {
            endPoint = pointsofarea.Last();

            if (pointsofarea.Count != 0)
            {
                progressLine.Value = 0;
                foreach (MapObjectBase obj in mapObjects)
                    if (obj is Human)
                        startPoint = (obj.getFocus());

                Car taxi = null;
                Human pl = null;

                foreach (MapObjectBase obj in mapObjects)
                {
                    if (obj is Human)
                    {
                        pl = (Human)obj;
                        pl.destinationPoint = pointsofarea.Last(); 
                        break;
                    }
                }

                foreach (MapObjectBase obj in mapObjects)
                {
                    if (obj is Car)
                    {
                        taxi = (Car)obj;
                        break;
                    }
                }

                var t = taxi.moveTo(startPoint);
                addMarker(4, t.Points);

                // провайдер навигации 
                RoutingProvider routingProvider = GMapProviders.OpenStreetMap;
                // определение маршрута 
                MapRoute route = routingProvider.GetRoute(
                    startPoint, // начальная точка маршрута 
                    endPoint, // конечная точка маршрута 
                    false, // поиск по шоссе (false - включен) 
                    false, // режим пешехода (false - выключен) 
                    15);
                addMarker(4, route.Points);
                taxi.Arrived += pl.CarArrived;
                pl.seated += taxi.inTocar;
                taxi.Follow += Focus_Follow;
            }
            else
            {
                MessageBox.Show("select an endpoint");
            }
        }


        private void Focus_Follow(object sender, EventArgs args)
        {
            Car c = (Car)sender;
            progressLine.Maximum = c.route.Points.Count;
            Map.Position = c.getFocus();

            if (progressLine.Value == progressLine.Maximum)
                (sender as Car).Follow -= Focus_Follow;

            if (progressLine.Value != progressLine.Maximum)
                progressLine.Value += 1;

            else
                progressLine.Value = 0;
        }
      

        private void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            LBresultofsearch.Items.Clear();

            PointLatLng point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);

            List <MapObjectBase> SortedList = mapObjects.OrderBy(obj => obj.getDistance(point)).ToList();
       
                foreach (MapObjectBase obj in SortedList)
                {
                    string dist = new StringBuilder()
                    .Append(obj.getName())
                    .Append(": ")
                    .Append(obj.getDistance(point).ToString("0.##"))
                    .Append(" м.").ToString();
                    LBresultofsearch.Items.Add(dist);
                }
        }

        private void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
