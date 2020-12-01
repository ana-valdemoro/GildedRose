using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class LegendaryItem : BaseItem
    {
        
        public LegendaryItem(): base( "Sulfuras, Hand of Ragnaros", 80, 0) { }


        public override void UpdateItemProperties()
        {
            //Do nothing because Legendary Items do not change their properties
        }
    }
}
