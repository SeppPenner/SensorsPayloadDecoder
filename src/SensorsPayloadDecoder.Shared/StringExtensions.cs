// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class contains extension methods for the <see cref="string" /> data type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Shared
{
    using System.Globalization;

    /// <summary>
    ///     This class contains extension methods for the <see cref="string" /> data type.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static class StringExtensions
    {
        /// <summary>
        ///     Converts a hexadecimal <see cref="string" /> to a <see cref="T:byte{}" />.
        /// </summary>
        /// <param name="hex">The hex <see cref="string" />.</param>
        /// <returns>The corresponding <see cref="T:byte{}" />.</returns>
        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once StyleCop.SA1650
        // ReSharper disable once InconsistentNaming
        public static byte[] HexToBytes(this string hex)
        {
            hex = hex.Trim();

            var bytes = new byte[hex.Length / 2];

            for (var index = 0; index < bytes.Length; index++)
            {
                bytes[index] = byte.Parse(hex.Substring(index * 2, 2), NumberStyles.HexNumber);
            }

            return bytes;
        }
    }
}