namespace GildedRose {
    public class BackstagePasses: BaseItem {

        public const int DeadlineToDuplicateQuality = 10;
        public const int DeadlineToTriplicateQuality = 5;
        public BackstagePasses(int quality, int sellIn) : base("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) { }

        protected internal override void UpdateState() {
            UpdateSellIn();
            UpdateQuality();

        }

        private void UpdateQuality() {
            Quality = (SellIn < Deadline) ? MinimumQuality : Quality + QualityIncrease();
        }
        private int QualityIncrease() {
            if (SellIn <= DeadlineToTriplicateQuality && Quality + 3 <= MaximumQuality) return 3;
            if (SellIn <= DeadlineToDuplicateQuality && Quality + 2 <= MaximumQuality) return 2;
            return 1;

        }
    }
}
