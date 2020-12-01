using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    class Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Item_Creation_Test()
        {
            Item item = new Item() { Name = "Peach", SellIn = 5, Quality = 12 };

            item.Name.Should().Be("Peach");
            item.SellIn.Should().Be(5);
            item.Quality.Should().Be(12);
        }


        [Test]
        public void Check_UpdateQuality_For_Legendary_Item()
        {
            Item legendaryItem = new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(legendaryItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedLegendaryItem = gildedRose.Items.First(item => item.Name == "Sulfuras, Hand of Ragnaros");
            expectedLegendaryItem.Quality.Should().Be(80);

        }

        [Test]
        public void Check_UpdateQuality_For_Ordinary_Item()
        {
            Item ordinaryItem = new Item() { Name = "Cheetos", SellIn = 2, Quality = 35 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(ordinaryItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedItem = gildedRose.Items.First(item => item.Name == "Cheetos");
            expectedItem.Quality.Should().Be(34);

        }
        [Test]
        public void Check_UpdateQuality_For_Ordinary_Item_When_SellIn_Property_Is_0()
        {
            Item ordinaryItem = new Item() { Name = "Cheetos", SellIn = 0, Quality = 35 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(ordinaryItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedItem = gildedRose.Items.First(item => item.Name == "Cheetos");
            expectedItem.Quality.Should().Be(33);

        }
        [Test]
        public void Check_UpdateQuality_For_Aged_Item()
        {
            Item agedItem = new Item() { Name = "Aged Brie", SellIn = 3, Quality = 35 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(agedItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedAgedItem = gildedRose.Items.First(item => item.Name == "Aged Brie");
            expectedAgedItem.Quality.Should().Be(36);

        }
        [Test]
        public void Check_UpdateQuality_For_Aged_Item_When_SellIn_Property_Is_0()
        {
            Item agedItem = new Item() { Name = "Aged Brie", SellIn = 0, Quality = 35 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(agedItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedAgedItem = gildedRose.Items.First(item => item.Name == "Aged Brie");
            expectedAgedItem.Quality.Should().Be(37);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes()
        {
            Item backstagePasessItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 35 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedBackstagePassesItem = gildedRose.Items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstagePassesItem.Quality.Should().Be(36);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_Less_Than_10_days()
        {
            Item backstagePasessItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 35 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedBackstagePassesItem = gildedRose.Items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstagePassesItem.Quality.Should().Be(37);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_Less_Than_5_days()
        {
            Item backstagePasessItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 35 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedBackstagePassesItem = gildedRose.Items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstagePassesItem.Quality.Should().Be(38);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_0()
        {
            Item backstagePasessItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 35 };
            IList<Item> initialList = new List<Item>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItemsProperty();

            Item expectedBackstagePassesItem = gildedRose.Items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstagePassesItem.Quality.Should().Be(0);

        }

        [Test]
        public void Check_Creation_Legendary_Item()
        {
            LegendaryItem legendaryItem = new LegendaryItem();
            //AgedBrie agedItem = new AgedBrie("Aged Brie", 35, 3);
            IList<BaseItem> basedList = new List<BaseItem>();
            basedList.Add(legendaryItem);
           // basedList.Add(agedItem);
            GildedRose gildedRose = new GildedRose(basedList );

            gildedRose.UpdateBaseItems();
            Item expectedLegendaryItem = gildedRose.Items.First(item => item.Name == "Sulfuras, Hand of Ragnaros");
            expectedLegendaryItem.Quality.Should().Be(80);
        }

    }
}

