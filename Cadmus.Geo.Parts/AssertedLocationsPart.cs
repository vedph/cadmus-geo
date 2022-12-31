﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.Geo.Parts;

/// <summary>
/// A set of <see cref="AssertedLocation"/>'s.
/// <para>Tag: <c>it.vedph.geo.asserted-locations</c>.</para>
/// </summary>
[Tag("it.vedph.geo.asserted-locations")]
public sealed class AssertedLocationsPart : PartBase
{
    /// <summary>
    /// Gets or sets the entries.
    /// </summary>
    public List<AssertedLocation> Locations { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AssertedLocationsPart"/> class.
    /// </summary>
    public AssertedLocationsPart()
    {
        Locations = new List<AssertedLocation>();
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins with
    /// these keys: ....</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new();

        builder.Set("tot", Locations?.Count ?? 0, false);

        if (Locations?.Count > 0)
        {
            int n = 0;
            foreach (LocationPoint point in Locations.Select(l => l.Point))
            {
                n++;
                builder.AddValue($"lat{n}", point.Lat);
                builder.AddValue($"lon{n}", point.Lon);
            }
        }

        return builder.Build(this);
    }

    /// <summary>
    /// Gets the definitions of data pins used by the implementor.
    /// </summary>
    /// <returns>Data pins definitions.</returns>
    public override IList<DataPinDefinition> GetDataPinDefinitions()
    {
        return new List<DataPinDefinition>(new[]
        {
            new DataPinDefinition(DataPinValueType.Integer,
               "tot-count",
               "The total count of locations."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "lat<N>",
                "The latitude of the N-th location in set."),
            new DataPinDefinition(DataPinValueType.Decimal,
                "lon<N>",
                "The longitude of the N-th location in set.",
                "M")
        });
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

        sb.Append("[AssertedLocations]");

        if (Locations?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Locations)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Locations.Count > 3)
                sb.Append("...(").Append(Locations.Count).Append(')');
        }

        return sb.ToString();
    }
}