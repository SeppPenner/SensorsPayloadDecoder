// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDownlinkConfirmableConfigurationMessage.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s
//   DownlinkConfirmableConfigurationMessage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch.Tests;

/// <summary>
///     This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s
///     DownlinkConfirmableConfigurationMessage.
/// </summary>
[TestClass]
public class TestDownlinkConfirmableConfigurationMessage
{
    /// <summary>
    ///     Tests the decoder with a confirmable downlink confirmable configuration message.
    /// </summary>
    [TestMethod]
    public void TestConfirmableConfigurationMessageConfirmable()
    {
        var data = new byte[] { 0x00 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkConfirmableConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ConfirmableStatus);
        Assert.AreEqual(ConfirmableStatus.Confirmable, result.ConfirmableStatus);
    }

    /// <summary>
    ///     Tests the decoder with a failing (too less bytes) downlink confirmable configuration message.
    /// </summary>
    [TestMethod]
    public void TestConfirmableConfigurationMessageFailingTooLessBytes()
    {
        var data = Array.Empty<byte>();

        try
        {
            _ = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkConfirmableConfigurationMessage);
        }
        catch (Exception ex)
        {
            Assert.AreEqual("payload", ex.Message);
        }
    }

    /// <summary>
    ///     Tests the decoder with a failing (too much bytes) downlink confirmable configuration message.
    /// </summary>
    [TestMethod]
    public void TestConfirmableConfigurationMessageFailingTooMuchBytes()
    {
        var data = new byte[] { 0x01, 0x01 };
        try
        {
            _ = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkConfirmableConfigurationMessage);
        }
        catch (Exception ex)
        {
            Assert.AreEqual(
                "The downlink confirmable configuration message must contain exactly 1 byte.",
                ex.Message);
        }
    }

    /// <summary>
    ///     Tests the decoder with a not confirmable downlink confirmable configuration message.
    /// </summary>
    [TestMethod]
    public void TestConfirmableConfigurationMessageNotConfirmable()
    {
        var data = new byte[] { 0x01 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkConfirmableConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ConfirmableStatus);
        Assert.AreEqual(ConfirmableStatus.NotConfirmable, result.ConfirmableStatus);
    }
}
