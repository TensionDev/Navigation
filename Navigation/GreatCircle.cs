using System;
using TensionDev.CoordinateSystems;

namespace TensionDev.Maritime.Navigation
{
    /// <summary>
    /// Computation dealing with Great Circle
    /// </summary>
    public static class GreatCircle
    {
        /// <summary>
        /// Average Radius of the Earth
        /// </summary>
        public const Double EARTH_RADIUS_M = 6371000.0;

        /// <summary>
        /// Geodetic Coordinate of a new position based on a given position, bearing and range.
        /// </summary>
        /// <param name="startPosition">Geodetic Start Position</param>
        /// <param name="bearingDegrees">Bearing in Degrees</param>
        /// <param name="rangeMetres">Range in Metres</param>
        /// <returns></returns>
        public static GeographicCoordinateSystem PositionFromPoint(GeographicCoordinateSystem startPosition, Double bearingDegrees, Double rangeMetres)
        {
            Double endLatitudeRad = Math.Asin(Math.Sin(startPosition.LatitudeDecimalRadians) * Math.Cos(rangeMetres / EARTH_RADIUS_M) +
                            Math.Cos(startPosition.LatitudeDecimalRadians) * Math.Sin(rangeMetres / EARTH_RADIUS_M) * Math.Cos(bearingDegrees * Math.PI / 180.0));

            Double endLongitudeRad = startPosition.LongitudeDecimalRadians + Math.Atan2(Math.Sin(bearingDegrees * Math.PI / 180.0) * Math.Sin(rangeMetres / EARTH_RADIUS_M) * Math.Cos(startPosition.LatitudeDecimalRadians),
                                        Math.Cos(rangeMetres / EARTH_RADIUS_M) - Math.Sin(startPosition.LatitudeDecimalRadians) * Math.Sin(endLatitudeRad));

            GeographicCoordinateSystem endPosition = new GeographicCoordinateSystem()
            {
                LatitudeDecimalRadians = endLatitudeRad,
                LongitudeDecimalRadians = endLongitudeRad,
            };

            return endPosition;
        }

        /// <summary>
        /// Distance based on a start position and end position.
        /// </summary>
        /// <param name="startPosition">Geodetic Start Position</param>
        /// <param name="endPosition">Geodetic End Position</param>
        /// <returns>Distance in Metres</returns>
        public static Double DistanceFromPoint(GeographicCoordinateSystem  startPosition, GeographicCoordinateSystem endPosition)
        {
            Double phi = endPosition.LatitudeDecimalRadians - startPosition.LatitudeDecimalRadians;
            Double lambda = endPosition.LongitudeDecimalRadians - startPosition.LongitudeDecimalRadians;

            Double a = Math.Sin(phi / 2) * Math.Sin(phi / 2) +
                Math.Cos(startPosition.LatitudeDecimalRadians) * Math.Cos(endPosition.LatitudeDecimalRadians) *
                Math.Sin(lambda / 2) * Math.Sin(lambda / 2);

            Double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            Double distance = EARTH_RADIUS_M * c;

            return distance;
        }
    }
}
