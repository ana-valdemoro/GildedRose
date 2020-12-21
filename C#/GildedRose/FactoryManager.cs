using System;
using System.Collections.Generic;
using GildedRose.ConcreteFactories;

namespace GildedRose {
    public  class FactoryManager
    {

        private readonly Dictionary<string, Func<ItemFactory>> ItemCatalog;
        private readonly OrdinaryFactory ordinaryFactory;

        public FactoryManager()
        {
            AgedBrieFactory agedBrieFactory = new AgedBrieFactory();
            SulfurasFactory sulfurasFactory = new SulfurasFactory();
            BackstagePassesFactory backstagePassesFactory = new BackstagePassesFactory();
            ItemCatalog = new Dictionary<string, Func<ItemFactory>>
            {
                { "Aged Brie", () =>  agedBrieFactory } ,
                { "Sulfuras, Hand of Ragnaros", () => sulfurasFactory},
                { "Backstage passes to a TAFKAL80ETC concert", ()=> backstagePassesFactory},
            };
            ordinaryFactory = new OrdinaryFactory();
        }

        public void RequestItemUpdate(Item item) {
            if (!ItemCatalog.ContainsKey(item.Name))
            {
                ordinaryFactory.UpdateItem(item);
            }else
            {
                ItemCatalog[item.Name].Invoke().UpdateItem(item);
            }
        }
    }

}


