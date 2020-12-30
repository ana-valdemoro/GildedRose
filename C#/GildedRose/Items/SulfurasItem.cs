namespace GildedRose.Items {
    public class SulfurasItem : BaseItem {
        
        public SulfurasItem(): base( Constants.Sulfuras, Constants.SulfurasQuality, Constants.SulfurasSellIn) { }

        protected internal override void UpdateState() {
            //Do nothing because Legendary Items do not change their properties
        }
    }
}
