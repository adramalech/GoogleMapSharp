using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

namespace GoogleMapSharp.Geocoding
{
  public class GeocodingClient : IGeocodingClient, IDisposable
  {
    private const string BASE_URL = @"https://maps.googleapis.com/maps/api/geocode/json";

    private readonly HttpClient httpClient;

    public GeocodingClient(HttpClient httpClient = null)
    {
      if (httpClient != null)
      {
        httpClient.BaseAddress = new Uri(BASE_URL);
        this.httpClient = httpClient;
      }
      else
      {
        this.httpClient = new HttpClient() { BaseAddress = new Uri(BASE_URL) };
      }
    }

    public Task<HttpResponseMessage> GetGeocodedLocation(IGeocodeRequest request, CancellationToken ct = default(CancellationToken))
    {
      if (request == null)
      {
        throw new ArgumentNullException(nameof(request));
      }

      return this.httpClient.GetAsync(request.ToString(), ct);
    }

    public Task<HttpResponseMessage> GetReverseGeocodedLocation(IReverseGeocodeRequest request, CancellationToken ct = default(CancellationToken))
    {
      if (request == null)
      {
        throw new ArgumentNullException(nameof(request));
      }

      return this.httpClient.GetAsync(request.ToString(), ct);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                this.httpClient.Dispose();
            }

            disposedValue = true;
        }
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(true);
    }
    #endregion
  }
}
