namespace GildedRose {
    public abstract class BaseItem  {
        public string Name { get; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public const int Deadline = 0;
        public const int MinimumQuality = 0;
        public const int MaximumQuality = 50;

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
