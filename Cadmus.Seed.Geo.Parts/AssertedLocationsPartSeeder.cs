using Bogus;
using Cadmus.Core;
using Cadmus.Geo.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.Geo.Parts;

/// <summary>
/// Seeder for <see cref="AssertedLocations"/> part.
/// Tag: <c>seed.it.vedph.geo.asserted-locations</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.geo.asserted-locations")]
public sealed class AssertedLocationsPartSeeder : PartSeederBase
{
    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part or null.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        ArgumentNullException.ThrowIfNull(item);

        AssertedLocationsPart part = new Faker<AssertedLocationsPart>()
           .RuleFor(p => p.Locations, f =>
            {
                return new List<AssertedLocation>
                {
                    new AssertedLocation
                    {
                        Point = new LocationPoint(f.Address.Latitude(),
                            f.Address.Longitude())
                    }
                };
            })
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
