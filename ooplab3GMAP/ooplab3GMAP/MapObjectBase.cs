using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;

namespace ooplab3GMAP
{
    public abstract class MapObjectBase
    {
        public string name;

        public MapObjectBase(string name)
        {
            this.name = name;
        }
        public string getName() => name;

        public abstract PointLatLng getFocus();

        public abstract GMapMarker getMarker();

        public abstract double getDistance(PointLatLng point);
    }
}
