using System.Collections.Generic;
using System.Diagnostics;

namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items { get; set; }
        
        public GildedRose(IList<Item> Items) {
            this.Items = Items;
        }
       

        public void UpdateItems() {
            foreach (var item in Items)
            {
                var baseItem = getBaseItem(item);
                baseItem.UpdateState();
                item.Quality = baseItem.Quality;
                item.SellIn = baseItem.SellIn;
            }

        }

        private BaseItem getBaseItem(Item item)
        {
            return new ItemFactory(item).CreateItem(item);
        }


    }

   
}
    

