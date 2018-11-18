using System;
using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;

namespace GoogleMapSharp.Geocoding
{
    public class GeocodeRequest
    {
        private readonly string apiKey;
        public string ApiKey => apiKey;

        private readonly string address;
        public string Address => address;

        public GeocodeRequest(string apiKey, string address)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            this.apiKey = apiKey;
            this.address = address;
        }

        public override string ToString()
        {
            var queryStringBuilder = new QueryBuilder();

            queryStringBuilder.Add("key", this.apiKey);

            queryStringBuilder.Add("address", System.Net.WebUtility.UrlEncode(this.address));

            var queryString = queryStringBuilder.ToQueryString();

            return queryString.Value;
        }
    }
}
