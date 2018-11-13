namespace GoogleMapSharp.Location
{
    public interface ILocationBuilder
    {
        ILocationBuilder Append(string location);
        ILocationBuilder Append(IGeoLocation location);
        ILocationBuilder Append(IEncodedPolylineLocation location);
        string Build();
    }
}
