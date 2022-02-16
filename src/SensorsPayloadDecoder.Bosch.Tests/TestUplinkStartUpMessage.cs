// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestUplinkStartUpMessage.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s UplinkStartUpMessage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch.Tests;

/// <summary>
///     This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s UplinkStartUpMessage.
/// </summary>
[TestClass]
public class TestUplinkStartUpMessage
{
    /// <summary>
    ///     Tests the decoder with a failing (too less bytes) uplink startup message.
    /// </summary>
    [TestMethod]
    public void TestParkingStatusMessageFailingTooLessBytes()
    {
        var data = Array.Empty<byte>();

        try
        {
            _ = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        }
        catch (Exception ex)
        {
            Assert.AreEqual("payload", ex.Message);
        }
    }

    /// <summary>
    ///     Tests the decoder with a failing (too much bytes) uplink startup message.
    /// </summary>
    [TestMethod]
    public void TestParkingStatusMessageFailingTooMuchBytes()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00
        };

        try
        {
            _ = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        }
        catch (Exception ex)
        {
            Assert.AreEqual("The uplink startup message must contain exactly 17 bytes.", ex.Message);
        }
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with a free parking space, the current firmware number 0.23.3 and
    ///     an invalid reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageFreeInvalidReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x05, 0x00
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.FreeParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNull(result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with a free parking space, the current firmware number 0.23.3 and
    ///     an "other reset" reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageFreeOtherReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x04, 0x00
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.FreeParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNotNull(result.ResetCause);
        Assert.AreEqual(ResetCause.OtherResets, result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with a free parking space, the current firmware number 0.23.3 and
    ///     a "power on reset" reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageFreePowerOnReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x02, 0x00
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.FreeParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNotNull(result.ResetCause);
        Assert.AreEqual(ResetCause.PowerOnReset, result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with a free parking space, the current firmware number 0.23.3 and
    ///     a "system request reset" reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageFreeSystemRequestReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x03, 0x00
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.FreeParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNotNull(result.ResetCause);
        Assert.AreEqual(ResetCause.SystemRequestReset, result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with a free parking space, the current firmware number 0.23.3 and
    ///     a "watchdog reset" reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageFreeWatchdogReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x01, 0x00
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.FreeParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNotNull(result.ResetCause);
        Assert.AreEqual(ResetCause.WatchdogReset, result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with an occupied parking space, the current firmware number 0.23.3
    ///     and an invalid reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageOccupiedInvalidReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x05, 0x01
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.OccupiedParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNull(result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with an occupied parking space, the current firmware number 0.23.3
    ///     and an "other reset" reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageOccupiedOtherReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x04, 0x01
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.OccupiedParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNotNull(result.ResetCause);
        Assert.AreEqual(ResetCause.OtherResets, result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with an occupied parking space, the current firmware number 0.23.3
    ///     and a "power on reset" reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageOccupiedPowerOnReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x02, 0x01
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.OccupiedParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNotNull(result.ResetCause);
        Assert.AreEqual(ResetCause.PowerOnReset, result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with an occupied parking space, the current firmware number 0.23.3
    ///     and a "system request reset" reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageOccupiedSystemRequestReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x03, 0x01
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.OccupiedParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNotNull(result.ResetCause);
        Assert.AreEqual(ResetCause.SystemRequestReset, result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }

    /// <summary>
    ///     Tests the decoder with an uplink startup message with an occupied parking space, the current firmware number 0.23.3
    ///     and a "watchdog reset" reset cause.
    /// </summary>
    [TestMethod]
    public void TestStartUpMessageOccupiedWatchdogReset()
    {
        var data = new byte[]
        {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x17, 0x00,
                0x01, 0x01
        };

        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.UplinkStartUpMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ParkingSpaceStatus);
        Assert.AreEqual(ParkingSpaceStatus.OccupiedParkingSpace, result.ParkingSpaceStatus);
        Assert.IsNotNull(result.ResetCause);
        Assert.AreEqual(ResetCause.WatchdogReset, result.ResetCause);
        Assert.IsNotNull(result.FirmwareInformation);
        Assert.AreEqual("0.23.3", result.FirmwareInformation);
    }
}
