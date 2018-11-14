namespace GoogleMapSharp.Geocoding
{
    public interface IGeocodeRequest
    {
        string ApiKey { get; }
        string Address { get; }
    }
}