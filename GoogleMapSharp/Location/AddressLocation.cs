using System;

namespace GoogleMapSharp.Location
{
    public class AddressLocation : ILocation
    {
        public readonly string address;

        public string Address => address;

        public AddressLocation(string address)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            this.address = address.Trim();
        }

        public override string ToString()
        {
            return this.address;
        }
    }
}
