using System.Collections.Generic;

namespace GildedRose {
    public class ItemFactory {
        private Dictionary<string, BaseItem> itemCatalog= new Dictionary<string, BaseItem>();
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string BRIE = "Aged Brie";
        public const string BACKSTAGE_PASSES_ITEM = "Backstage passes to a TAFKAL80ETC concert";
        public const string CONJURED_ITEM = "Conjured";

        public ItemFactory(Item item) {
            itemCatalog.Add(SULFURAS, new Sulfuras());
            itemCatalog.Add(BRIE, new AgedBrie(item.Quality,item.SellIn));
            itemCatalog.Add(BACKSTAGE_PASSES_ITEM, new BackstagePasses(item.Quality, item.SellIn));
        }
        public BaseItem CreateItem(Item item)
        {
            if (itemCatalog.TryGetValue(item.Name, out var baseItem))
            {
                return baseItem;
            }
            return new OrdinaryItem(item.Name, item.Quality, item.SellIn);
        }

    }
}
