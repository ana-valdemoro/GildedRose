namespace GildedRose {
    public static class ItemFactory {

        public static BaseItem CreateItem(Item item) {
            switch (item.Name)
            {
                case Constants.Sulfuras: 
                    return new SulfurasItem();
                case Constants.AgedBrie: 
                    return new AgedBrie(Constants.AgedBrie, item.Quality, item.SellIn);
                case Constants.BactagePasses:
                    return new BackstagePasses(Constants.BactagePasses, item.Quality, item.SellIn);
                default:
                    return new OrdinaryItem(item.Name, item.Quality, item.SellIn);
            }

        }

    }

}
