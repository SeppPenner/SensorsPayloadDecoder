namespace SensorsPayloadDecoder.Elsys.ErsEye.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     This class provides some basic tests for the <see cref="ElsysHumidityPayloadDecoder" />'s
    ///     DownlinkConfirmableConfigurationMessage.
    /// </summary>
    [TestClass]
    public class BasicDecodingTests
    {
        /// <summary>
        ///     The Elsys ERS sensor payload decoder.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public static readonly ElsysHumidityPayloadDecoder Decoder = new ElsysHumidityPayloadDecoder();

        /// <summary>
        ///     Tests the decoder with a message containing motion and occupancy.
        /// </summary>
        [TestMethod]
        public void TestMotionOccupancy()
        {
            var data = new byte[] { 0x05, 0x01, 0x11, 0x01 };
            var result = Decoder.DecodePayload(data);
            Assert.IsNotNull(result.Motion);
            Assert.AreEqual(1, result.Motion);
            Assert.IsNotNull(result.Occupancy);
            Assert.AreEqual(1, result.Occupancy);
        }

        /// <summary>
        ///     Tests the decoder with a message containing temperature, humidity, light, motion, VDD and occupancy.
        /// </summary>
        [TestMethod]
        public void TestTemperatureHumidityLightMotionVddAndOccupancy()
        {
            var data = new byte[] { 0x01, 0x01, 0x16, 0x02, 0x29, 0x04, 0x00, 0x2C, 0x05, 0x05, 0x07, 0x0F, 0xDC, 0x11, 0x01 };
            var result = Decoder.DecodePayload(data);
            Assert.IsNotNull(result.Temperature);
            Assert.AreEqual(27.8, result.Temperature);
            Assert.IsNotNull(result.Humidity);
            Assert.AreEqual(41, result.Humidity);
            Assert.IsNotNull(result.Light);
            Assert.AreEqual(44, result.Light);
            Assert.IsNotNull(result.Motion);
            Assert.AreEqual(5, result.Motion);
            Assert.IsNotNull(result.Vdd);
            Assert.AreEqual(4060, result.Vdd);
            Assert.IsNotNull(result.Occupancy);
            Assert.AreEqual(1, result.Occupancy);
        }
    }
}