// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   An enumeration for the type of the message to decode.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch
{
    /// <summary>
    ///     An enumeration for the type of the message to decode.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        ///     The uplink parking status message.
        /// </summary>
        UplinkParkingStatusMessage,

        /// <summary>
        ///     The uplink heartbeat message.
        /// </summary>
        UplinkHeartbeatMessage,

        /// <summary>
        ///     The uplink startup message.
        /// </summary>
        UplinkStartUpMessage,

        /// <summary>
        ///     The downlink confirmable configuration message.
        /// </summary>
        DownlinkConfirmableConfigurationMessage,

        /// <summary>
        ///     The downlink data rate configuration message.
        /// </summary>
        DownlinkDataRateConfigurationMessage
    }
}