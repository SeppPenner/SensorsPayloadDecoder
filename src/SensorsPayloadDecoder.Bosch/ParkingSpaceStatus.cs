// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParkingSpaceStatus.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   An enumeration for the parking space status flag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch
{
    /// <summary>
    ///     An enumeration for the parking space status flag.
    /// </summary>
    public enum ParkingSpaceStatus
    {
        /// <summary>
        ///     The free parking space status.
        /// </summary>
        FreeParkingSpace,

        /// <summary>
        ///     The occupied parking space status.
        /// </summary>
        OccupiedParkingSpace
    }
}