// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Acceleration.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class contains the acceleration attributes of the <see cref="MessageResult" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Elsys.ErsEye
{
    /// <summary>
    ///     This class contains the acceleration attributes of the <see cref="MessageResult" />.
    /// </summary>
    public class Acceleration
    {
        /// <summary>
        ///     Gets or sets the x value.
        /// </summary>
        public int? X { get; set; }

        /// <summary>
        ///     Gets or sets the y value.
        /// </summary>
        public int? Y { get; set; }

        /// <summary>
        ///     Gets or sets the z value.
        /// </summary>
        public int? Z { get; set; }
    }
}