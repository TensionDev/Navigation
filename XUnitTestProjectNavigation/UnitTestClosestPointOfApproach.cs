using System;
using TensionDev.Maritime.Navigation;
using Xunit;

namespace XUnitTestProjectNavigation
{
    public class UnitTestClosestPointOfApproach
    {
        internal const Int32 DISTANCE_PRECISION = 2;
        internal const Int32 TIME_PRECISION = 0;

        [Fact]
        public void TestCalculateCPAandTCPA1()
        {
            VesselTrack ownVessel = new VesselTrack();
            VesselTrack targetVessel = new VesselTrack();

            double expectedCPA = 0.0;
            double expectedTCPA = 0.0;

            ClosestPointOfApproach.CalculateCPAandTCPA(ownVessel, targetVessel, out double actualCPA, out double actualTCPA);

            Assert.Equal(expectedCPA, actualCPA, DISTANCE_PRECISION);
            Assert.Equal(expectedTCPA, actualTCPA, TIME_PRECISION);
        }

        [Fact]
        public void TestCalculateCPAandTCPA2()
        {
            VesselTrack ownVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02203,
                    LongitudeDecimalRadians = 1.81450,
                },
                SpeedOverGroundKnots = 1.98048,
                CourseOverGroundDegrees = 213.94921,
            };
            VesselTrack targetVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02239,
                    LongitudeDecimalRadians = 1.81455,
                },
                SpeedOverGroundKnots = 5.37353,
                CourseOverGroundDegrees = 129.32617,
            };

            double expectedCPA = 1.23 ;
            double expectedTCPA = 150;

            ClosestPointOfApproach.CalculateCPAandTCPA(ownVessel, targetVessel, out double actualCPA, out double actualTCPA);
            actualCPA /= 1852;

            Assert.Equal(expectedCPA, actualCPA, DISTANCE_PRECISION);
            Assert.Equal(expectedTCPA, actualTCPA, TIME_PRECISION);
        }

        [Fact]
        public void TestCalculateCPAandTCPA3()
        {
            VesselTrack ownVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02203,
                    LongitudeDecimalRadians = 1.81450,
                },
                SpeedOverGroundKnots = 1.98048,
                CourseOverGroundDegrees = 213.94921,
            };
            VesselTrack targetVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02203,
                    LongitudeDecimalRadians = 1.81446,
                },
                SpeedOverGroundKnots = 1.99922,
                CourseOverGroundDegrees = 111.37690,
            };

            double expectedCPA = 0.05;
            double expectedTCPA = 154;

            ClosestPointOfApproach.CalculateCPAandTCPA(ownVessel, targetVessel, out double actualCPA, out double actualTCPA);
            actualCPA /= 1852;

            Assert.Equal(expectedCPA, actualCPA, DISTANCE_PRECISION);
            Assert.Equal(expectedTCPA, actualTCPA, TIME_PRECISION);
        }

        [Fact]
        public void TestCalculateCPAandTCPA4()
        {
            VesselTrack ownVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02203,
                    LongitudeDecimalRadians = 1.81450,
                },
                SpeedOverGroundKnots = 1.98048,
                CourseOverGroundDegrees = 213.94921,
            };
            VesselTrack targetVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02202,
                    LongitudeDecimalRadians = 1.81422,
                },
                SpeedOverGroundKnots = 10.00002,
                CourseOverGroundDegrees = 90.80503,
            };

            double expectedCPA = 0.11;
            double expectedTCPA = 311;

            ClosestPointOfApproach.CalculateCPAandTCPA(ownVessel, targetVessel, out double actualCPA, out double actualTCPA);
            actualCPA /= 1852;

            Assert.Equal(expectedCPA, actualCPA, DISTANCE_PRECISION);
            Assert.Equal(expectedTCPA, actualTCPA, TIME_PRECISION);
        }

        [Fact]
        public void TestCalculateCPAandTCPA5()
        {
            VesselTrack ownVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02196,
                    LongitudeDecimalRadians = 1.81446,
                },
                SpeedOverGroundKnots = 1.04226,
                CourseOverGroundDegrees = 212.72825,
            };
            VesselTrack targetVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02212,
                    LongitudeDecimalRadians = 1.81454,
                },
                SpeedOverGroundKnots = 6.00000,
                CourseOverGroundDegrees = 209.16741,
            };

            double expectedCPA = 0.03;
            double expectedTCPA = 437;

            ClosestPointOfApproach.CalculateCPAandTCPA(ownVessel, targetVessel, out double actualCPA, out double actualTCPA);
            actualCPA /= 1852;

            Assert.Equal(expectedCPA, actualCPA, DISTANCE_PRECISION);
            Assert.Equal(expectedTCPA, actualTCPA, TIME_PRECISION);
        }

        [Fact]
        public void TestCalculateCPAandTCPA6()
        {
            VesselTrack ownVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02196,
                    LongitudeDecimalRadians = 1.81446,
                },
                SpeedOverGroundKnots = 1.04226,
                CourseOverGroundDegrees = 212.72825,
            };
            VesselTrack targetVessel = new VesselTrack()
            {
                VesselCoordinates = new GeodeticCoord()
                {
                    LatitudeDecimalRadians = 0.02190,
                    LongitudeDecimalRadians = 1.81424,
                },
                SpeedOverGroundKnots = 6.08546,
                CourseOverGroundDegrees = 358.84242,
            };

            double expectedCPA = 0.73;
            double expectedTCPA = 129;

            ClosestPointOfApproach.CalculateCPAandTCPA(ownVessel, targetVessel, out double actualCPA, out double actualTCPA);
            actualCPA /= 1852;

            Assert.Equal(expectedCPA, actualCPA, DISTANCE_PRECISION);
            Assert.Equal(expectedTCPA, actualTCPA, TIME_PRECISION);
        }
    }
}
