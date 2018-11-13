using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

namespace GoogleMapSharp.Geocoding
{
  public class GeocodingClient : IGeocodingClient, IDisposable
  {
    private const string BASE_URL = @"https://maps.googleapis.com/maps/api/geocode/json?";

    private readonly string apiKey;

    private readonly HttpClient httpClient;

    public GeocodingClient(string apiKey, HttpClient httpClient = null)
    {
      if (string.IsNullOrEmpty(apiKey) || string.IsNullOrWhiteSpace(apiKey))
      {
        throw new ArgumentNullException(nameof(apiKey), "Unable to create client with an empty api key.");
      }

      this.apiKey = apiKey;

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
