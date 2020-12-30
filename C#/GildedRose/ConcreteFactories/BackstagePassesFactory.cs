using GildedRose.Items;

namespace GildedRose.ConcreteFactories {
    public class BackstagePassesFactory : ItemFactory {
        public override BaseItem CreateItem(Item item) {
            return new BackstagePasses(item.Name, item.Quality, item.SellIn);
        }
    }
}
