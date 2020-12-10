namespace GildedRose.ConcreteFactories
{
    public class SulfurasFactory 
    {
        public BaseItem CreateItem(Item item)
        {
            return new SulfurasItem();
        }
    }
}
