using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.ConcreteFactories
{
    public class OrdinaryFactory
    {
        public  BaseItem CreateItem(Item item)
        {
            return new OrdinaryItem(item.Name, item.Quality, item.SellIn);
        }
    }
}
