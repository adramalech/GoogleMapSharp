using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace GoogleMapSharp.Location
{
    public class LocationBuilder : ILocationBuilder
    {
        private List<string> locations;

        public LocationBuilder()
        {
            this.locations = new List<string>();
        }

        public ILocationBuilder Append(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location));
            }

            this.locations.Add(location.Trim());

            return this;
        }

        public ILocationBuilder Append(IGeoLocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            this.locations.Add(location.ToString());

            return this;
        }

        public ILocationBuilder Append(IEncodedPolylineLocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            this.locations.Add(location.ToString());

            return this;
        }

        public ILocationBuilder Append(IPlace location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            this.locations.Add(location.ToString());

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
