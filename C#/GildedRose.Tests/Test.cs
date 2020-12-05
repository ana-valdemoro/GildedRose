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
            Item legendaryItem = new Item() { Name = Constants.Sulfuras }; 
            IList<Item> initialList = new List<Item>();
            initialList.Add(legendaryItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();

            var expectedLegendaryItem = gildedRose.Items.First(baseItem => baseItem.Name == Constants.Sulfuras);
            expectedLegendaryItem.Quality.Should().Be(Constants.SulfurasQuality);
            expectedLegendaryItem.SellIn.Should().Be(Constants.SulfurasSellIn);

        }

        [Test]
        public void Check_UpdateQuality_For_Ordinary_Item() {
            Item ordinaryItem = new Item() {Name = "Cheetos", Quality = 35 , SellIn = 2 };
            List<Item> baseList = new List<Item>();
            baseList.Add(ordinaryItem);
            GildedRose gildedRose = new GildedRose(baseList);

            gildedRose.UpdateItems();

            var expectedItem = gildedRose.Items.First(baseItem => baseItem.Name == "Cheetos");
            expectedItem.Quality.Should().Be(34);
            expectedItem.SellIn.Should().Be(1);

        }
        [Test]
        public void Check_UpdateQuality_For_Ordinary_Item_When_SellIn_Property_Is_0() {
            Item ordinaryItem = new Item() { Name = "Cheetos", Quality = 35, SellIn = 0 };
            List<Item> baseList = new List<Item>();
            baseList.Add(ordinaryItem);
            GildedRose gildedRose = new GildedRose(baseList);

            gildedRose.UpdateItems();

            var expectedItem = gildedRose.Items.First(baseItem => baseItem.Name == "Cheetos");
            expectedItem.Quality.Should().Be(33);
            expectedItem.SellIn.Should().Be(-1);

        }
        [Test]
        public void Check_UpdateQuality_For_Aged_Item()
        {
            Item agedItem = new Item(){Name = Constants.AgedBrie, Quality = 35, SellIn = 3};
            List<Item> initialList = new List<Item>();
            initialList.Add(agedItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();

            var expectedAgedItem = gildedRose.Items.First(item => item.Name == Constants.AgedBrie);
            expectedAgedItem.Quality.Should().Be(36);
            expectedAgedItem.SellIn.Should().Be(2);
        }
        [Test]
        public void Check_UpdateQuality_For_Aged_Item_When_Quality_has_Maximum_Value()
        {
            Item agedItem = new Item() { Name = Constants.AgedBrie, Quality = Constants.MaximumQuality, SellIn = 3 };
            List<Item> initialList = new List<Item>();
            initialList.Add(agedItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();

            var expectedAgedItem = gildedRose.Items.First(item => item.Name == Constants.AgedBrie);
            expectedAgedItem.Quality.Should().Be(Constants.MaximumQuality);
            expectedAgedItem.SellIn.Should().Be(2);
        }

        [Test]
        public void Check_UpdateQuality_For_Aged_Item_When_SellIn_Property_Is_0()
        {
            Item agedItem = new Item() { Name = Constants.AgedBrie, Quality = 35, SellIn = 0 };
            List<Item> initialList = new List<Item>();
            initialList.Add(agedItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();

            var expectedAgedItem = gildedRose.Items.First(item => item.Name == Constants.AgedBrie);
            expectedAgedItem.Quality.Should().Be(37);
            expectedAgedItem.SellIn.Should().Be(-1);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes()
        {
            Item backstagePasessItem = new Item(){Name = Constants.BactagePasses, Quality = 35, SellIn = 12};
            List<Item> initialList = new List<Item>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();

            var expectedBackstagePassesItem = gildedRose.Items.First(item => item.Name == Constants.BactagePasses);
            expectedBackstagePassesItem.Quality.Should().Be(36);
            expectedBackstagePassesItem.SellIn.Should().Be(11);

        }
       [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_Less_Than_10_days()
        {
            Item backstagePasessItem = new Item() { Name = Constants.BactagePasses, Quality = 35, SellIn = 10 };
            List<Item> initialList = new List<Item>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();

            var expectedBackstagePassesItem = gildedRose.Items.First(item => item.Name == Constants.BactagePasses);
            expectedBackstagePassesItem.Quality.Should().Be(37);
            expectedBackstagePassesItem.SellIn.Should().Be(9);

        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_Less_Than_5_days() {
            Item backstagePasessItem = new Item() { Name = Constants.BactagePasses, Quality = 35, SellIn = 5 };
            List<Item> initialList = new List<Item>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();

            var expectedBackstagePassesItem = gildedRose.Items.First(item => item.Name == Constants.BactagePasses);
            expectedBackstagePassesItem.Quality.Should().Be(38);
            expectedBackstagePassesItem.SellIn.Should().Be(4);


        }
        [Test]
        public void Check_UpdateQuality_For_Backstage_Passes_When_SellIn_Property_Is_0() {
            Item backstagePasessItem = new Item() { Name = Constants.BactagePasses, Quality = 35, SellIn = 0 };
            List<Item> initialList = new List<Item>();
            initialList.Add(backstagePasessItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();

            var expectedBackstagePassesItem = gildedRose.Items.First(item => item.Name == Constants.BactagePasses);
            expectedBackstagePassesItem.Quality.Should().Be(0);
            expectedBackstagePassesItem.SellIn.Should().Be(-1);

        }

        /*[Test]
        public void Check_Creation_Legendary_Item() {
            Item legendaryItem = new Item(){Name = Constants.Sulfuras, Quality = 80, SellIn = 2};
            Item agedItem = new Item(){Name = Constants.AgedBrieName, Quality = 35,SellIn = 3 };
            Item backstage = new Item(35,0);
            IList<Item> basedList = new List<Item>();
            basedList.Add(legendaryItem);
            basedList.Add(agedItem);
            basedList.Add(backstage);
            GildedRose gildedRose = new GildedRose(basedList );

            gildedRose.UpdateItems();
            BaseItem expectedLegendaryItem = gildedRose.Items.First(item => item.Name == "Sulfuras, Hand of Ragnaros");
            expectedLegendaryItem.Quality.Should().Be(80);
            expectedLegendaryItem.SellIn.Should().Be(0);
            BaseItem expectedAgedItem = gildedRose.Items.First(item => item.Name == "Aged Brie");
            expectedAgedItem.Quality.Should().Be(36);
            expectedAgedItem.SellIn.Should().Be(2);
            BaseItem expectedBackstage = gildedRose.Items.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert");
            expectedBackstage.Quality.Should().Be(0);
            expectedBackstage.SellIn.Should().Be(-1);

        }
        */
        [Test]
        public void Check_UpdateItems_For_A_List_Of_Two_Items()
        {
            List<Item> initialList = new List<Item>();
            Item legendary = new Item() {Name = Constants.Sulfuras};
            Item ordinaryItem = new Item() { Name = "Cheetos", Quality = 35, SellIn = 0 };
            initialList.Add(legendary);
            initialList.Add(ordinaryItem);
            GildedRose gildedRose = new GildedRose(initialList);

            gildedRose.UpdateItems();
            var expectedLegendaryItem = gildedRose.Items.First(item => item.Name == "Sulfuras, Hand of Ragnaros");
            expectedLegendaryItem.Quality.Should().Be(80);
            expectedLegendaryItem.SellIn.Should().Be(0);
            var expectedOrdinaryItem = gildedRose.Items.First(item => item.Name == "Cheetos");
            expectedOrdinaryItem.Quality.Should().Be(33);
            expectedOrdinaryItem.SellIn.Should().Be(-1);


        }

    }
}

