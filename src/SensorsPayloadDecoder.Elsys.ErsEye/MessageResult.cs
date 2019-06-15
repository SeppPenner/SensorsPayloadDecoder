namespace SensorsPayloadDecoder.Elsys.ErsEye
{
    /// <summary>
    ///     The result decoded from the decoder.
    /// </summary>
    public class MessageResult
    {
        /// <summary>
        ///     Gets or sets the acceleration value.
        /// </summary>
        public Acceleration Acceleration { get; set; } = new Acceleration();

        /// <summary>
        ///     Gets or sets the Acc motion value.
        /// </summary>
        public int? AccMotion { get; set; }

        /// <summary>
        ///     Gets or sets the analog input 1 value.
        /// </summary>
        public int? AnalogInput1 { get; set; }

        /// <summary>
        ///     Gets or sets the analog input 2 value.
        /// </summary>
        public int? AnalogInput2 { get; set; }

        /// <summary>
        ///     Gets or sets the CO2 value.
        /// </summary>
        public int? Co2 { get; set; }

        /// <summary>
        ///     Gets or sets the digital 1 input value.
        /// </summary>
        public int? Digital1Input { get; set; }

        /// <summary>
        ///     Gets or sets the digital 2 input value.
        /// </summary>
        public int? Digital2Input { get; set; }

        /// <summary>
        ///     Gets or sets the distance value.
        /// </summary>
        public int? Distance { get; set; }

        /// <summary>
        ///     Gets or sets the external pressure value.
        /// </summary>
        public int? ExternalPressure { get; set; }

        /// <summary>
        ///     Gets or sets the external temperature 1 value.
        /// </summary>
        public int? ExternalTemperature1 { get; set; }

        /// <summary>
        ///     Gets or sets the external temperature 2 value.
        /// </summary>
        public int? ExternalTemperature2 { get; set; }

        /// <summary>
        ///     Gets or sets the GPS coordinate values.
        /// </summary>
        public Coordinate GpsCoordinate { get; set; } = new Coordinate();

        /// <summary>
        ///     Gets or sets the humidity value.
        /// </summary>
        public int? Humidity { get; set; }

        /// <summary>
        ///     Gets or sets the IR (infrared) temperature value.
        /// </summary>
        public IrTemperature IrTemperature { get; set; } = new IrTemperature();

        /// <summary>
        ///     Gets or sets the light value.
        /// </summary>
        public int? Light { get; set; }

        /// <summary>
        ///     Gets or sets the motion value.
        /// </summary>
        public int? Motion { get; set; }

        /// <summary>
        ///     Gets or sets the occupancy value.
        /// </summary>
        public int? Occupancy { get; set; }

        /// <summary>
        ///     Gets or sets the pulse input 1 value.
        /// </summary>
        public int? PulseInput1 { get; set; }

        /// <summary>
        ///     Gets or sets the pulse input 1 absolute value.
        /// </summary>
        public int? PulseInput1Absolute { get; set; }

        /// <summary>
        ///     Gets or sets the pulse input 2 value.
        /// </summary>
        public int? PulseInput2 { get; set; }

        /// <summary>
        ///     Gets or sets the pulse input 2 absolute value.
        /// </summary>
        public int? PulseInput2Absolute { get; set; }

        /// <summary>
        ///     Gets or sets the sound value.
        /// </summary>
        public Sound Sound { get; set; } = new Sound();

        /// <summary>
        ///     Gets or sets the temperature value.
        /// </summary>
        public double? Temperature { get; set; }

        /// <summary>
        ///     Gets or sets the VDD (battery level) value.
        /// </summary>
        public int? Vdd { get; set; }

        /// <summary>
        ///     Gets or sets the water leak value.
        /// </summary>
        public int? Waterleak { get; set; }
    }
}