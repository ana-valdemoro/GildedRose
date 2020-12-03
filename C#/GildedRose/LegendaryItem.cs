namespace GildedRose {
    public class LegendaryItem : BaseItem {
        
        public LegendaryItem(): base( "Sulfuras, Hand of Ragnaros", 80, 0) { }

        protected internal override void UpdateState() {
            //Do nothing because Legendary Items do not change their properties
        }
    }
}
