using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.Navigation
{
    /// <summary>
    /// Vessel Track
    /// </summary>
    public class VesselTrack
    {
        private GeodeticCoord vesselCoordinates;
        private double speedOverGround;
        private double courseOverGround;

        private const double KNOTS_METRES_PER_SECOND = 0.514444;

        /// <summary>
        /// Default Constructor initialised to 0 for all variables
        /// </summary>
        public VesselTrack()
        {
            vesselCoordinates = new GeodeticCoord();
            speedOverGround = 0.0;
            courseOverGround = 0.0;
        }

        /// <summary>
        /// Vessel Coordinates
        /// </summary>
        public GeodeticCoord VesselCoordinates { get => vesselCoordinates; set => vesselCoordinates = value; }

        /// <summary>
        /// Speed Over Ground in Knots
        /// </summary>
        public Double SpeedOverGroundKnots { get => speedOverGround / KNOTS_METRES_PER_SECOND; set => SpeedOverGroundMetresPerSecond = value * KNOTS_METRES_PER_SECOND; }

        /// <summary>
        /// Speed Over Ground in Metres per Second
        /// </summary>
        public Double SpeedOverGroundMetresPerSecond { get => speedOverGround; set => speedOverGround = value; }

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
