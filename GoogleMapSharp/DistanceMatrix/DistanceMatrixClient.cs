using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

namespace GoogleMapSharp.DistanceMatrix
{
    public class DistanceMatrixClient : IDistanceMatrixClient, IDisposable
    {
        private const string BASE_URL = @"https://maps.googleapis.com/maps/api/distancematrix/json";

        private readonly HttpClient httpClient;

        public DistanceMatrixClient(HttpClient httpClient = null)
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
