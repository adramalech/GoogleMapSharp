using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleMapSharp.Geocoding
{
  public class GeocodingClient : BaseGoogleMapClient, IGeocodingClient
  {
    private const string endPoint = "distancematrix";

    public GeocodingClient(string apiKey, HttpClient httpClient = null) : base(apiKey, endPoint, httpClient)
    {
    }


  }
}
