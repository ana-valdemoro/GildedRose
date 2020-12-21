using System.Collections.Generic;
using System.Diagnostics;
using GildedRose.ConcreteFactories;

namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items { get; set; }
        private FactoryManager FactoryManager { get; set; }

        public GildedRose(IList<Item> items) {
            Items = items;
            FactoryManager = new FactoryManager();
        }

        public void UpdateItems() {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }

        }

        private void UpdateItem(Item item) { 
           FactoryManager.RequestItemUpdate(item);
        }


    }

}
    

