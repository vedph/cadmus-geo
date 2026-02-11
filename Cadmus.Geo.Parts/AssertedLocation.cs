using Cadmus.Refs.Bricks;

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
    /// Gets or sets the geographic location.
    /// </summary>
    public GeoLocation Value { get; set; } = new();

    /// <summary>
    /// Gets or sets the assertion.
    /// </summary>
    public Assertion? Assertion { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return Value.ToString();
    }
}
