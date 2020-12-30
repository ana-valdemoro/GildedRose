namespace GildedRose.Items {
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
            if (SellIn < Constants.Deadline && Quality - 2 >= Constants.MinimumQuality) return 2;
            return Quality - 1 >= Constants.MinimumQuality ? 1 : 0;
        }
    }
}
