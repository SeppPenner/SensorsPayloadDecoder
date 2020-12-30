// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestUplinkParkingStatusMessage.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s UplinkParkingStatusMessage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     This class provides some basic tests for the <see cref="BoschParkingSensorDecoder" />'s UplinkParkingStatusMessage.
    /// </summary>
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class TestParkingStatusMessage
    {
        /// <summary>
        ///     The Bosch sensor payload decoder.
        /// </summary>
        private static readonly BoschParkingSensorDecoder Decoder = new BoschParkingSensorDecoder();

        /// <summary>
        ///     Tests the decoder with a failing (too less bytes) uplink parking status message.
        /// </summary>
        [TestMethod]
        public void TestParkingStatusMessageFailingTooLessBytes()
        {
            var data = new byte[] { };
            try
            {
                var unused = Decoder.DecodePayload(data, MessageType.UplinkParkingStatusMessage);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("payload", ex.Message);
            }
        }

        /// <summary>
        ///     Tests the decoder with a failing (too much bytes) uplink parking status message.
        /// </summary>
        [TestMethod]
        public void TestParkingStatusMessageFailingTooMuchBytes()
        {
            var data = new byte[] { 0x01, 0x01 };
            try
            {
                var unused = Decoder.DecodePayload(data, MessageType.UplinkParkingStatusMessage);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The uplink parking status message must contain exactly 1 byte.", ex.Message);
            }
        }

        /// <summary>
        ///     Tests the decoder with a free uplink parking status message.
        /// </summary>
        [TestMethod]
        public void TestParkingStatusMessageFree()
        {
            var data = new byte[] { 0x00 };
            var result = Decoder.DecodePayload(data, MessageType.UplinkParkingStatusMessage);
            Assert.IsNotNull(result.ParkingSpaceStatus);
            Assert.AreEqual(ParkingSpaceStatus.FreeParkingSpace, result.ParkingSpaceStatus);
        }

        /// <summary>
        ///     Tests the decoder with an occupied uplink parking status message.
        /// </summary>
        [TestMethod]
        public void TestParkingStatusMessageOccupied()
        {
            var data = new byte[] { 0x01 };
            var result = Decoder.DecodePayload(data, MessageType.UplinkParkingStatusMessage);
            Assert.IsNotNull(result.ParkingSpaceStatus);
            Assert.AreEqual(ParkingSpaceStatus.OccupiedParkingSpace, result.ParkingSpaceStatus);
        }
    }
}