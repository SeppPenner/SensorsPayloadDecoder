﻿namespace SensorsPayloadDecoder.Elsys.ErsEye
{
    /// <summary>
    ///     This class contains the IR (infrared) temperature attributes of the <see cref="MessageResult" />.
    /// </summary>
    public class IrTemperature
    {
        /// <summary>
        ///     Gets or sets the external temperature value.
        /// </summary>
        public int? ExternalTemperature { get; set; }

        /// <summary>
        ///     Gets or sets the internal temperature value.
        /// </summary>
        public int? InternalTemperature { get; set; }
    }
}