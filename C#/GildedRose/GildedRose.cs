using System.Collections.Generic;
using System.Diagnostics;

namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items { get; set; }
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
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

        private void UpdateBackstagePasses(Item item)
        {
            IncreaseQualityValue(item);
            IncreasesQualityDaysBeforeConcert(item);
            DecreaseSellInProperty(item);
            if (item.SellIn < 0) item.Quality = 0;

        }

        private void UpdateAgedItem(Item item)
        {
            IncreaseQualityValue(item);
            DecreaseSellInProperty(item);
            if (item.SellIn < 0) IncreaseQualityValue(item);

        }

        private void UpdateOrdinaryItem(Item item)
        {
            DecreaseQualityValue(item);
            DecreaseSellInProperty(item);
            if (item.SellIn < 0) DecreaseQualityValue(item);
        }

        private static void DecreaseQualityValue(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
        private static void IncreaseQualityValue(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }


        private static void DecreaseSellInProperty(Item item)
        {
            item.SellIn--;
        }

        private static void IncreasesQualityDaysBeforeConcert(Item item)
        {
            if (item.SellIn < 11 && item.Quality < 50)
            {
                item.Quality++;
            }

            if (item.SellIn < 6 && item.Quality < 50)
            {
                item.Quality++;
            }

        }
    }
}
