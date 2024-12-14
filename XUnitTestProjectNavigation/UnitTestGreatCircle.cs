﻿using System;
using TensionDev.CoordinateSystems;
using TensionDev.Maritime.Navigation;
using Xunit;

namespace XUnitTestProjectNavigation
{
    public class UnitTestGreatCircle : IDisposable
    {
        private bool disposedValue;

        internal const Int32 POSITION_PRECISION = 4;
        internal const Int32 DISTANCE_PRECISION = 0;

        [Fact]
        public void TestPositionFromPoint1()
        {
            GeographicCoordinateSystem startPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalDegrees = 51.47788,
                LongitudeDecimalDegrees = -0.00147,
            };
            Double bearingDegrees = 300.7;
            Double rangeMetres = 7794.0;

            GeographicCoordinateSystem expectedPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalDegrees = 51.5136,
                LongitudeDecimalDegrees = -0.0983,
            };

            GeographicCoordinateSystem actualPosition = GreatCircle.PositionFromPoint(startPosition, bearingDegrees, rangeMetres);

            Assert.Equal(expectedPosition.LatitudeDecimalDegrees, actualPosition.LatitudeDecimalDegrees, POSITION_PRECISION);
            Assert.Equal(expectedPosition.LongitudeDecimalDegrees, actualPosition.LongitudeDecimalDegrees, POSITION_PRECISION);
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

            Double actualDistance = GreatCircle.DistanceFromPoint(startPosition, endPosition);

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
        // ~UnitTestGreatCircle()
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
