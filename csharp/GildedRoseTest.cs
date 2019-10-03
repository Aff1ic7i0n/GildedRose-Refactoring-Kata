using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void TestAnyNormal()
        {
            var item = new Item { Name = "Whatever", SellIn = 10, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(9, item.SellIn);
            Assert.AreEqual(9, item.Quality);
        }

        [Test]
        public void TestNormalZeroQuality()
        {
            var item = new Item { Name = "Whatever", SellIn = 0, Quality = 0 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
        }
        [Test]
        public void TestNormalZeroQualityZeroSellin()
        {
            var item = new Item { Name = "Whatever", SellIn = 0, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(8, item.Quality);
        }
        [Test]
        public void TestNormalOverSold()
        {
            var item = new Item { Name = "Whatever", SellIn = -5, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(8, item.Quality);
        }

        [Test]
        public void TestBrie()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(11, item.Quality);
        }
        [Test]
        public void TestBrieOverSold()
        {
            var item = new Item { Name = "Aged Brie", SellIn = -5, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(12, item.Quality);
        }
        [Test]
        public void TestBrieQuality50()
        {
            var item = new Item { Name = "Aged Brie", SellIn = -5, Quality = 50 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(50, item.Quality);
        }
        [Test]
        public void TestTickets()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 30, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(11, item.Quality);
        }
        [Test]
        public void TestTickets10Days()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(12, item.Quality);
        }
        [Test]
        public void TestTickets5Days()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(13, item.Quality);
        }
        [Test]
        public void TestTicketsConcert()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
        }
        [Test]
        public void TestSulfuras()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(10, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }
        [Test]
        public void TestConjured()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(9, item.SellIn);
            Assert.AreEqual(8, item.Quality);
        }

        [Test]
        public void TestConjuredZero()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
        }
        [Test]
        public void TestConjuredOverSold()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = -5, Quality = 10 };
            GildedRose app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();
            Assert.AreEqual(6, item.Quality);
        }
    }
}
