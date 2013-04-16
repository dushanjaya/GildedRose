using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTest
{
    // Unit test has been written to test the behavior of each and every available item in the shop
    public class GildedRoseTest
    {
        [TestCase(3)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(51)]
        public void QuilityAndSellInDateOfSulfurasNeverChange(int numberOfDaysAfter)
        {
            var app = new GildedRoseApp();
            for (var day = 1; day <= numberOfDaysAfter; day++)
            {
                app.UpdateQuality();
            }
            var item = app.AvailableItems.Single(x => x.Name == "Sulfuras, Hand of Ragnaros");
            item.Quality.Should().Be(80);
            item.SellIn.Should().Be(0);
        }

        [TestCase(3, 17, 7)]
        [TestCase(5, 15, 5)]
        [TestCase(10, 10, 0)]
        [TestCase(11, 8, -1)]
        [TestCase(14, 2, -4)]
        [TestCase(20, 0, -10)]
        [TestCase(51, 0, -41)]
        public void QuilityAndSellInDateOfDexterityVestAfterSpecificNumberOfDays(int numberOfDaysAfter, int expectedQuality, int expectedSellInDate)
        {
            var app = new GildedRoseApp();
            for (var day = 1; day <= numberOfDaysAfter; day++)
            {
                app.UpdateQuality();
            }
            var item = app.AvailableItems.Single(x => x.Name == "+5 Dexterity Vest");
            item.Quality.Should().Be(expectedQuality);
            item.SellIn.Should().Be(expectedSellInDate);
        }

        [TestCase(2, 2, 0)]
        [TestCase(7, 12, -5)]
        [TestCase(10, 18, -8)]
        [TestCase(20, 38, -18)]
        [TestCase(25, 48, -23)]
        [TestCase(61, 50, -59)]
        public void QuilityAndSellInDateOfAgedBrieAfterSpecificNumberOfDays(int numberOfDaysAfter, int expectedQuality, int expectedSellInDate)
        {
            var app = new GildedRoseApp();
            for (var day = 1; day <= numberOfDaysAfter; day++)
            {
                app.UpdateQuality();
            }
            var item = app.AvailableItems.Single(x => x.Name == "Aged Brie");
            item.Quality.Should().Be(expectedQuality);
            item.SellIn.Should().Be(expectedSellInDate);
        }

        [TestCase(3, 4, 2)]
        [TestCase(4, 3, 1)]
        [TestCase(5, 2, 0)]
        [TestCase(6, 0, -1)]
        [TestCase(10, 0, -5)]
        [TestCase(17, 0, -12)]
        public void QuilityAndSellInDateOfElixirAfterSpecificNumberOfDays(int numberOfDaysAfter, int expectedQuality, int expectedSellInDate)
        {
            var app = new GildedRoseApp();
            for (var day = 1; day <= numberOfDaysAfter; day++)
            {
                app.UpdateQuality();
            }
            var item = app.AvailableItems.Single(x => x.Name == "Elixir of the Mongoose");
            item.Quality.Should().Be(expectedQuality);
            item.SellIn.Should().Be(expectedSellInDate);
        }

        [TestCase(3, 23, 12)]
        [TestCase(5, 25, 10)]
        [TestCase(6, 27, 9)]
        [TestCase(10, 35, 5)]
        [TestCase(12, 41, 3)]
        [TestCase(14, 47, 1)]
        [TestCase(15, 50, 0)]
        [TestCase(16, 0, -1)]
        [TestCase(20, 0, -5)]
        public void QuilityAndSellInDateOfBackstagePassesAfterSpecificNumberOfDays(int numberOfDaysAfter, int expectedQuality, int expectedSellInDate)
        {
            var app = new GildedRoseApp();
            for (var day = 1; day <= numberOfDaysAfter; day++)
            {
                app.UpdateQuality();
            }
            var item = app.AvailableItems.Single(x => x.Name == "Backstage passes to a TAFKAL80ETC concert");
            item.Quality.Should().Be(expectedQuality);
            item.SellIn.Should().Be(expectedSellInDate);
        }

        [TestCase(1, 4, 2)]
        [TestCase(2, 2, 1)]
        [TestCase(3, 0, 0)]
        [TestCase(5, 0, -2)]
        [TestCase(10, 0, -7)]
        public void QuilityAndSellInDateOfConjuredAfterSpecificNumberOfDays(int numberOfDaysAfter, int expectedQuality, int expectedSellInDate)
        {
            var app = new GildedRoseApp();
            for (var day = 1; day <= numberOfDaysAfter; day++)
            {
                app.UpdateQuality();
            }
            var item = app.AvailableItems.Single(x => x.Name == "Conjured Mana Cake");
            item.Quality.Should().Be(expectedQuality);
            item.SellIn.Should().Be(expectedSellInDate);
        }
    }
}
