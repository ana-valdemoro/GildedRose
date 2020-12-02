namespace GildedRose {
    public abstract class BaseItem : Item {
      
        public BaseItem(string name, int quality, int sellIn) {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }


        public abstract void UpdateItemProperties();
        protected void UpdateSellInProperty() {
            SellIn--;
        }
    }
}
