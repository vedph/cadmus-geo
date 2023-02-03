using Cadmus.Core;
using Cadmus.Geo.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.Geo.Parts.Test;

public sealed class AssertedToponymsPartSeederTest
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
        Type t = typeof(AssertedToponymsPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.geo.asserted-toponyms", attr!.Tag);
    }

    [Fact]
    public void Seed_Ok()
    {
        AssertedToponymsPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart? part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        AssertedToponymsPart? p = part as AssertedToponymsPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p!);

        Assert.NotEmpty(p!.Toponyms);
    }
}
