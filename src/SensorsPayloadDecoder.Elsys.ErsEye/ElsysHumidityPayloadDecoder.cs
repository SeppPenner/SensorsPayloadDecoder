// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElsysHumidityPayloadDecoder.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A payload decoder for the Elsys Ers Eye humidity sensor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Elsys.ErsEye
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     A payload decoder for the Elsys Ers Eye humidity sensor.
    /// </summary>
    public class ElsysHumidityPayloadDecoder
    {
        /// <summary>
        ///     Decodes the payload.
        /// </summary>
        /// <param name="payload">The payload to decode as <see cref="T:byte{}" />.</param>
        /// <returns>A <see cref="MessageResult" /> that contains all the information of the message depending on the message type.</returns>
        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once InconsistentNaming
        public MessageResult DecodePayload(byte[] payload)
        {
            if (payload == null || payload.Length == 0)
            {
                throw new ArgumentException(nameof(payload));
            }

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(payload);
            }

            return DecodeElsysPayload(payload);
        }

        /// <summary>
        ///     Converts the 16 bit binary value to a signed <c>int</c>.
        /// </summary>
        /// <param name="bin">The binary value.</param>
        /// <returns>The corresponding signed <c>int</c> value.</returns>
        // ReSharper disable once InconsistentNaming
        private static int Bin16ToDecimal(int bin)
        {
            var num = bin & 0xFFFF;

            if ((0x8000 & num) > 0)
            {
                num = -(0x010000 - num);
            }

            return num;
        }

        /// <summary>
        ///     Converts the 8 bit binary value to a signed <c>int</c>.
        /// </summary>
        /// <param name="bin">The binary value.</param>
        /// <returns>The corresponding signed <c>int</c> value.</returns>
        // ReSharper disable once InconsistentNaming
        private static int Bin8ToDecimal(int bin)
        {
            var num = bin & 0xFF;

            if ((0x80 & num) > 0)
            {
                num = -(0x0100 - num);
            }

            return num;
        }

        /// <summary>
        ///     Decodes the Elsys Ers Eye humidity sensor payload internally.
        /// </summary>
        /// <param name="data">The payload to decode as <see cref="T:byte{}" />.</param>
        /// <returns>A <see cref="MessageResult" /> that contains all the information of the message depending on the message type.</returns>
        // ReSharper disable once InconsistentNaming
        private static MessageResult DecodeElsysPayload(IReadOnlyList<byte> data)
        {
            var result = new MessageResult();
            for (var i = 0; i < data.Count; i++)
            {
                switch (data[i])
                {
                    case Constants.TemperatureType: // Temperature value.
                        var temperature = (data[i + 1] << 8) | data[i + 2];
                        temperature = Bin16ToDecimal(temperature);
                        result.Temperature = (double)temperature / 10;
                        i += 2;
                        break;

                    case Constants.HumidityType: // Humidity value.
                        var rh = data[i + 1];
                        result.Humidity = rh;
                        i += 1;
                        break;

                    case Constants.AccelerationType: // Acceleration value.
                        result.Acceleration.X = Bin8ToDecimal(data[i + 1]);
                        result.Acceleration.Y = Bin8ToDecimal(data[i + 2]);
                        result.Acceleration.Z = Bin8ToDecimal(data[i + 3]);
                        i += 3;
                        break;

                    case Constants.LightType: // Light value.
                        result.Light = (data[i + 1] << 8) | data[i + 2];
                        i += 2;
                        break;

                    case Constants.MotionType: // Motion sensor (PIR) value.
                        result.Motion = data[i + 1];
                        i += 1;
                        break;

                    case Constants.C02Type: // CO2 value.
                        result.Co2 = (data[i + 1] << 8) | data[i + 2];
                        i += 2;
                        break;

                    case Constants.VddType: // Battery level value.
                        result.Vdd = (data[i + 1] << 8) | data[i + 2];
                        i += 2;
                        break;

                    case Constants.Analog1Type: // Analog input 1 value.
                        result.AnalogInput1 = (data[i + 1] << 8) | data[i + 2];
                        i += 2;
                        break;

                    case Constants.GpsType: // GPS coordinate value.
                        result.GpsCoordinate.Latitude = (data[i + 1] << 16) | (data[i + 2] << 8) | data[i + 3];
                        result.GpsCoordinate.Longitude = (data[i + 4] << 16) | (data[i + 5] << 8) | data[i + 6];
                        i += 6;
                        break;

                    case Constants.Pulse1Type: // Pulse input 1 value.
                        result.PulseInput1 = (data[i + 1] << 8) | data[i + 2];
                        i += 2;
                        break;

                    case Constants.Pulse1AbsoluteType: // Pulse input 1 absolute value.
                        var pulseAbs = (data[i + 1] << 24) | (data[i + 2] << 16) | (data[i + 3] << 8) | data[i + 4];
                        result.PulseInput1Absolute = pulseAbs;
                        i += 4;
                        break;

                    case Constants.Temperature1Type: // External temperature value.
                        var extTemp = (data[i + 1] << 8) | data[i + 2];
                        extTemp = Bin16ToDecimal(extTemp);
                        result.ExternalTemperature1 = extTemp / 10;
                        i += 2;
                        break;

                    case Constants.DigitalInput1Type: // Digital input value.
                        result.Digital1Input = data[i + 1];
                        i += 1;
                        break;

                    case Constants.DistanceType: // Distance sensor input value.
                        result.Distance = (data[i + 1] << 8) | data[i + 2];
                        i += 2;
                        break;

                    case Constants.AccMotionType: // Acc motion value.
                        result.AccMotion = data[i + 1];
                        i += 1;
                        break;

                    case Constants.IrTemperatureType: // IR temperature value.
                        var internalTemperature = (data[i + 1] << 8) | data[i + 2];
                        internalTemperature = Bin16ToDecimal(internalTemperature);
                        var externalTemperature = (data[i + 3] << 8) | data[i + 4];
                        externalTemperature = Bin16ToDecimal(externalTemperature);
                        result.IrTemperature.InternalTemperature = internalTemperature / 10;
                        result.IrTemperature.ExternalTemperature = externalTemperature / 10;
                        i += 4;
                        break;

                    case Constants.OccupancyType: // Body occupancy value.
                        result.Occupancy = data[i + 1];
                        i += 1;
                        break;

                    case Constants.WaterleakType: // Water leak value.
                        result.Waterleak = data[i + 1];
                        i += 1;
                        break;

                    case Constants.GridEyeType: // Grideye data value.
                        i += 65;
                        break;

                    case Constants.PressureType: // External Pressure value.
                        var temp = (data[i + 1] << 24) | (data[i + 2] << 16) | (data[i + 3] << 8) | data[i + 4];
                        result.ExternalPressure = temp / 1000;
                        i += 4;
                        break;

                    case Constants.SoundType: // Sound value.
                        result.Sound.SoundPeak = data[i + 1];
                        result.Sound.SoundAverage = data[i + 2];
                        i += 2;
                        break;

                    case Constants.Pulse2Type: // Pulse input 2 value.
                        result.PulseInput2 = (data[i + 1] << 8) | data[i + 2];
                        i += 2;
                        break;

                    case Constants.Pulse2AbsoluteType: // Pulse input 2 absolute value.
                        result.PulseInput2Absolute =
                            (data[i + 1] << 24) | (data[i + 2] << 16) | (data[i + 3] << 8) | data[i + 4];
                        i += 4;
                        break;

                    case Constants.Analog2Type: // Analog input 2 value.
                        result.AnalogInput2 = (data[i + 1] << 8) | data[i + 2];
                        i += 2;
                        break;

                    case Constants.Temperature2Type: // External temperature 2 value.
                        var externalTemperature2 = (data[i + 1] << 8) | data[i + 2];
                        externalTemperature2 = Bin16ToDecimal(externalTemperature2);
                        result.ExternalTemperature2 = externalTemperature2 / 10;
                        i += 2;
                        break;
                    case Constants.DigitalInput2Type: // Digital input 2 value.
                        result.Digital2Input = data[i + 1];
                        i += 1;
                        break;

                    default: // Something is wrong with the data.
                        i = data.Count;
                        break;
                }
            }

            return result;
        }
    }
}