namespace Cadmus.Geo.Parts;

/// <summary>
/// A bounding box defined by two corner points and used by
/// <see cref="AssertedLocationsPart"/>.
/// </summary>
public class LocationBox
{
    /// <summary>
    /// Gets or sets the box corner A.
    /// </summary>
    public LocationPoint? A { get; set; }

    /// <summary>
    /// Gets or sets the box corner B.
    /// </summary>
    public LocationPoint? B { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{A} - {B}";
    }
}
