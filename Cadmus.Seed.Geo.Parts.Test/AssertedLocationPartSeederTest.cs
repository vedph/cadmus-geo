using Bogus;
using Cadmus.Core;
using Cadmus.Geo.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Geo.Parts.Test;

public sealed class AssertedLocationPartSeederTest
{
    private static readonly PartSeederFactory _factory =
    TestHelper.GetFactory();
    private static readonly SeedOptions _seedOptions =
        _factory.GetSeedOptions();
    private static readonly IItem _item =
        _factory.GetItemSeeder().GetItem(1, "facet");

    [Fact]
    public void TypeHasTagAttribute()
    {
        Type t = typeof(AssertedLocationsPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.geo.asserted-locations", attr!.Tag);
    }

    [Fact]
    public void Seed_Ok()
    {
        AssertedLocationsPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart? part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        AssertedLocationsPart? p = part as AssertedLocationsPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p!);

        Assert.NotEmpty(p!.Locations);
    }
}
