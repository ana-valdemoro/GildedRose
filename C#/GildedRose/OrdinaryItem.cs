namespace GildedRose {
    public class OrdinaryItem: BaseItem {

        public const int Deadline = 0;
        public const int MinimumQuality = 0;

        public OrdinaryItem(string name, int quality, int sellIn) : base(name, quality, sellIn) { }

        public override void UpdateItemProperties() {
            UpdateSellInProperty();
            UpdateQualityProperty();

        }

        private void UpdateQualityProperty() {
            Quality -= QualityDecrease();
        }
        private int QualityDecrease() {
            if (SellIn < Deadline && Quality - 2 >= MinimumQuality) return 2;
            return Quality - 1 >= MinimumQuality ? 1 : 0;
        }
    }
}
