// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageResult.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The result decoded from the decoder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch
{
    /// <summary>
    ///     The result decoded from the decoder.
    /// </summary>
    public class MessageResult
    {
        /// <summary>
        ///     Gets or sets the confirmable status.
        /// </summary>
        public ConfirmableStatus? ConfirmableStatus { get; set; }

        /// <summary>
        ///     Gets or sets the data rate configuration.
        /// </summary>
        public DataRateConfiguration? DataRateConfiguration { get; set; }

        /// <summary>
        ///     Gets or sets the firmware information.
        /// </summary>
        public string FirmwareInformation { get; set; }

        /// <summary>
        ///     Gets or sets the parking space status.
        /// </summary>
        public ParkingSpaceStatus? ParkingSpaceStatus { get; set; }

        /// <summary>
        ///     Gets or sets the reset cause.
        /// </summary>
        public ResetCause? ResetCause { get; set; }
    }
}