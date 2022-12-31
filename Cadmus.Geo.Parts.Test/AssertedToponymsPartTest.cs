using Cadmus.Core;
using Cadmus.Refs.Bricks;
using Cadmus.Seed.Geo.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.Geo.Parts.Test
{
    public sealed class AssertedToponymsPartTest
    {
        private static AssertedToponymsPart GetPart()
        {
            AssertedToponymsPartSeeder seeder = new();
            IItem item = new Item
            {
                FacetId = "default",
                CreatorId = "zeus",
                UserId = "zeus",
                Description = "Test item",
                Title = "Test Item",
                SortKey = ""
            };
            return (AssertedToponymsPart)seeder.GetPart(item, null, null)!;
        }

        private static AssertedToponymsPart GetEmptyPart()
        {
            return new AssertedToponymsPart
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
            AssertedToponymsPart part = GetPart();

            string json = TestHelper.SerializePart(part);
            AssertedToponymsPart part2 =
                TestHelper.DeserializePart<AssertedToponymsPart>(json)!;

            Assert.Equal(part.Id, part2.Id);
            Assert.Equal(part.TypeId, part2.TypeId);
            Assert.Equal(part.ItemId, part2.ItemId);
            Assert.Equal(part.RoleId, part2.RoleId);
            Assert.Equal(part.CreatorId, part2.CreatorId);
            Assert.Equal(part.UserId, part2.UserId);

            Assert.Equal(part.Toponyms.Count, part2.Toponyms.Count);
        }

        [Fact]
        public void GetDataPins_NoEntries_Ok()
        {
            AssertedToponymsPart part = GetPart();
            part.Toponyms.Clear();

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
            AssertedToponymsPart part = GetEmptyPart();
            char c = 'a';
            for (int n = 1; n <= 3; n++)
            {
                part.Toponyms.Add(new AssertedToponym
                {
                    Eid = $"t{n}",
                    Name = new ProperName
                    {
                        Pieces= new List<ProperNamePiece>
                        {
                            new()
                            {
                                Type = "last",
                                Value = $"Do{c}"
                            }
                        }
                    }
                });
                c++;
            }

            List<DataPin> pins = part.GetDataPins(null).ToList();

            Assert.Equal(6 + 1, pins.Count);

            DataPin? pin = pins.Find(p => p.Name == "tot-count");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
            Assert.Equal("3", pin!.Value);

            c = 'a';
            for (int n = 1; n <= 3; n++)
            {
                Assert.NotNull(pins.Find(
                    p => p.Name == "eid" && p.Value == $"t{n}"));
                Assert.NotNull(pins.Find(
                    p => p.Name == "name" && p.Value == $"do{c}"));
                c++;
            }
        }
    }
}
