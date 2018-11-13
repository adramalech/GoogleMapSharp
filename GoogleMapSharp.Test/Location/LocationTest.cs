using System;
using GoogleMapSharp;
using GoogleMapSharp.Location;
using Xunit;

namespace GoogleMapSharp.Test.Location
{
    public class LocationTest
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
        [InlineData(80.123456, 80.123456)]
        public void GenerateMultipleDestinationLocations_CheckCountOfDelimiters(double latitude, double longitude)
        {
            var result = new LocationBuilder().Append(new GeoLocation(80.123456, 80.123456))
                                              .Append(new GeoLocation(80.123456, 80.123456))
                                              .Append(new GeoLocation(80.123456, 80.123456))
                                              .Build();

            Assert.NotEmpty(result);

            var len = result.Split('|').Length;

            Assert.True(len == 3);
        }

        [Theory]
        [InlineData(90.00001, -160.000)]
        [InlineData(-91.0000, -120.000)]
        [InlineData(80.012345, -189.0001)]
        [InlineData(-81.123456, 190.00001)]
        [InlineData(-167.001234, 200.98989)]
        public void GeoLocationCreation_ShouldThrowException_WhenLatLng_OutOfRange(double latitude, double longitude)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var result = new GeoLocation(latitude, longitude);
            });
        }

        [Theory]
        [InlineData(90.00001, -160.000)]
        [InlineData(-91.0000, -120.000)]
        [InlineData(80.012345, -189.0001)]
        [InlineData(-81.123456, 190.00001)]
        [InlineData(-167.001234, 200.98989)]
        public void PolyLineEncodingGeoLocation_ShouldThrowException_WhenLatLng_OutOfRange(double latitude, double longitude)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var result = new EncodedPolylineLocation(latitude, longitude);
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void LocationBuilder_ShouldThrowException_When_AddressIsEmpty(string address)
        {
            Assert.Throws<ArgumentNullException>(() => {
                var result = new LocationBuilder().Append(address)
                                                  .Build();
            });
        }
    }
}
