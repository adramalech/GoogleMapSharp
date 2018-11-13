using System;
using GoogleMapSharp;
using GoogleMapSharp.Location;
using Xunit;

namespace GoogleMapSharp.Test.Location
{
    public class LocationBuilderTest
    {
        [Theory]
        [InlineData(80.123456, 80.123456)]
        public void GenerateSingleLocationString(double latitude, double longitude)
        {
            var result = new LocationBuilder().Append(new GeoLocation(latitude, longitude))
                                              .Build();

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(90.00001, -160.000)]
        [InlineData(-91.0000, -120.000)]
        [InlineData(80.012345, -189.0001)]
        [InlineData(-81.123456, 190.00001)]
        [InlineData(-167.001234, 200.98989)]
        public void LocationBuilder_ShouldThrowException_WhenLatLng_OutOfRange_GeoLocationAppend(double latitude, double longitude)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var result = new LocationBuilder().Append(new GeoLocation(latitude, longitude))
                                                  .Build();
            });
        }

        [Theory]
        [InlineData(90.00001, -160.000)]
        [InlineData(-91.0000, -120.000)]
        [InlineData(80.012345, -189.0001)]
        [InlineData(-81.123456, 190.00001)]
        [InlineData(-167.001234, 200.98989)]
        public void LocationBuilder_ShouldThrowException_WhenLatLng_OutOfRange_PolyLineEncodingGeoLocation(double latitude, double longitude)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var result = new LocationBuilder().Append(new EncodedPolylineLocation(latitude, longitude))
                                                  .Build();
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void LocationBuilder_ShouldThrowException_WhenLatLng_OutOfRange(string address)
        {
            Assert.Throws<ArgumentNullException>(() => {
                var result = new LocationBuilder().Append(new AddressLocation(address))
                                                  .Build();
            });
        }
    }
}
