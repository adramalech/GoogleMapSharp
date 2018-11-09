using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleMapSharp.DistanceMatrix
{
    public class DistanceMatrixClient : BaseGoogleMapClient, IDistanceMatrixClient
    {
        private const string endPoint = "distancematrix";

        public DistanceMatrixClient(string apiKey, HttpClient client = null) : base(apiKey, endPoint, client)
        {
        }

    }
}
