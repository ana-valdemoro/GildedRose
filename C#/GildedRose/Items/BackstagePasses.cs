namespace GildedRose {
    public class BackstagePasses: BaseItem {
        public BackstagePasses(string name, int quality, int sellIn) : base(name, quality, sellIn) { }

        protected internal override void UpdateState() {
            UpdateSellIn();
            UpdateQuality();

        }

        private void UpdateQuality() {
            Quality = (SellIn < Constants.Deadline) ? Constants.MinimumQuality : Quality + QualityIncrease();
        }
        private int QualityIncrease() {
            if (SellIn <= Constants.DeadlineToTriplicateQuality && Quality + 3 <= Constants.MaximumQuality) return 3;
            if (SellIn <= Constants.DeadlineToDuplicateQuality && Quality + 2 <= Constants.MaximumQuality) return 2;
            return 1;

        }
    }
}
