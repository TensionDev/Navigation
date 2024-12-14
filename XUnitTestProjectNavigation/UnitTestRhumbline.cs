using System;
using TensionDev.CoordinateSystems;
using TensionDev.Maritime.Navigation;
using Xunit;

namespace XUnitTestProjectNavigation
{
    public class UnitTestRhumbline :IDisposable
    {
        private bool disposedValue;

        internal const Int32 POSITION_PRECISION = 4;
        internal const Int32 BEARING_PRECISION = 2;
        internal const Int32 DISTANCE_PRECISION = 0;

        [Fact]
        public void TestPositionFromPoint1()
        {
            GeographicCoordinateSystem startPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalDegrees = 51.12555555555555555555555555555556,
                LongitudeDecimalDegrees = 1.3380555555555555555555555555556,
            };
            Double bearingDegrees = 116.63611111111111111111111111111;
            Double rangeMetres = 40230.0;

            GeographicCoordinateSystem expectedPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalDegrees = 50.9634,
                LongitudeDecimalDegrees = 1.8524,
            };

            GeographicCoordinateSystem actualPosition = Rhumbline.PositionFromPoint(startPosition, bearingDegrees, rangeMetres);

            Assert.Equal(expectedPosition.LatitudeDecimalDegrees, actualPosition.LatitudeDecimalDegrees, POSITION_PRECISION);
            Assert.Equal(expectedPosition.LongitudeDecimalDegrees, actualPosition.LongitudeDecimalDegrees, POSITION_PRECISION);
        }

        [Fact]
        public void TestBearingFromPoint1()
        {
            GeographicCoordinateSystem startPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalDegrees = 50.366389,
                LongitudeDecimalDegrees = -4.133889,
            };
            GeographicCoordinateSystem endPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalDegrees = 42.351111,
                LongitudeDecimalDegrees = -71.040833,
            };

            Double expectedBearing = 260.1272;

            Double actualBearing = Rhumbline.BearingFromPoint(startPosition, endPosition);

            Assert.Equal(expectedBearing, actualBearing, BEARING_PRECISION);
        }

        [Fact]
        public void TestDistanceFromPoint1()
        {
            GeographicCoordinateSystem startPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalDegrees = 51.127,
                LongitudeDecimalDegrees = 1.338,
            };
            GeographicCoordinateSystem endPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalDegrees = 50.964,
                LongitudeDecimalDegrees = 1.853,
            };

            Double expectedDistance = 40308.0;

            Double actualDistance = Rhumbline.DistanceFromPoint(startPosition, endPosition);

            Assert.Equal(expectedDistance, actualDistance, DISTANCE_PRECISION);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitTestRhumbline()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
