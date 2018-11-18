using System;
using GoogleMapSharp.Location;
using Microsoft.AspNetCore.Http.Extensions;

namespace GoogleMapSharp.Geocoding
{
    public class ReverseGeocodeRequest : IReverseGeocodeRequest
    {
        private readonly string apiKey;
        public string ApiKey => apiKey;

        private readonly IGeoLocation latLng;
        public IGeoLocation LatLng => latLng;

        public ReverseGeocodeRequest(string apiKey, IGeoLocation latLng)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            if (latLng == null)
            {
                throw new ArgumentNullException(nameof(latLng));
            }

            this.apiKey = apiKey;
            this.latLng = latLng;
        }

        public override string ToString()
        {
            var queryStringBuilder = new QueryBuilder();

            queryStringBuilder.Add("key", this.apiKey);

            queryStringBuilder.Add("latlng", this.latLng.ToString());

            var queryString = queryStringBuilder.ToQueryString();

            return queryString.Value;
        }
    }
}