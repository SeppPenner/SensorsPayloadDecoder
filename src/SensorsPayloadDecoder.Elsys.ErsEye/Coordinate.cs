namespace SensorsPayloadDecoder.Elsys.ErsEye
{
    /// <summary>
    ///     This class contains the GPS coordinate attributes of the <see cref="MessageResult" />.
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        ///     Gets or sets the latitude value.
        /// </summary>
        public int? Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude value.
        /// </summary>
        public int? Longitude { get; set; }
    }
}