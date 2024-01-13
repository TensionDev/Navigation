using System;

namespace TensionDev.Maritime.Navigation
{
    /// <summary>
    /// Computation for Closest Point of Approach and Time to Closest Point of Approach
    /// </summary>
    public static class ClosestPointOfApproach
    {
        /// <summary>
        /// Calculates the Closest Point of Approach (CPA) and Time to Closest Point of Approach (TCPA).
        /// </summary>
        /// <param name="ownVessel">Own Vessel information</param>
        /// <param name="targetVessel">Target Vessel information</param>
        /// <param name="closestPointOfApproachMetres">CPA in Metres</param>
        /// <param name="timeToClosestPointOfApproachSeconds">TCPA in Seconds</param>
        public static void CalculateCPAandTCPA(VesselTrack ownVessel, VesselTrack targetVessel, out Double closestPointOfApproachMetres, out Double timeToClosestPointOfApproachSeconds)
        {
            double bearingDegrees = Rhumbline.BearingFromPoint(ownVessel.VesselCoordinates, targetVessel.VesselCoordinates);
            double distanceMetres = Rhumbline.DistanceFromPoint(ownVessel.VesselCoordinates, targetVessel.VesselCoordinates);

            double dRelativePosX = Math.Sin(bearingDegrees / 180.0 * Math.PI) * distanceMetres;
            double dRelativePosY = Math.Cos(bearingDegrees / 180.0 * Math.PI) * distanceMetres;

            double OwnX = Math.Sin(ownVessel.CourseOverGroundRadians) * ownVessel.SpeedOverGroundMetresPerSecond;
            double OwnY = Math.Cos(ownVessel.CourseOverGroundRadians) * ownVessel.SpeedOverGroundMetresPerSecond;
            double ObjectX = Math.Sin(targetVessel.CourseOverGroundRadians) * targetVessel.SpeedOverGroundMetresPerSecond;
            double ObjectY = Math.Cos(targetVessel.CourseOverGroundRadians) * targetVessel.SpeedOverGroundMetresPerSecond;
            double RelX = ObjectX - OwnX;
            double RelY = ObjectY - OwnY;
            double dRelativeSOG = Math.Sqrt((RelX * RelX) + (RelY * RelY));

            if (dRelativeSOG == 0.0)
            {
                closestPointOfApproachMetres = distanceMetres;
                timeToClosestPointOfApproachSeconds = 0.0;

                return;
            }

            if (RelY == 0.0)
            {
                closestPointOfApproachMetres = dRelativePosX;
                timeToClosestPointOfApproachSeconds = (dRelativePosX / RelX);

            }
            else if (RelX == 0.0)
            {
                closestPointOfApproachMetres = dRelativePosY;
                timeToClosestPointOfApproachSeconds = (dRelativePosY / RelY);
            }
            else
            {
                // y = dGradient * x + dYIntersect
                // y = (1 / dGradient) * x
                // ((1 - (dGradient * dGradient)) / dGradient) * x = dYIntersect
                // x = dYIntersect / ((1 - (dGradient * dGradient)) / dGradient)

                double dCPAPointX;
                double dCPAPointY;
                double dGradient, dYIntersect;
                double dX, dY;

                dGradient = RelY / RelX;

                dYIntersect = dRelativePosY - (dGradient * dRelativePosX);

                dCPAPointX = dYIntersect / -(1 / dGradient + dGradient);
                dCPAPointY = dGradient * dCPAPointX + dYIntersect;

                dX = dCPAPointX * dCPAPointX;
                dY = dCPAPointY * dCPAPointY;
                closestPointOfApproachMetres = Math.Sqrt(dX + dY);

                dX = dCPAPointX - dRelativePosX;
                dY = dCPAPointY - dRelativePosY;

                dX /= RelX;
                dY /= RelY;

                timeToClosestPointOfApproachSeconds = ((dX + dY) / 2.0);
            }
        }
    }
}
