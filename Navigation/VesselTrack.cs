using System;
using System.Collections.Generic;
using System.Text;
using TensionDev.CoordinateSystems;

namespace TensionDev.Maritime.Navigation
{
    /// <summary>
    /// Vessel Track
    /// </summary>
    public class VesselTrack
    {
        private double courseOverGround;

        private const double KNOTS_METRES_PER_SECOND = 0.514444;

        /// <summary>
        /// Default Constructor initialised to 0 for all variables
        /// </summary>
        public VesselTrack()
        {
            VesselCoordinates = new GeographicCoordinateSystem();
            SpeedOverGroundMetresPerSecond = 0.0;
            courseOverGround = 0.0;
        }

        /// <summary>
        /// Vessel Coordinates
        /// </summary>
        public GeographicCoordinateSystem VesselCoordinates { get; set; }

        /// <summary>
        /// Speed Over Ground in Knots
        /// </summary>
        public Double SpeedOverGroundKnots { get => SpeedOverGroundMetresPerSecond / KNOTS_METRES_PER_SECOND; set => SpeedOverGroundMetresPerSecond = value * KNOTS_METRES_PER_SECOND; }

        /// <summary>
        /// Speed Over Ground in Metres per Second
        /// </summary>
        public Double SpeedOverGroundMetresPerSecond { get; set; }

        /// <summary>
        /// Course Over Ground in Radians
        /// </summary>
        public Double CourseOverGroundRadians { get => courseOverGround * Math.PI / 180.0; set => CourseOverGroundDegrees = value * 180.0 / Math.PI; }

        /// <summary>
        /// Course Over Ground in Degrees
        /// </summary>
        public Double CourseOverGroundDegrees { get => courseOverGround; set => courseOverGround = Math.Max(Math.Min(value, 360), 0); }

    }
}
