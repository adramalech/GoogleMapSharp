using System;

namespace GoogleMapSharp.Location
{
    public class Place
    {
        private readonly string placeId;
        public string PlaceId => placeId;

        public Place(string placeId)
        {
            if (string.IsNullOrWhiteSpace(placeId))
            {
                throw new ArgumentNullException(nameof(placeId));
            }

            this.placeId = placeId;
        }

        public override string ToString()
        {
            return $"place_id:{this.placeId}";
        }
    }
}
