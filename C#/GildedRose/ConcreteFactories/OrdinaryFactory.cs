
using GildedRose.Items;

namespace GildedRose.ConcreteFactories
{
    public class OrdinaryFactory: ItemFactory
    {
        public override BaseItem CreateItem(Item item)
        {
            return new OrdinaryItem(item.Name, item.Quality, item.SellIn);
        }
    }
}
