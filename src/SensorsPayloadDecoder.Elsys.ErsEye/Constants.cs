// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class contains constant types for the <see cref="ElsysHumidityPayloadDecoder" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Elsys.ErsEye;

/// <summary>
///     This class contains constant types for the <see cref="ElsysHumidityPayloadDecoder" />.
/// </summary>
public static class Constants
{
    /// <summary>
    ///     The acceleration type. 3 bytes. From -128 to 127. +/-63 = 1G.
    /// </summary>
    public const byte AccelerationType = 0x03;

    /// <summary>
    ///     The ACC motion type. 1 byte. Number of motion.
    /// </summary>
    public const byte AccMotionType = 0x0F;

    /// <summary>
    ///     The analog 1 type. 2 bytes. From 0 to 65535 mV.
    /// </summary>
    public const byte Analog1Type = 0x08;

    /// <summary>
    ///     The analog 2 type. 2 bytes. From 0 to 65535 mV.
    /// </summary>
    public const byte Analog2Type = 0x18;

    /// <summary>
    ///     The CO2 type. 2 bytes. From 0 to 65535 ppm.
    /// </summary>
    public const byte C02Type = 0x06;

    /// <summary>
    ///     The debug type. 4 bytes.
    /// </summary>
    public const byte DebugType = 0x3D;

    /// <summary>
    ///     The digital input 1 type. 1 byte. Either 0 or 1.
    /// </summary>
    public const byte DigitalInput1Type = 0x0D;

    /// <summary>
    ///     The digital input 1 type. 1 byte. Either 0 or 1.
    /// </summary>
    public const byte DigitalInput2Type = 0x1A;

    /// <summary>
    ///     The distance type. 2 bytes. In mm.
    /// </summary>
    public const byte DistanceType = 0x0E;

    /// <summary>
    ///     The GPS coordinates type. 6 bytes (3 bytes latitude, 3 bytes longitude). Binary format.
    /// </summary>
    public const byte GpsType = 0x09;

    /// <summary>
    ///     The grid eye type. 65 bytes (1 byte temperature, 64 byte external temperature).
    /// </summary>
    public const byte GridEyeType = 0x13;

    /// <summary>
    ///     The humidity type. 1 byte. From 0 to 100%.
    /// </summary>
    public const byte HumidityType = 0x02;

    /// <summary>
    ///     The infrared temperature type. 4 bytes (2 bytes internal temperature, 2 bytes external temperature). From -3276.8
    ///     °C to 3276.7 °C.
    /// </summary>
    public const byte IrTemperatureType = 0x10;

    /// <summary>
    ///     The light type. 2 bytes. From 0 to 65535 Lux.
    /// </summary>
    public const byte LightType = 0x04;

    /// <summary>
    ///     The motion type. 1 byte.
    /// </summary>
    public const byte MotionType = 0x05;

    /// <summary>
    ///     The occupancy type. 1 byte.
    /// </summary>
    public const byte OccupancyType = 0x11;

    /// <summary>
    ///     The pressure type. 4 bytes. In hPa.
    /// </summary>
    public const byte PressureType = 0x14;

    /// <summary>
    ///     The pulse 1 absolute type. 4 bytes.
    /// </summary>
    public const byte Pulse1AbsoluteType = 0x0B;

    /// <summary>
    ///     The pulse 1 type. 2 bytes. Relative pulse count.
    /// </summary>
    public const byte Pulse1Type = 0x0A;

    /// <summary>
    ///     The pulse 2 absolute type. 4 bytes.
    /// </summary>
    public const byte Pulse2AbsoluteType = 0x17;

    /// <summary>
    ///     The pulse 2 type. 2 bytes. Relative pulse count.
    /// </summary>
    public const byte Pulse2Type = 0x16;

    /// <summary>
    ///     The sound type. 2 bytes. (1 byte peak, 1 byte average).
    /// </summary>
    public const byte SoundType = 0x15;

    /// <summary>
    ///     The external 1 temperature type. 2 bytes. From -3276.8 °C to 3276.7 °C.
    /// </summary>
    public const byte Temperature1Type = 0x0C;

    /// <summary>
    ///     The external 2 temperature type. 2 bytes. From -3276.8 °C to 3276.7 °C.
    /// </summary>
    public const byte Temperature2Type = 0x19;

    /// <summary>
    ///     The temperature type. 2 bytes. From -3276.8 °C to 3276.7 °C.
    /// </summary>
    public const byte TemperatureType = 0x01;

    /// <summary>
    ///     The VDD (battery level) type. 2 bytes. From 0 to 65535 mV.
    /// </summary>
    public const byte VddType = 0x07;

    /// <summary>
    ///     The water leak type. 1 byte.
    /// </summary>
    public const byte WaterleakType = 0x12;
}
