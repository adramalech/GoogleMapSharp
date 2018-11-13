using System;

namespace GoogleMapSharp.Location
{
    public class GeoLocation : IGeoLocation
    {
        private const double MAX_LONGITUDE = 180.00;
        private const double MIN_LONGITUDE = -180.00;
        private const double MAX_LATITUDE = 90.00;
        private const double MIN_LATITUDE = -90.00;

        private readonly double longitude;
        public double Longitude => longitude;

        private readonly double latitude;
        public double Latitude => latitude;

        public GeoLocation(double latitude, double longitude)
        {
            if (!isLatitudeInRange(latitude))
            {
                throw new ArgumentOutOfRangeException(nameof(latitude), $"Latitude cannot be outside of min {MIN_LATITUDE} or max {MAX_LATITUDE} range.");
            }

            if (!isLongitudeInRange(longitude))
            {
                throw new ArgumentOutOfRangeException(nameof(longitude), $"Longitude cannot be outside of min {MIN_LONGITUDE} or max {MAX_LONGITUDE} range.");
            }

            this.latitude = latitude;
            this.longitude = longitude;
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
            return $"{this.latitude},{this.longitude}";
        }
    }
}
