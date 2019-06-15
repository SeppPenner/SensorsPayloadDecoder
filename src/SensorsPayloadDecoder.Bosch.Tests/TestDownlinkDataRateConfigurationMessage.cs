namespace SensorsPayloadDecoder.Bosch.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s
    ///     DownlinkDataRateConfigurationMessage.
    /// </summary>
    [TestClass]
    public class TestDownlinkDataRateConfigurationMessage
    {
        /// <summary>
        ///     The Bosch sensor payload decoder.
        /// </summary>
        private static readonly BoschParkingSensorDecoder Decoder = new BoschParkingSensorDecoder();

        /// <summary>
        ///     Tests the decoder with a DR0 (SF12) downlink data rate configuration message.
        /// </summary>
        [TestMethod]
        public void TestDatarateConfigurationMessageDr0()
        {
            var data = new byte[] { 0x00 };
            var result = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
            Assert.IsNotNull(result.DataRateConfiguration);
            Assert.AreEqual(DataRateConfiguration.Dr0Sf12, result.DataRateConfiguration);
        }

        /// <summary>
        ///     Tests the decoder with a DR1 (SF11) downlink data rate configuration message.
        /// </summary>
        [TestMethod]
        public void TestDatarateConfigurationMessageDr1()
        {
            var data = new byte[] { 0x01 };
            var result = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
            Assert.IsNotNull(result.DataRateConfiguration);
            Assert.AreEqual(DataRateConfiguration.Dr1Sf11, result.DataRateConfiguration);
        }

        /// <summary>
        ///     Tests the decoder with a DR2 (SF10) downlink data rate configuration message.
        /// </summary>
        [TestMethod]
        public void TestDatarateConfigurationMessageDr2()
        {
            var data = new byte[] { 0x02 };
            var result = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
            Assert.IsNotNull(result.DataRateConfiguration);
            Assert.AreEqual(DataRateConfiguration.Dr2Sf10, result.DataRateConfiguration);
        }

        /// <summary>
        ///     Tests the decoder with a DR3 (SF9) downlink data rate configuration message.
        /// </summary>
        [TestMethod]
        public void TestDatarateConfigurationMessageDr3()
        {
            var data = new byte[] { 0x03 };
            var result = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
            Assert.IsNotNull(result.DataRateConfiguration);
            Assert.AreEqual(DataRateConfiguration.Dr3Sf9, result.DataRateConfiguration);
        }

        /// <summary>
        ///     Tests the decoder with a DR4 (SF8) downlink data rate configuration message.
        /// </summary>
        [TestMethod]
        public void TestDatarateConfigurationMessageDr4()
        {
            var data = new byte[] { 0x04 };
            var result = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
            Assert.IsNotNull(result.DataRateConfiguration);
            Assert.AreEqual(DataRateConfiguration.Dr4Sf8, result.DataRateConfiguration);
        }

        /// <summary>
        ///     Tests the decoder with a DR5 (SF7) downlink data rate configuration message.
        /// </summary>
        [TestMethod]
        public void TestDatarateConfigurationMessageDr5()
        {
            var data = new byte[] { 0x05 };
            var result = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
            Assert.IsNotNull(result.DataRateConfiguration);
            Assert.AreEqual(DataRateConfiguration.Dr5Sf7, result.DataRateConfiguration);
        }

        /// <summary>
        ///     Tests the decoder with a failing (too much bytes) downlink data rate configuration message.
        /// </summary>
        [TestMethod]
        public void TestDatarateConfigurationMessageFailingTooMuchBytes()
        {
            var data = new byte[] { 0x01, 0x01 };
            try
            {
                var unused = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
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
        public void TestDatarateConfigurationMessageInvalid()
        {
            var data = new byte[] { 0x07 };
            var result = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
            Assert.IsNull(result.DataRateConfiguration);
        }

        /// <summary>
        ///     Tests the decoder with a failing (too less bytes) downlink data rate configuration message.
        /// </summary>
        [TestMethod]
        public void TestDatarateConfigurationMessageMessageFailingTooLessBytes()
        {
            var data = new byte[] { };
            try
            {
                var unused = Decoder.DecodePayload(data, MessageType.DownlinkDataRateConfigurationMessage);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("payload", ex.Message);
            }
        }
    }
}