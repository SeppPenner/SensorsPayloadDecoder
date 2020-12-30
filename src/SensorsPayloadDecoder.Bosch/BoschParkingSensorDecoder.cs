// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoschParkingSensorDecoder.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A payload decoder for the BOSCH parking lot sensor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch
{
    using System;
    using System.Collections.Generic;

    using SensorsPayloadDecoder.Shared;

    /// <summary>
    ///     A payload decoder for the BOSCH parking lot sensor.
    /// </summary>
    public class BoschParkingSensorDecoder
    {
        /// <summary>
        ///     Decodes the payload.
        /// </summary>
        /// <param name="payload">The payload to decode as <see cref="T:byte[]" />.</param>
        /// <param name="type">The <see cref="MessageType" /> to decode.</param>
        /// <returns>A <see cref="MessageResult" /> that contains all the information of the message depending on the message type.</returns>
        // ReSharper disable once InconsistentNaming
        public MessageResult DecodePayload(byte[] payload, MessageType type)
        {
            if (payload == null || payload.Length == 0)
            {
                throw new ArgumentException(nameof(payload));
            }

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(payload);
            }

            switch (type)
            {
                case MessageType.UplinkParkingStatusMessage: return DecodeUplinkParkingStatusMessage(payload);
                case MessageType.UplinkHeartbeatMessage: return DecodeUplinkHeartbeatMessage(payload);
                case MessageType.UplinkStartUpMessage: return DecodeUplinkStartUpMessage(payload);
                case MessageType.DownlinkConfirmableConfigurationMessage:
                    return DecodeDownlinkConfirmableConfiguration(payload);
                case MessageType.DownlinkDataRateConfigurationMessage:
                    return DecodeDownlinkDataRateConfiguration(payload);
                default: return null;
            }
        }

        /// <summary>
        ///     Decodes the downlink confirmable configuration message.
        /// </summary>
        /// <param name="payload">The payload to decode as <see cref="T:byte[]" />.</param>
        /// <returns>A <see cref="MessageResult" /> that contains all the information of the message.</returns>
        // ReSharper disable once InconsistentNaming
        private static MessageResult DecodeDownlinkConfirmableConfiguration(IReadOnlyList<byte> payload)
        {
            if (payload.Count != 1)
            {
                throw new Exception("The downlink confirmable configuration message must contain exactly 1 byte.");
            }

            var isConfirmable = payload[0] == 0x00;

            return new MessageResult
                   {
                       ConfirmableStatus =
                           isConfirmable ? ConfirmableStatus.Confirmable : ConfirmableStatus.NotConfirmable
                   };
        }

        /// <summary>
        ///     Decodes the downlink data rate configuration message.
        /// </summary>
        /// <param name="payload">The payload to decode as <see cref="T:byte[]" />.</param>
        /// <returns>A <see cref="MessageResult" /> that contains all the information of the message.</returns>
        // ReSharper disable once InconsistentNaming
        private static MessageResult DecodeDownlinkDataRateConfiguration(IReadOnlyList<byte> payload)
        {
            if (payload.Count != 1)
            {
                throw new Exception("The downlink data rate configuration message must contain exactly 1 byte.");
            }

            return new MessageResult { DataRateConfiguration = GetDataRateConfigurationFromByte(payload[0]) };
        }

        /// <summary>
        ///     Decodes the uplink heartbeat message.
        /// </summary>
        /// <param name="payload">The payload to decode as <see cref="T:byte[]" />.</param>
        /// <returns>A <see cref="MessageResult" /> that contains all the information of the message.</returns>
        // ReSharper disable once InconsistentNaming
        private static MessageResult DecodeUplinkHeartbeatMessage(byte[] payload)
        {
            if (payload.Length != 1)
            {
                throw new Exception("The uplink heartbeat message must contain exactly 1 byte.");
            }

            var isParkingSpaceOccupied = payload[0].IsBitSet(0);

            return new MessageResult
                   {
                       ParkingSpaceStatus = isParkingSpaceOccupied
                                                ? ParkingSpaceStatus.OccupiedParkingSpace
                                                : ParkingSpaceStatus.FreeParkingSpace
                   };
        }

        /// <summary>
        ///     Decodes the uplink parking status message.
        /// </summary>
        /// <param name="payload">The payload to decode as <see cref="T:byte[]" />.</param>
        /// <returns>A <see cref="MessageResult" /> that contains all the information of the message.</returns>
        // ReSharper disable once InconsistentNaming
        private static MessageResult DecodeUplinkParkingStatusMessage(byte[] payload)
        {
            if (payload.Length != 1)
            {
                throw new Exception("The uplink parking status message must contain exactly 1 byte.");
            }

            var isParkingSpaceOccupied = payload[0].IsBitSet(0);

            return new MessageResult
                   {
                       ParkingSpaceStatus = isParkingSpaceOccupied
                                                ? ParkingSpaceStatus.OccupiedParkingSpace
                                                : ParkingSpaceStatus.FreeParkingSpace
                   };
        }

        /// <summary>
        ///     Decodes the uplink startup message.
        /// </summary>
        /// <param name="payload">The payload to decode as <see cref="T:byte[]" />.</param>
        /// <returns>A <see cref="MessageResult" /> that contains all the information of the message.</returns>
        // ReSharper disable once InconsistentNaming
        private static MessageResult DecodeUplinkStartUpMessage(byte[] payload)
        {
            if (payload.Length != 17)
            {
                throw new Exception("The uplink startup message must contain exactly 17 bytes.");
            }

            var isParkingSpaceOccupied = payload[16].IsBitSet(0);
            var resetCause = GetResetCauseFromByte(payload[15]);

            return new MessageResult
                   {
                       FirmwareInformation =
                           $"{Convert.ToInt32(payload[14])}.{Convert.ToInt32(payload[13])}.{Convert.ToInt32(payload[12])}",
                       ParkingSpaceStatus = isParkingSpaceOccupied
                                                ? ParkingSpaceStatus.OccupiedParkingSpace
                                                : ParkingSpaceStatus.FreeParkingSpace,
                       ResetCause = resetCause
                   };
        }

        /// <summary>
        ///     Gets the <see cref="DataRateConfiguration" /> from the given <see cref="byte" /> value.
        /// </summary>
        /// <param name="byteValue">The <see cref="byte" /> value to parse.</param>
        /// <returns>The <see cref="DataRateConfiguration" /> from the given <see cref="byte" /> value or <c>null</c>.</returns>
        // ReSharper disable once InconsistentNaming
        private static DataRateConfiguration? GetDataRateConfigurationFromByte(byte byteValue)
        {
            if (byteValue == 0x00)
            {
                return DataRateConfiguration.Dr0Sf12;
            }

            if (byteValue == 0x01)
            {
                return DataRateConfiguration.Dr1Sf11;
            }

            if (byteValue == 0x02)
            {
                return DataRateConfiguration.Dr2Sf10;
            }

            if (byteValue == 0x03)
            {
                return DataRateConfiguration.Dr3Sf9;
            }

            if (byteValue == 0x04)
            {
                return DataRateConfiguration.Dr4Sf8;
            }

            if (byteValue == 0x05)
            {
                return DataRateConfiguration.Dr5Sf7;
            }

            return null;
        }

        /// <summary>
        ///     Gets the <see cref="ResetCause" /> from the given <see cref="byte" /> value.
        /// </summary>
        /// <param name="byteValue">The <see cref="byte" /> value to parse.</param>
        /// <returns>The <see cref="ResetCause" /> from the given <see cref="byte" /> value or <c>null</c>.</returns>
        // ReSharper disable once InconsistentNaming
        private static ResetCause? GetResetCauseFromByte(byte byteValue)
        {
            if (byteValue == 0x01)
            {
                return ResetCause.WatchdogReset;
            }

            if (byteValue == 0x02)
            {
                return ResetCause.PowerOnReset;
            }

            if (byteValue == 0x03)
            {
                return ResetCause.SystemRequestReset;
            }

            if (byteValue == 0x04)
            {
                return ResetCause.OtherResets;
            }

            return null;
        }
    }
}