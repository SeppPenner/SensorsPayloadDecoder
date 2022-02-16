// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteExtensions.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class contains extension methods for the <see cref="byte" /> data type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Shared;

/// <summary>
///     This class contains extension methods for the <see cref="byte" /> data type.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     Determines whether [is bit set] [the specified position]. This method is used to check if a bit on a given position
    ///     is set in a <see cref="byte" />.
    /// </summary>
    /// <param name="b">The <see cref="byte" />.</param>
    /// <param name="pos">The position.</param>
    /// <returns>
    ///     <c>true</c> if [is bit set] [the specified position]; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">pos - Index must be in the range of 0-7.</exception>
    public static bool IsBitSet(this byte b, int pos)
    {
        if (pos < 0 || pos > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Index must be in the range of 0-7.");
        }

        return (b & (1 << pos)) != 0;
    }

    /// <summary>
    ///     This method is used to set a bit on a given position in a <see cref="byte" />.
    /// </summary>
    /// <param name="b">The <see cref="byte" />.</param>
    /// <param name="pos">The position.</param>
    /// <returns>The set <see cref="byte" />.</returns>
    /// <exception cref="ArgumentOutOfRangeException">pos - Index must be in the range of 0-7.</exception>
    public static byte SetBit(this byte b, int pos)
    {
        if (pos < 0 || pos > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Index must be in the range of 0-7.");
        }

        return (byte)(b | (1 << pos));
    }

    /// <summary>
    ///     Converts a <see cref="byte" /> to a binary <see cref="string" />.
    /// </summary>
    /// <param name="b">The <see cref="byte" />.</param>
    /// <returns>The changed <see cref="byte" />.</returns>
    public static string ToBinaryString(this byte b)
    {
        return Convert.ToString(b, 2).PadLeft(8, '0');
    }

    /// <summary>
    ///     This method is used to toggle a bit on a given position in a <see cref="byte" />.
    /// </summary>
    /// <param name="b">The <see cref="byte" />.</param>
    /// <param name="pos">The position.</param>
    /// <returns>The changed <see cref="byte" />.</returns>
    public static byte ToggleBit(this byte b, int pos)
    {
        if (pos < 0 || pos > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Index must be in the range of 0-7.");
        }

        return (byte)(b ^ (1 << pos));
    }

    /// <summary>
    ///     This method is used to unset a bit on a given position in a <see cref="byte" />.
    /// </summary>
    /// <param name="b">The <see cref="byte" />.</param>
    /// <param name="pos">The position.</param>
    /// <returns>The changed <see cref="byte" />.</returns>
    /// <exception cref="ArgumentOutOfRangeException">pos - Index must be in the range of 0-7.</exception>
    public static byte UnsetBit(this byte b, int pos)
    {
        if (pos < 0 || pos > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Index must be in the range of 0-7.");
        }

        return (byte)(b & ~(1 << pos));
    }
}
