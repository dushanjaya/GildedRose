﻿using System.Collections.Generic;

namespace GildedRose
{
    /* 
    Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a prominent
    city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods. Unfortunately,
    our goods are constantly degrading in quality as they approach their sell by date. 
    We have a system in place that updates our inventory for us. 
    It was developed by a no-nonsense type named Leeroy, who has moved on to new adventures.
    Your task is to add the new feature to our system so that we can begin selling a new category of items.
    First an introduction to our system:

        - All items have a SellIn value which denotes the number of days we have to sell the item
        - All items have a Quality value which denotes how valuable the item is
        - At the end of each day our system lowers both values for every item

    Pretty simple, right? Well this is where it gets interesting:

        - Once the sell by date has passed, Quality degrades twice as fast
        - The Quality of an item is never negative
        - "Aged Brie" actually increases in Quality the older it gets
        - The Quality of an item is never more than 50
        - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        - "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; 
            Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
            but Quality drops to 0 after the concert

    We have recently signed a supplier of conjured items. This requires an update to our system:

        - "Conjured" items degrade in Quality twice as fast as normal items

    Feel free to make any changes to the UpdateQuality method and add any new code as long as everything 
    still works correctly. However, do not alter the Item class or Items property as those belong to
    the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code
    ownership (you can make the UpdateQuality method and Items property static if you like, we'll cover for you).
    Your work needs to be completed by Friday, February 18, 2011 08:00:00 AM PST.

    Just for clarification, an item can never have its Quality increase above 50,
    however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
    */
    public class GildedRoseApp
    {
        #region Public Region

        public void UpdateQuality()
        {
            foreach (var item in AvailableItems)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Conjured Mana Cake":
                        UpdateConjuredQuality(item);
                        break;
                    case "Aged Brie":
                        UpdateAgedBrieQuality(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePassesQuality(item);
                        break;
                    default:
                        UpdateDefaultQuality(item);
                        break;
                }
                item.SellIn = item.SellIn - 1;
            }
        }

        public IList<Item> AvailableItems = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };

        #endregion

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
