using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.Navigation
{
    /// <summary>
    /// Geodetic Coordinates
    /// </summary>
    public class GeodeticCoord
    {
        private double latitude;
        private double longitude;

        /// <summary>
        /// Latitude in Radians
        /// </summary>
        public Double LatitudeDecimalRadians { get => latitude * Math.PI / 180.0; set => LatitudeDecimalDegrees = value * 180.0 / Math.PI; }

        /// <summary>
        /// Longitude in Radians
        /// </summary>
        public Double LongitudeDecimalRadians { get => longitude * Math.PI / 180.0; set => LongitudeDecimalDegrees = value * 180.0 / Math.PI; }

        /// <summary>
        /// Latitude in Degrees
        /// </summary>
        public Double LatitudeDecimalDegrees { get => latitude; set => latitude = Math.Max(Math.Min(value, 90), -90); }

        /// <summary>
        /// Longitude in Degrees
        /// </summary>
        public Double LongitudeDecimalDegrees { get => longitude; set => longitude = Math.Max(Math.Min(value, 180), -180); }
    }
}
