using System;
using TensionDev.Maritime.Navigation;
using Xunit;

namespace XUnitTestProjectNavigation
{
    public class UnitTestGreatCircle
    {
        internal const Int32 POSITION_PRECISION = 4;
        internal const Int32 DISTANCE_PRECISION = 0;

        [Fact]
        public void TestPositionFromPoint1()
        {
            GeodeticCoord startPosition = new GeodeticCoord()
            {
                LatitudeDecimalDegrees = 51.47788,
                LongitudeDecimalDegrees = -0.00147,
            };
            Double bearingDegrees = 300.7;
            Double rangeMetres = 7794.0;

            GeodeticCoord expectedPosition = new GeodeticCoord()
            {
                LatitudeDecimalDegrees = 51.5136,
                LongitudeDecimalDegrees = -0.0983,
            };

            GeodeticCoord actualPosition = GreatCircle.PositionFromPoint(startPosition, bearingDegrees, rangeMetres);

            Assert.Equal(expectedPosition.LatitudeDecimalDegrees, actualPosition.LatitudeDecimalDegrees, POSITION_PRECISION);
            Assert.Equal(expectedPosition.LongitudeDecimalDegrees, actualPosition.LongitudeDecimalDegrees, POSITION_PRECISION);
        }

        [Fact]
        public void TestDistanceFromPoint1()
        {
            GeodeticCoord startPosition = new GeodeticCoord()
            {
                LatitudeDecimalDegrees = 51.127,
                LongitudeDecimalDegrees = 1.338,
            };
            GeodeticCoord endPosition = new GeodeticCoord()
            {
                LatitudeDecimalDegrees = 50.964,
                LongitudeDecimalDegrees = 1.853,
            };

            Double expectedDistance = 40308.0;

            Double actualDistance = GreatCircle.DistanceFromPoint(startPosition, endPosition);

            Assert.Equal(expectedDistance, actualDistance, DISTANCE_PRECISION);
        }
    }
}
