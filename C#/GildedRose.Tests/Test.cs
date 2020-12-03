using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests {
    class Test {
        

        [Test]
        public void Item_Creation_Test()
        {
            Item item = new Item() { Name = "Peach", SellIn = 5, Quality = 12 };

            item.Name.Should().Be("Peach");
            item.SellIn.Should().Be(5);
            item.Quality.Should().Be(12);
        }


        [Test]
        public void Check_UpdateQuality_For_Legendary_Item() {
            LegendaryItem legendaryItem = new LegendaryItem();
            List<BaseItem> initialList = new List<BaseItem>();
            initialList.Add(legendaryItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedLegendaryItem = gildedRose.BaseItems.First(baseItem => baseItem.Name == "Sulfuras, Hand of Ragnaros");
            expectedLegendaryItem.Quality.Should().Be(80);
            expectedLegendaryItem.SellIn.Should().Be(0);

        }

        [Test]
        public void Check_UpdateQuality_For_Ordinary_Item() {
            OrdinaryItem ordinaryItem = new OrdinaryItem("Cheetos", 35, 2) ;
            List<BaseItem> baseList = new List<BaseItem>();
            baseList.Add(ordinaryItem);
            GildedRose gildedRose = new GildedRose(baseList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedItem = gildedRose.BaseItems.First(baseItem => baseItem.Name == "Cheetos");
            expectedItem.Quality.Should().Be(34);

        }
        [Test]
        public void Check_UpdateQuality_For_Ordinary_Item_When_SellIn_Property_Is_0() {
            OrdinaryItem ordinaryItem = new OrdinaryItem("Cheetos", 35, 2);
            List<BaseItem> initialList = new List<BaseItem>();
            initialList.Add(ordinaryItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedItem = gildedRose.BaseItems.First(item => item.Name == "Cheetos");
            expectedItem.Quality.Should().Be(34);
            expectedItem.SellIn.Should().Be(1);

        }
        [Test]
        public void Check_UpdateQuality_For_Aged_Item()
        {
            AgedBrie agedItem = new AgedBrie(35,3);
            List<BaseItem> initialList = new List<BaseItem>();
            initialList.Add(agedItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedAgedItem = gildedRose.BaseItems.First(item => item.Name == "Aged Brie");
            expectedAgedItem.Quality.Should().Be(36);
            expectedAgedItem.SellIn.Should().Be(2);

        }
        [Test]
        public void Check_UpdateQuality_For_Aged_Item_When_SellIn_Property_Is_0()
        {
            AgedBrie agedItem = new AgedBrie(35, 0);
            List<BaseItem> initialList = new List<BaseItem>();
            initialList.Add(agedItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedAgedItem = gildedRose.BaseItems.First(item => item.Name == "Aged Brie");
            expectedAgedItem.Quality.Should().Be(37);
            expectedAgedItem.SellIn.Should().Be(-1);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes()
        {
            BackstagePasses backstagePasessItem = new BackstagePasses(35, 12);
            List<BaseItem> initialList = new List<BaseItem>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedBackstagePassesItem = gildedRose.BaseItems.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstagePassesItem.Quality.Should().Be(36);
            expectedBackstagePassesItem.SellIn.Should().Be(11);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_Less_Than_10_days()
        {
            BackstagePasses backstagePasessItem = new BackstagePasses(35, 10);
            List<BaseItem> initialList = new List<BaseItem>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedBackstagePassesItem = gildedRose.BaseItems.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstagePassesItem.Quality.Should().Be(37);
            expectedBackstagePassesItem.SellIn.Should().Be(9);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_Less_Than_5_days() {
            BackstagePasses backstagePasessItem = new BackstagePasses(35, 5);
            List<BaseItem> initialList = new List<BaseItem>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedBackstagePassesItem = gildedRose.BaseItems.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstagePassesItem.Quality.Should().Be(38);
            expectedBackstagePassesItem.SellIn.Should().Be(4);


        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_0() {
            BackstagePasses backstagePasessItem = new BackstagePasses(35, 0);
            List<BaseItem> initialList = new List<BaseItem>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateBaseItems();

            BaseItem expectedBackstagePassesItem = gildedRose.BaseItems.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstagePassesItem.Quality.Should().Be(0);

        }

        [Test]
        public void Check_Creation_Legendary_Item() {
            LegendaryItem legendaryItem = new LegendaryItem();
            AgedBrie agedItem = new AgedBrie(35, 3);
            BackstagePasses backstage = new BackstagePasses(35,0);
            IList<BaseItem> basedList = new List<BaseItem>();
            basedList.Add(legendaryItem);
            basedList.Add(agedItem);
            basedList.Add(backstage);
            GildedRose gildedRose = new GildedRose(basedList );

            gildedRose.UpdateBaseItems();
            BaseItem expectedLegendaryItem = gildedRose.BaseItems.First(item => item.Name == "Sulfuras, Hand of Ragnaros");
            expectedLegendaryItem.Quality.Should().Be(80);
            expectedLegendaryItem.SellIn.Should().Be(0);
            BaseItem expectedAgedItem = gildedRose.BaseItems.First(item => item.Name == "Aged Brie");
            expectedAgedItem.Quality.Should().Be(36);
            expectedAgedItem.SellIn.Should().Be(2);
            BaseItem expectedBackstage = gildedRose.BaseItems.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstage.Quality.Should().Be(0);
            expectedBackstage.SellIn.Should().Be(-1);



        }

    }
}

