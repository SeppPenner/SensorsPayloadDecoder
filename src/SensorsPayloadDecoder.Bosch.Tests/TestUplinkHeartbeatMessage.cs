namespace SensorsPayloadDecoder.Bosch.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s UplinkHeartbeatMessage.
    /// </summary>
    [TestClass]
    public class TestUplinkHeartbeatMessage
    {
        /// <summary>
        ///     The Bosch sensor payload decoder.
        /// </summary>
        private static readonly BoschParkingSensorDecoder Decoder = new BoschParkingSensorDecoder();

        /// <summary>
        ///     Tests the decoder with a failing (too less bytes) uplink heartbeat message.
        /// </summary>
        [TestMethod]
        public void TestHeartbeatMessageFailingTooLessBytes()
        {
            var data = new byte[] { };
            try
            {
                var unused = Decoder.DecodePayload(data, MessageType.UplinkHeartbeatMessage);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("payload", ex.Message);
            }
        }

        /// <summary>
        ///     Tests the decoder with a failing (too much bytes) uplink heartbeat message.
        /// </summary>
        [TestMethod]
        public void TestHeartbeatMessageFailingTooMuchBytes()
        {
            var data = new byte[] { 0x01, 0x01 };
            try
            {
                var unused = Decoder.DecodePayload(data, MessageType.UplinkHeartbeatMessage);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The uplink heartbeat message must contain exactly 1 byte.", ex.Message);
            }
        }

        /// <summary>
        ///     Tests the decoder with a free uplink heartbeat message.
        /// </summary>
        [TestMethod]
        public void TestHeartbeatMessageFree()
        {
            var data = new byte[] { 0x00 };
            var result = Decoder.DecodePayload(data, MessageType.UplinkHeartbeatMessage);
            Assert.IsNotNull(result.ParkingSpaceStatus);
            Assert.AreEqual(ParkingSpaceStatus.FreeParkingSpace, result.ParkingSpaceStatus);
        }

        /// <summary>
        ///     Tests the decoder with an occupied uplink heartbeat message.
        /// </summary>
        [TestMethod]
        public void TestHeartbeatMessageOccupied()
        {
            var data = new byte[] { 0x01 };
            var result = Decoder.DecodePayload(data, MessageType.UplinkHeartbeatMessage);
            Assert.IsNotNull(result.ParkingSpaceStatus);
            Assert.AreEqual(ParkingSpaceStatus.OccupiedParkingSpace, result.ParkingSpaceStatus);
        }
    }
}