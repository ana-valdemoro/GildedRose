namespace GildedRose {
    public class AgedBrie : BaseItem {
        public AgedBrie(int quality, int sellIn) : base("Aged Brie", quality, sellIn){ }

        protected internal override void UpdateItemProperties() {
            UpdateSellInProperty();
            UpdateQualityProperty();

        }
        private void UpdateQualityProperty() {
            Quality += QualityIncrease();

        }

        private int QualityIncrease() {
            if (SellIn < Deadline && Quality + 2 <= MaximumQuality) return 2;
            return Quality + 1 <= MaximumQuality ? 1 : 0;
        }

    }
}
