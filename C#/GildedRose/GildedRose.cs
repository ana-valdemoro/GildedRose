using System.Collections.Generic;
using System.Diagnostics;

namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items { get; set; }
        public IList<BaseItem> BaseItems { get; set; }
        public const int MinimumQuality = 0;
        public const int MaximumQuality = 50;
        public const int Deadline = 0;
        public const int DeadlineToDuplicateQuality = 10;
        public const int DeadlineToTriplicateQuality = 5;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public GildedRose(IList<BaseItem> Items)
        {
            this.BaseItems = Items;
        }

        public void UpdateItemsProperty()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Aged Brie":
                        UpdateAgedItem(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePasses(item);
                        break;
                    default:
                        UpdateOrdinaryItem(item);
                        break;
                }
            }

           

        }

        public void UpdateBaseItems()
        {
            foreach (var baseItem in BaseItems)
            {
                baseItem.UpdateItemProperties();
            }
        }

        private void UpdateBackstagePasses(Item item)
        {
            DecreaseSellInProperty(item);  
            item.Quality = (item.SellIn < Deadline) ? MinimumQuality : item.Quality + QualityIncreaseForBackstagePasses(item);
        }

        private void UpdateAgedItem(Item item)
        {
            DecreaseSellInProperty(item);
            item.Quality += QualityValueIncrease(item);

        }

        private void UpdateOrdinaryItem(Item item)
        {
            DecreaseSellInProperty(item);
            item.Quality -= QualityValueDecrease(item);
        }

        private static int QualityValueDecrease(Item item)
        {
            if (item.SellIn < Deadline && item.Quality -2 >= MinimumQuality) return 2;
            if (item.Quality - 1 >= MinimumQuality) return 1;
            return 0;
        }
        private static int QualityValueIncrease(Item item)
        {
            if (item.SellIn < Deadline && item.Quality + 2 <= MaximumQuality) return 2;
            if (item.Quality + 1 <= MaximumQuality) return 1;
            return 0;

        }


        private static void DecreaseSellInProperty(Item item)
        {
            item.SellIn--;
        }

        private static int QualityIncreaseForBackstagePasses(Item item)
        {
            if (item.SellIn <= DeadlineToTriplicateQuality && item.Quality + 3 <= MaximumQuality) return 3;
            if (item.SellIn <= DeadlineToDuplicateQuality && item.Quality + 2 <= MaximumQuality) return 2;
            return 1;

        }
    }

   
}
    

