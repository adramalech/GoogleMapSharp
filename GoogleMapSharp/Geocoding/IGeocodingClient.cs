using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GoogleMapSharp.Geocoding
{
    public interface IGeocodingClient
    {
        Task<HttpResponseMessage> GetGeocodedLocation(IGeocodeRequest request, CancellationToken ct = default(CancellationToken));
        Task<HttpResponseMessage> GetReverseGeocodedLocation(IReverseGeocodeRequest request, CancellationToken ct = default(CancellationToken));
    }
}