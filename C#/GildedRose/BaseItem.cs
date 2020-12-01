using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public abstract class BaseItem : Item
    {
        public BaseItem(string Name, int Quality, int SellIn)
        {
            base.Name = Name;
            base.Quality = Quality;
            base.SellIn = SellIn;
        }



        public abstract void UpdateItemProperties();
        protected void UpdateSellInProperty() {
            SellIn--;
        }
    }
}
