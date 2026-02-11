using System.Text;

namespace Cadmus.Geo.Parts;

/// <summary>
/// A single geographic location, defined by a point (latitude and longitude,
/// and optionally an altitude) with a label, plus optionally an uncertainty
/// radius, a geometric representation, and a note.
/// </summary>
public class GeoLocation
{
    /// <summary>
    /// Gets or sets an optional entity ID for this location.
    /// </summary>
    public string? Eid { get; set; }

    /// <summary>
    /// The label associated with the location.
    /// </summary>
    public string Label { get; set; } = "";

    /// <summary>
    /// Gets or sets the latitude coordinate, expressed in degrees.
    /// </summary>
    /// <remarks>Valid latitude values range from -90.0 (south pole) to 90.0
    /// (north pole).</remarks>
    public double Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude coordinate, expressed in degrees.
    /// </summary>
    /// <remarks>Valid longitude values range from -180.0 (west) to 180.0
    /// (east).</remarks>
    public double Longitude { get; set; }

    /// <summary>
    /// Gets or sets the altitude, in meters, above sea level.
    /// </summary>
    /// <remarks>The value can be null if the altitude is not specified.
    /// Ensure that the value, if provided, represents a valid altitude
    /// measurement in meters.</remarks>
    public double? Altitude { get; set; }

    /// <summary>
    /// Gets or sets the uncertainty radius in meters. This represents the
    /// radius of a circle whose center is the point defined by the latitude
    /// and longitude, and within which the actual location is likely to be found.
    /// The value can be null if the point is considered exact.
    /// </summary>
    public double? Radius { get; set; }

    /// <summary>
    /// Gets or sets the geometric representation of the object as a string,
    /// usually in WKT or GeoJSON.
    /// </summary>
    /// <remarks>The geometry string should be formatted according to the
    /// requirements of the consuming application or service. Invalid or improperly
    /// formatted geometry data may result in errors during processing or
    /// interpretation.</remarks>
    public string? Geometry { get; set; }

    /// <summary>
    /// Gets or sets the additional notes associated with the entity.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Converts this object to a string representation.
    /// </summary>
    /// <returns>String.</returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Label);
        if (Latitude != 0 || Longitude != 0)
        {
            sb.Append($" ({Latitude}, {Longitude}");
            if (Altitude.HasValue)
                sb.Append($", {Altitude.Value} m");
            if (Radius.HasValue)
                sb.Append($", ±{Radius.Value} m");
            sb.Append(')');
        }
        return sb.ToString();
    }
}
