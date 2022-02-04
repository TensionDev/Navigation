using System;
using TensionDev.Maritime.Navigation;
using Xunit;

namespace XUnitTestProjectNavigation
{
    public class UnitTestGeodeticCoord
    {
        [Fact]
        public void Test1()
        {
            GeodeticCoord geodeticCoord = new GeodeticCoord();

            Assert.Equal(0, geodeticCoord.LatitudeDecimalDegrees);
            Assert.Equal(0, geodeticCoord.LongitudeDecimalDegrees);
            Assert.Equal(0, geodeticCoord.LatitudeDecimalRadians);
            Assert.Equal(0, geodeticCoord.LongitudeDecimalRadians);
        }

        [Fact]
        public void Test2()
        {
            double latitudeDeg = 30;
            double longitudeDeg = 30;
            double latitudeRad = latitudeDeg * Math.PI / 180.0;
            double longitudeRad = longitudeDeg * Math.PI / 180.0;

            GeodeticCoord geodeticCoord = new GeodeticCoord()
            {
                LatitudeDecimalDegrees = 30,
                LongitudeDecimalDegrees = 30,
            };

            Assert.Equal(latitudeDeg, geodeticCoord.LatitudeDecimalDegrees);
            Assert.Equal(longitudeDeg, geodeticCoord.LongitudeDecimalDegrees);
            Assert.Equal(latitudeRad, geodeticCoord.LatitudeDecimalRadians);
            Assert.Equal(longitudeRad, geodeticCoord.LongitudeDecimalRadians);
        }

        [Fact]
        public void Test3()
        {
            double latitudeDeg = -60;
            double longitudeDeg = -90;
            double latitudeRad = latitudeDeg * Math.PI / 180.0;
            double longitudeRad = longitudeDeg * Math.PI / 180.0;

            GeodeticCoord geodeticCoord = new GeodeticCoord()
            {
                LatitudeDecimalDegrees = -60,
                LongitudeDecimalDegrees = -90,
            };

            Assert.Equal(latitudeDeg, geodeticCoord.LatitudeDecimalDegrees);
            Assert.Equal(longitudeDeg, geodeticCoord.LongitudeDecimalDegrees);
            Assert.Equal(latitudeRad, geodeticCoord.LatitudeDecimalRadians);
            Assert.Equal(longitudeRad, geodeticCoord.LongitudeDecimalRadians);
        }

        [Fact]
        public void Test4()
        {
            double latitudeDeg = 90;
            double longitudeDeg = -180;
            double latitudeRad = latitudeDeg * Math.PI / 180.0;
            double longitudeRad = longitudeDeg * Math.PI / 180.0;

            GeodeticCoord geodeticCoord = new GeodeticCoord()
            {
                LatitudeDecimalDegrees = double.MaxValue,
                LongitudeDecimalDegrees = double.MinValue,
            };

            Assert.Equal(latitudeDeg, geodeticCoord.LatitudeDecimalDegrees);
            Assert.Equal(longitudeDeg, geodeticCoord.LongitudeDecimalDegrees);
            Assert.Equal(latitudeRad, geodeticCoord.LatitudeDecimalRadians);
            Assert.Equal(longitudeRad, geodeticCoord.LongitudeDecimalRadians);
        }
    }
}