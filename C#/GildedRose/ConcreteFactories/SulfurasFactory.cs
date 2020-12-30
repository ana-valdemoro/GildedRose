using GildedRose.Items;

namespace GildedRose.ConcreteFactories
{
    public class SulfurasFactory : ItemFactory
    {
        public override BaseItem CreateItem(Item item)
        {
            return new SulfurasItem();
        }
    }
}
