using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleMapSharp
{
    public class BaseGoogleMapClient : IDisposable
    {
        private const string BASE_URL = @"https://maps.googleapis.com/maps/api/";

        private const string OUTPUT_FORMAT = "json";

        protected readonly string apiEndPoint;

        protected readonly string apiKey;

        private readonly HttpClient httpClient;

        public Task<HttpResponseMessage> GetAsync(string reqUri, CancellationToken ct = default(CancellationToken)) => this.httpClient.GetAsync(reqUri, ct);

        public Task<HttpResponseMessage> PostAsync(string reqUri, HttpContent content, CancellationToken ct = default(CancellationToken)) => this.httpClient.PostAsync(reqUri, content, ct);

        internal BaseGoogleMapClient(string apiKey, string apiEndPoint, HttpClient httpClient = null)
        {
            this.httpClient = httpClient ?? new HttpClient();
            this.httpClient.BaseAddress = new Uri(BASE_URL + apiEndPoint + @"/" + OUTPUT_FORMAT);
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
