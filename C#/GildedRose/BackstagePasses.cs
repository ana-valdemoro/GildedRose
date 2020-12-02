using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class BackstagePasses: BaseItem
    {
        public const int Deadline = 0;
        public const int MinimumQuality = 0;
        public const int MaximumQuality = 50;
        public const int DeadlineToDuplicateQuality = 10;
        public const int DeadlineToTriplicateQuality = 5;
        public BackstagePasses(int quality, int sellIn) : base("Backstage passes to a TAFKAL80ETC concert", quality, sellIn) { }

        public override void UpdateItemProperties() {
            UpdateSellInProperty();
            UpdateQualityProperty();

        }

        private void UpdateQualityProperty() {
            Quality = (SellIn < Deadline) ? MinimumQuality : Quality + QualityIncrease();
        }
        private int QualityIncrease() {
            if (SellIn <= DeadlineToTriplicateQuality && Quality + 3 <= MaximumQuality) return 3;
            if (SellIn <= DeadlineToDuplicateQuality && Quality + 2 <= MaximumQuality) return 2;
            return 1;

        }
    }
}
