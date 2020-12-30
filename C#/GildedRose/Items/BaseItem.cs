namespace GildedRose.Items {
    public abstract class BaseItem  {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }


        protected BaseItem(string name, int quality, int sellIn) {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        protected internal abstract void UpdateState();
        protected void UpdateSellIn() {
            SellIn--;
        }
    }
}
