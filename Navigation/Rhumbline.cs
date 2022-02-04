using System;

namespace TensionDev.Maritime.Navigation
{
    public class Rhumbline
    {
        public const Double EARTH_RADIUS_M = 6371000.0;

        /// <summary>
        /// Geodetic Coordinate of a new position based on a given position, bearing and range.
        /// </summary>
        /// <param name="startPosition">Geodetic Start Position</param>
        /// <param name="bearingDegrees">Bearing in Degrees</param>
        /// <param name="distanceMetres">Distance in Metres</param>
        /// <returns>New Position</returns>
        public static GeodeticCoord PositionFromPoint(GeodeticCoord startPosition, Double bearingDegrees, Double distanceMetres)
        {
            Double delta = distanceMetres / EARTH_RADIUS_M;
            Double phi = delta * Math.Cos(bearingDegrees * Math.PI / 180.0);
            Double endLatitudeRad = startPosition.LatitudeDecimalRadians + phi;

            Double psi = Math.Log(Math.Tan(endLatitudeRad / 2 + Math.PI / 4) / Math.Tan(startPosition.LatitudeDecimalRadians / 2 + Math.PI / 4));
            Double q = Math.Abs(psi) > Single.Epsilon ? phi / psi : Math.Cos(startPosition.LatitudeDecimalRadians); // E-W course becomes ill-conditioned with 0/0

            Double lambda = delta * Math.Sin(bearingDegrees * Math.PI / 180.0) / q;
            Double endLongitudeRad = startPosition.LongitudeDecimalRadians + lambda;

            if (Math.Abs(endLatitudeRad) > Math.PI / 2)
                endLatitudeRad = endLatitudeRad > 0 ? Math.PI - endLatitudeRad : -Math.PI - endLatitudeRad;

            if (Math.Abs(endLongitudeRad) > Math.PI)
                endLongitudeRad = endLongitudeRad > 0 ? 2 * Math.PI - endLongitudeRad : (2 * -Math.PI) - endLongitudeRad;

            GeodeticCoord endPosition = new GeodeticCoord()
            {
                LatitudeDecimalRadians = endLatitudeRad,
                LongitudeDecimalRadians = endLongitudeRad,
            };

            return endPosition;
        }

        /// <summary>
        /// Bearing based on a start position and end position.
        /// </summary>
        /// <param name="startPosition">Geodetic Start Position</param>
        /// <param name="endPosition">Geodetic End Position</param>
        /// <returns>Bearing in Degrees</returns>
        public static Double BearingFromPoint(GeodeticCoord startPosition, GeodeticCoord endPosition)
        {
            Double psi = Math.Log(Math.Tan(endPosition.LatitudeDecimalRadians / 2 + Math.PI / 4) / Math.Tan(startPosition.LatitudeDecimalRadians / 2 + Math.PI / 4));

            // if lambda over 180° take shorter rhumb line across the anti-meridian:
            Double lambda = endPosition.LongitudeDecimalRadians - startPosition.LongitudeDecimalRadians;
            if (Math.Abs(lambda) > Math.PI)
                lambda = lambda > 0 ? -(2 * Math.PI - lambda) : (2 * Math.PI + lambda);

            Double bearingRad = Math.Atan2(lambda, psi);

            if (bearingRad < 0)
                bearingRad = (2 * Math.PI) + bearingRad;

            return bearingRad * 180.0 / Math.PI;
        }

        /// <summary>
        /// Distance based on a start position and end position.
        /// </summary>
        /// <param name="startPosition">Geodetic Start Position</param>
        /// <param name="endPosition">Geodetic End Position</param>
        /// <returns>Distance in Metres</returns>
        public static Double DistanceFromPoint(GeodeticCoord startPosition, GeodeticCoord endPosition)
        {
            Double phi = endPosition.LatitudeDecimalRadians - startPosition.LatitudeDecimalRadians;
            Double psi = Math.Log(Math.Tan(endPosition.LatitudeDecimalRadians / 2 + Math.PI / 4) / Math.Tan(startPosition.LatitudeDecimalRadians / 2 + Math.PI / 4));
            Double q = Math.Abs(psi) > Single.Epsilon ? phi / psi : Math.Cos(startPosition.LatitudeDecimalRadians); // E-W course becomes ill-conditioned with 0/0

            // if dLon over 180° take shorter rhumb line across the anti-meridian:
            Double lambda = endPosition.LongitudeDecimalRadians - startPosition.LongitudeDecimalRadians;
            if (Math.Abs(lambda) > Math.PI)
                lambda = lambda > 0 ? -(2 * Math.PI - lambda) : (2 * Math.PI + lambda);

            Double distance = Math.Sqrt(phi * phi + q * q * lambda * lambda) * EARTH_RADIUS_M;

            return distance;
        }
    }
}
