// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetCause.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   An enumeration for the reset cause flag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch;

/// <summary>
///     An enumeration for the reset cause flag.
/// </summary>
public enum ResetCause
{
    /// <summary>
    ///     The watchdog reset reset cause.
    /// </summary>
    WatchdogReset,

    /// <summary>
    ///     The power on reset cause.
    /// </summary>
    PowerOnReset,

    /// <summary>
    ///     The system request reset cause.
    /// </summary>
    SystemRequestReset,

    /// <summary>
    ///     The other reset cause.
    /// </summary>
    OtherResets
}
