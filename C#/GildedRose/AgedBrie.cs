namespace GildedRose {
    public class AgedBrie : BaseItem {
        public AgedBrie(string name, int quality, int sellIn) : base(name, quality, sellIn){ }

        protected internal override void UpdateState() {
            UpdateSellIn();
            UpdateQuality();

        }
        private void UpdateQuality() {
            Quality += QualityIncrease();

        }

        private int QualityIncrease() {
            if (SellIn < Constants.Deadline && Quality + 2 <= Constants.MaximumQuality) return 2;
            return Quality + 1 <= Constants.MaximumQuality ? 1 : 0;
        }

    }
}
