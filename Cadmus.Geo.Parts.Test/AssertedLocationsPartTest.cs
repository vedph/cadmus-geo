using Cadmus.Core;
using Cadmus.Seed.Geo.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Geo.Parts.Test;

public sealed class AssertedLocationsPartTest
{
    private static AssertedLocationsPart GetPart()
    {
        AssertedLocationsPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (AssertedLocationsPart)seeder.GetPart(item, null, null)!;
    }

    private static AssertedLocationsPart GetEmptyPart()
    {
        return new AssertedLocationsPart
        {
            ItemId = Guid.NewGuid().ToString(),
            RoleId = "some-role",
            CreatorId = "zeus",
            UserId = "another",
        };
    }

    [Fact]
    public void Part_Is_Serializable()
    {
        AssertedLocationsPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        AssertedLocationsPart part2 =
            TestHelper.DeserializePart<AssertedLocationsPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Locations.Count, part2.Locations.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        AssertedLocationsPart part = GetPart();
        part.Locations.Clear();

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Single(pins);
        DataPin pin = pins[0];
        Assert.Equal("tot-count", pin.Name);
        TestHelper.AssertPinIds(part, pin);
        Assert.Equal("0", pin.Value);
    }

    [Fact]
    public void GetDataPins_Entries_Ok()
    {
        AssertedLocationsPart part = GetEmptyPart();

        for (int n = 1; n <= 3; n++)
        {
            part.Locations.Add(new AssertedLocation
            {
                Value = new GeoLocation
                {
                    Latitude = n,
                    Longitude = n * 10
                }
            });
        }

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(6 + 1, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin!.Value);

        for (int n = 1; n <= 3; n++)
        {
            Assert.NotNull(pins.Find(
                p => p.Name == $"lat{n}" && p.Value == $"{n}"));
            Assert.NotNull(pins.Find(
                p => p.Name == $"lon{n}" && p.Value == $"{n * 10}"));
        }
    }
}
