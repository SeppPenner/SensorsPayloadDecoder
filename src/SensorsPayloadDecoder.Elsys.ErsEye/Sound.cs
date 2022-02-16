// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sound.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   This class contains the sound attributes of the <see cref="MessageResult" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Elsys.ErsEye;

/// <summary>
///     This class contains the sound attributes of the <see cref="MessageResult" />.
/// </summary>
public class Sound
{
    /// <summary>
    ///     Gets or sets the sound average value.
    /// </summary>
    public int? SoundAverage { get; set; }

    /// <summary>
    ///     Gets or sets the sound peak value.
    /// </summary>
    public int? SoundPeak { get; set; }
}
