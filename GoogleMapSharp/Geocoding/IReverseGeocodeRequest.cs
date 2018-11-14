using GoogleMapSharp.Location;

namespace GoogleMapSharp.Geocoding
{
    public interface IReverseGeocodeRequest
    {
        IGeoLocation LatLng { get; }
        string ApiKey { get; }
    }
}