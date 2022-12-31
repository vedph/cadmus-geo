namespace Cadmus.Geo.Parts;

/// <summary>
/// A geographical point used by <see cref="AssertedLocationsPart"/>.
/// </summary>
public class LocationPoint
{
    /// <summary>
    /// Gets or sets the latitude.
    /// </summary>
    public double Lat { get; set; }
    /// <summary>
    /// Gets or sets the longitude.
    /// </summary>
    public double Lon { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationPoint"/> class.
    /// </summary>
    public LocationPoint()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationPoint"/> class.
    /// </summary>
    /// <param name="lat">The latitude.</param>
    /// <param name="lon">The longitude.</param>
    public LocationPoint(double lat, double lon)
    {
        Lat = lat;
        Lon = lon;
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>A <see cref="string" /> that represents this instance.</returns>
    public override string ToString()
    {
        return $"{Lat}, {Lon}";
    }
}
