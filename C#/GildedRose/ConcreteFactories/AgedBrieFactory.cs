using GildedRose.Items;

namespace GildedRose.ConcreteFactories
{
    public class AgedBrieFactory : ItemFactory
    {
        public override BaseItem CreateItem(Item item)
        {
            return new AgedBrie(item.Name, item.Quality, item.SellIn);
        }
    }
}
