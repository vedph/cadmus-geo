using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Configuration;

namespace Cadmus.Geo.Parts;

/// <summary>
/// A set of toponyms with their optional assertions.
/// <para>Tag: <c>it.vedph.geo.asserted-toponyms</c>.</para>
/// </summary>
[Tag("it.vedph.geo.asserted-toponyms")]
public sealed class AssertedToponymsPart : PartBase
{
    /// <summary>
    /// Gets or sets the toponyms.
    /// </summary>
    public List<AssertedToponym> Toponyms { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AssertedToponymsPart"/> class.
    /// </summary>
    public AssertedToponymsPart()
    {
        Toponyms = new List<AssertedToponym>();
    }

    /// <summary>
    /// Get all the key=value pairs (pins) exposed by the implementor.
    /// </summary>
    /// <param name="item">The optional item. The item with its parts
    /// can optionally be passed to this method for those parts requiring
    /// to access further data.</param>
    /// <returns>The pins: <c>tot-count</c> and a collection of pins with
    /// these keys: name.</returns>
    public override IEnumerable<DataPin> GetDataPins(IItem? item = null)
    {
        DataPinBuilder builder = new(DataPinHelper.DefaultFilter);

        builder.Set("tot", Toponyms?.Count ?? 0, false);

        if (Toponyms?.Count > 0)
        {
            foreach (AssertedToponym toponym in Toponyms)
            {
                builder.AddValue("name", toponym.Name.GetFullName(),
                    filter: true);
                if (!string.IsNullOrEmpty(toponym.Eid))
                    builder.AddValue("eid", toponym.Eid);
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
               "The total count of entries."),
            new DataPinDefinition(DataPinValueType.Integer,
               "name",
               "The name(s) in the topnyms set.",
               "Mf"),
            new DataPinDefinition(DataPinValueType.Integer,
               "eid",
               "The EID(s) in the topnyms set.",
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

        sb.Append("[AssertedToponyms]");

        if (Toponyms?.Count > 0)
        {
            sb.Append(' ');
            int n = 0;
            foreach (var entry in Toponyms)
            {
                if (++n > 3) break;
                if (n > 1) sb.Append("; ");
                sb.Append(entry);
            }
            if (Toponyms.Count > 3)
                sb.Append("...(").Append(Toponyms.Count).Append(')');
        }

        return sb.ToString();
    }
}
