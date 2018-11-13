using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace GoogleMapSharp.Location
{
    public class LocationBuilder : ILocationBuilder
    {
        private List<ILocation> locations;

        public LocationBuilder()
        {
            this.locations = new List<ILocation>();
        }

        public ILocationBuilder Append(ILocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            this.locations.Add(location);

            return this;
        }

        public string Build()
        {
            var output = new StringBuilder();

            if (this.locations.Any())
            {
                var length = this.locations.Count();
                var markerCnt = length - 1;

                output.Append(locations.First());

                if (length > 1)
                {
                    this.locations.Skip(1).ToList().ForEach(location =>
                    {
                        if (markerCnt >= 0)
                        {
                            output.Append("|");
                            markerCnt--;
                        }

                        output.Append(location);
                    });
                }
            }

            return output.ToString();
        }
    }
}
