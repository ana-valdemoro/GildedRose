using System;
using System.Collections.Generic;

namespace GildedRose {
    public  class ItemFactory {

        private Dictionary<string, Delegate> itemList = new Dictionary<string, Delegate>
        {
            { "Aged Brie",  new Func<Item, BaseItem>(CreteAgeBrie)} ,
            { "Sulfuras, Hand of Ragnaros",   new Func<BaseItem>(CreateSulfurasItem) },
            { "Backstage passes to a TAFKAL80ETC concert",  new Func<Item, BaseItem>(CreateBacktagePasses)},
        };

        private static BaseItem CreateSulfurasItem()
        {
            return new SulfurasItem();
        }

        private static BaseItem CreteAgeBrie(Item item)
        {
            return new AgedBrie(item.Name, item.Quality, item.SellIn);
        }

        private static BaseItem CreateBacktagePasses(Item item)
        {
            return new BackstagePasses(item.Name, item.Quality, item.SellIn);
        }
        public BaseItem CreateItem(Item item) {
            if (!itemList.ContainsKey(item.Name)) return new OrdinaryItem(item.Name, item.Quality, item.SellIn);
            if (item.Name == Constants.Sulfuras) return (BaseItem) itemList[item.Name].DynamicInvoke();
            return  (BaseItem) itemList[item.Name].DynamicInvoke(item);
        }
    }

}


