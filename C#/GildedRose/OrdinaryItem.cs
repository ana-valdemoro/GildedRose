namespace GildedRose {
    public class OrdinaryItem: BaseItem {

        public OrdinaryItem(string name, int quality, int sellIn) : base(name, quality, sellIn) { }

        protected internal override void UpdateState() {
            UpdateSellIn();
            UpdateQuality();

        }

        private void UpdateQuality() {
            Quality -= QualityDecrease();
        }
        private int QualityDecrease() {
            if (SellIn < Deadline && Quality - 2 >= MinimumQuality) return 2;
            return Quality - 1 >= MinimumQuality ? 1 : 0;
        }
    }
}
