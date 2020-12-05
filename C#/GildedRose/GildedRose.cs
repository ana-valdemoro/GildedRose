using System.Collections.Generic;
using System.Diagnostics;
using GildedRose.ConcreteFactories;

namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items { get; set; }

        public GildedRose(IList<Item> items) {
            Items = items;

        }

        public void UpdateItems() {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }

        }

        private void UpdateItem(Item item)
        {
            var baseItem = ItemFactory.CreateItem(item);
            baseItem.UpdateState();
            item.Quality = baseItem.Quality;
            item.SellIn = baseItem.SellIn;
        }


    }

}
    

