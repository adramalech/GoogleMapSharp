using System;
using System.Text;
using System.Collections.Generic;

namespace GoogleMapSharp.Location
{
    public class EncodedPolylineLocation : IEncodedPolylineLocation
    {
        private const double MAX_LONGITUDE = 180.00;
        private const double MIN_LONGITUDE = -180.00;
        private const double MAX_LATITUDE = 90.00;
        private const double MIN_LATITUDE = -90.00;

        private readonly string polyline;
        public string Polyline => polyline;

        public EncodedPolylineLocation(string polyline)
        {
            this.polyline = polyline;
        }

        public EncodedPolylineLocation(double latitude, double longitude)
        {
            if (!isLatitudeInRange(latitude))
            {
                throw new ArgumentOutOfRangeException(nameof(latitude), $"Latitude cannot be outside of min {MIN_LATITUDE} or max {MAX_LATITUDE} range.");
            }

            if (!isLongitudeInRange(longitude))
            {
                throw new ArgumentOutOfRangeException(nameof(longitude), $"Longitude cannot be outside of min {MIN_LONGITUDE} or max {MAX_LONGITUDE} range.");
            }

            this.polyline = encodePolyline(latitude) + encodePolyline(longitude);
        }

        private string encodePolyline(double value)
        {
            var coordinate = new StringBuilder();
            bool hasNext;

            int curValue = (int)(value * 1e5);
            curValue = curValue << 1;

            if (value < 0)
            {
                curValue = ~curValue;
            }

            var nextValue = 0;
            var encValue = 0;

            do
            {
                nextValue = (curValue >> 5);
                hasNext = (nextValue > 0);
                encValue = curValue & 0x1f;

                if (hasNext)
                {
                    encValue = encValue | 0x20;
                }

                encValue = encValue + 0x3f;

                curValue = nextValue;

                coordinate.Append((char)encValue);

            } while (hasNext);

            return coordinate.ToString();
        }

        private bool isLatitudeInRange(double latitude)
        {
            return (latitude >= MIN_LATITUDE && latitude <= MAX_LATITUDE);
        }

        private bool isLongitudeInRange(double longitude)
        {
            return (longitude >= MIN_LONGITUDE && longitude <= MAX_LONGITUDE);
        }

        public override string ToString()
        {
            return $"enc:{this.polyline}";
        }
    }
}
