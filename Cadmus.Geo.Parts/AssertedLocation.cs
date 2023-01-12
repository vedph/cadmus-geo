using Cadmus.Refs.Bricks;
using System.Text;

namespace Cadmus.Geo.Parts;

/// <summary>
/// Minimalist geographic location. This includes a point, a bounding box,
/// and a geometry, where at least the point should be specified.
/// Optionally it can have an <see cref="Assertion"/> representing its
/// level of certainty and related references.
/// </summary>
public class AssertedLocation : IHasAssertion
{
    /// <summary>
    /// Gets or sets an optional tag. This can be used to distinguish different
    /// types of locations.
    /// </summary>
    public string? Tag { get; set; }

    /// <summary>
    /// Gets or sets the reference point for this location.
    /// </summary>
    public LocationPoint Point { get; set; }

    /// <summary>
    /// Gets or sets the reference bounding box for this location.
    /// </summary>
    public LocationBox? Box { get; set; }

    /// <summary>
    /// Gets or sets the optional reference point altitude.
    /// </summary>
    public double? Altitude { get; set; }

    /// <summary>
    /// Gets or sets the optional geometry used to represent the region
    /// covered by this location (see e.g.
    /// http://postgis.net/workshops/postgis-intro/geometries.html)
    /// </summary>
    public string? Geometry { get; set; }

    /// <summary>
    /// Gets or sets the assertion.
    /// </summary>
    public Assertion? Assertion { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AssertedLocation"/> class.
    /// </summary>
    public AssertedLocation()
    {
        Point = new LocationPoint();
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("[Location] ").Append(Point);
        if (Altitude != null) sb.Append(" alt: ").Append(Altitude.Value);
        if (Box != null) sb.Append(" box: ").Append(Box);

        return sb.ToString();
    }
}
