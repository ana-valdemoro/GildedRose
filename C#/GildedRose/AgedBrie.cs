using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class AgedBrie : BaseItem
    {
        public const int Deadline = 0;
        public const int MaximumQuality = 50;

        public AgedBrie(string name , int quality, int sellIn) : base(name,quality, sellIn){ }
        public void UpdateQualityProperty() {
           
            Quality += QualityValueIncrease();

        }

        public override void UpdateItemProperties()
        {
            UpdateSellInProperty();
            UpdateQualityProperty();

        }

        private int QualityValueIncrease() {
            if (SellIn < Deadline && Quality + 2 <= MaximumQuality) return 2;
            if (Quality + 1 <= MaximumQuality) return 1;
            return 0;

        }

    }
}
