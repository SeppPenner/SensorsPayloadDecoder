// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDownlinkDataRateConfigurationMessage.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s
//   DownlinkDataRateConfigurationMessage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch.Tests;

/// <summary>
///     This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s
///     DownlinkDataRateConfigurationMessage.
/// </summary>
[TestClass]
public class TestDownlinkDataRateConfigurationMessage
{
    /// <summary>
    ///     Tests the decoder with a DR0 (SF12) downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageDr0()
    {
        var data = new byte[] { 0x00 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.DataRateConfiguration);
        Assert.AreEqual(DataRateConfiguration.Dr0Sf12, result.DataRateConfiguration);
    }

    /// <summary>
    ///     Tests the decoder with a DR1 (SF11) downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageDr1()
    {
        var data = new byte[] { 0x01 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.DataRateConfiguration);
        Assert.AreEqual(DataRateConfiguration.Dr1Sf11, result.DataRateConfiguration);
    }

    /// <summary>
    ///     Tests the decoder with a DR2 (SF10) downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageDr2()
    {
        var data = new byte[] { 0x02 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.DataRateConfiguration);
        Assert.AreEqual(DataRateConfiguration.Dr2Sf10, result.DataRateConfiguration);
    }

    /// <summary>
    ///     Tests the decoder with a DR3 (SF9) downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageDr3()
    {
        var data = new byte[] { 0x03 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.DataRateConfiguration);
        Assert.AreEqual(DataRateConfiguration.Dr3Sf9, result.DataRateConfiguration);
    }

    /// <summary>
    ///     Tests the decoder with a DR4 (SF8) downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageDr4()
    {
        var data = new byte[] { 0x04 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.DataRateConfiguration);
        Assert.AreEqual(DataRateConfiguration.Dr4Sf8, result.DataRateConfiguration);
    }

    /// <summary>
    ///     Tests the decoder with a DR5 (SF7) downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageDr5()
    {
        var data = new byte[] { 0x05 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.DataRateConfiguration);
        Assert.AreEqual(DataRateConfiguration.Dr5Sf7, result.DataRateConfiguration);
    }

    /// <summary>
    ///     Tests the decoder with a failing (too much bytes) downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageFailingTooMuchBytes()
    {
        var data = new byte[] { 0x01, 0x01 };

        try
        {
            _ = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        }
        catch (Exception ex)
        {
            Assert.AreEqual(
                "The downlink data rate configuration message must contain exactly 1 byte.",
                ex.Message);
        }
    }

    /// <summary>
    ///     Tests the decoder with an invalid downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageInvalid()
    {
        var data = new byte[] { 0x07 };
        var result = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        Assert.IsNotNull(result);
        Assert.IsNull(result.DataRateConfiguration);
    }

    /// <summary>
    ///     Tests the decoder with a failing (too less bytes) downlink data rate configuration message.
    /// </summary>
    [TestMethod]
    public void TestDataRateConfigurationMessageMessageFailingTooLessBytes()
    {
        var data = Array.Empty<byte>();

        try
        {
            _ = BoschParkingSensorDecoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
        }
        catch (Exception ex)
        {
            Assert.AreEqual("payload", ex.Message);
        }
    }
}
