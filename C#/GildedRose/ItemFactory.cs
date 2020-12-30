using GildedRose.Items;

namespace GildedRose {
    public abstract class ItemFactory
    {
        public void UpdateItem(Item item)
        {
            BaseItem baseItem = CreateItem(item); 
            baseItem.UpdateState();
            item.Quality = baseItem.Quality;
            item.SellIn = baseItem.SellIn;

        }
        public abstract BaseItem CreateItem(Item item);
    }
}
