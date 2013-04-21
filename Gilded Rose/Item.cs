
namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public void UpdateQuality()
        {
            switch (Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    break;
                case "Conjured Mana Cake":
                    UpdateConjuredQuality(this);
                    break;
                case "Aged Brie":
                    UpdateAgedBrieQuality(this);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePassesQuality(this);
                    break;
                default:
                    UpdateDefaultQuality(this);
                    break;
            }
        }

        public void UpdateSellInDate()
        {
            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn = SellIn - 1;
            }
        }

        #region Private Region

        #region Constants

        private const int MaximumItemQuality = 50;
        private const int MinimumItemQuality = 0;
        private const int SellInDateEnd = 0;

        #endregion

        #region Methods

        private static void UpdateDefaultQuality(Item item)
        {
            item.Quality = item.SellIn <= SellInDateEnd ? item.Quality - 2 : item.Quality - 1;
            if (item.Quality >= MinimumItemQuality) return;
            item.Quality = MinimumItemQuality;
        }

        private static void UpdateBackstagePassesQuality(Item item)
        {
            if (item.SellIn <= SellInDateEnd)
            {
                item.Quality = MinimumItemQuality;
                return;
            }

            if (item.SellIn <= 5)
            {
                item.Quality = item.Quality + 3;
            }
            else if (item.SellIn <= 10)
            {
                item.Quality = item.Quality + 2;
            }
            else
            {
                item.Quality = item.Quality + 1;
            }

            if (item.Quality <= MaximumItemQuality) return;
            item.Quality = MaximumItemQuality;

        }

        private static void UpdateAgedBrieQuality(Item item)
        {
            item.Quality = item.SellIn <= SellInDateEnd ? item.Quality + 2 : item.Quality + 1;
            if (item.Quality <= MaximumItemQuality) return;
            item.Quality = MaximumItemQuality;
        }

        private static void UpdateConjuredQuality(Item item)
        {
            item.Quality = item.SellIn <= SellInDateEnd ? item.Quality - 4 : item.Quality - 2;
            if (item.Quality >= MinimumItemQuality) return;
            item.Quality = MinimumItemQuality;
        }

        #endregion

        #endregion
    }
}
