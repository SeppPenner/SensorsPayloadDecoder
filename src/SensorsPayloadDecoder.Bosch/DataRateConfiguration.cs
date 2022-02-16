// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataRateConfiguration.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   An enumeration for the data rate configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SensorsPayloadDecoder.Bosch;

/// <summary>
///     An enumeration for the data rate configuration.
/// </summary>
public enum DataRateConfiguration
{
    /// <summary>
    ///     The DR0 (SF12) data rate configuration.
    /// </summary>
    Dr0Sf12,

    /// <summary>
    ///     The DR1 (SF11) data rate configuration.
    /// </summary>
    Dr1Sf11,

    /// <summary>
    ///     The DR2 (SF10) data rate configuration.
    /// </summary>
    Dr2Sf10,

    /// <summary>
    ///     The DR3 (SF9) data rate configuration.
    /// </summary>
    Dr3Sf9,

    /// <summary>
    ///     The DR4 (SF8) data rate configuration.
    /// </summary>
    Dr4Sf8,

    /// <summary>
    ///     The DR5 (SF7) data rate configuration.
    /// </summary>
    Dr5Sf7
}
