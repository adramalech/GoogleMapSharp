namespace GoogleMapSharp.Location
{
    public interface ILocationBuilder
    {
        ILocationBuilder Append(ILocation location);
        string Build();
    }
}
