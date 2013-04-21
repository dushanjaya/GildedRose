
namespace GildedRose
{
    public class Item
    {
        #region Constants

        protected const int MaximumItemQuality = 50;
        protected const int MinimumItemQuality = 0;
        protected const int SellInDateEnd = 0;

        #endregion

        #region Public Region

        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual void UpdateQuality()
        {
            Quality = SellIn <= SellInDateEnd ? Quality - 2 : Quality - 1;
            if (Quality >= MinimumItemQuality) return;
            Quality = MinimumItemQuality;
        }

        public virtual void UpdateSellInDate()
        {
            SellIn = SellIn - 1;
        }

        #endregion
    }

    public class DexterityVestItem : Item
    {

    }

    public class AgedBrieItem : Item
    {
        public override void UpdateQuality()
        {
            Quality = SellIn <= SellInDateEnd ? Quality + 2 : Quality + 1;
            if (Quality <= MaximumItemQuality) return;
            Quality = MaximumItemQuality;
        }
    }

    public class ElixirItem : Item
    {

    }

    public class BackstagePassesItem : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= SellInDateEnd)
            {
                Quality = MinimumItemQuality;
                return;
            }

            if (SellIn <= 5)
            {
                Quality = Quality + 3;
            }
            else if (SellIn <= 10)
            {
                Quality = Quality + 2;
            }
            else
            {
                Quality = Quality + 1;
            }

            if (Quality <= MaximumItemQuality) return;
            Quality = MaximumItemQuality;
        }
    }

    public class SulfurasItem : Item
    {
        public override void UpdateSellInDate()
        {
        }

        public override void UpdateQuality()
        {
        }
    }

    public class ConjuredItem : Item
    {
        public override void UpdateQuality()
        {
            Quality = SellIn <= SellInDateEnd ? Quality - 4 : Quality - 2;
            if (Quality >= MinimumItemQuality) return;
            Quality = MinimumItemQuality;
        }
    }

}
