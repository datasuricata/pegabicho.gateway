using System;
using System.Collections.Generic;
using System.Text;

namespace begabicho.shared.Helpers
{
    public static class UtilsLocalization
    {

    }

    public class Coordinate
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class CoordinateCalc
    {
        public decimal Distance(Coordinate obj1, Coordinate obj2, bool calcMiles)
        {
            // # 1- miles, other km
            // # use 3960 for miles; 
            // # use 6371 if you want km
            double R = (calcMiles) ? 3960 : 6371; // R is earth radius.
            double dLat = this.ToRadian(obj2.Latitude - obj1.Latitude);
            double dLon = this.ToRadian(obj2.Longitude - obj1.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(this.ToRadian(obj1.Latitude)) * Math.Cos(this.ToRadian(obj2.Latitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return (decimal)d;
        }

        private double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
