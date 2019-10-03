using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        // store handlers for special cases
        private readonly Dictionary<string, Action<Item>> _handlers = new Dictionary<string, Action<Item>>();

        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            // add handler for Aged Brie
            _handlers.Add("Aged Brie", item =>
            {
                    item.Quality++;

                    if (item.SellIn < 1)
                    {
                        item.Quality++;
                    }
                    // if quality is more than 50 then 50, we don't allow more than 50
                    item.Quality = item.Quality > 50 ? 50 : item.Quality;
            });
            _handlers.Add("Sulfuras, Hand of Ragnaros", item =>
            {
                // nothing should change, so add a day which will be reduced in general handing
                item.SellIn++;
            });
            _handlers.Add("Backstage passes to a TAFKAL80ETC concert", item =>
            {
                if (item.SellIn < 1)
                {
                    item.Quality = 0;
                }
                else
                {
                    item.Quality++;
                    if (item.SellIn <= 10)
                    {
                        item.Quality++;
                    }
                    if (item.SellIn <= 5)
                    {
                        item.Quality++;
                    }
                    // if quality is more than 50 then 50, we don't allow more than 50
                    item.Quality = item.Quality > 50 ? 50 : item.Quality;

                }
            });
            _handlers.Add("Conjured Mana Cake", item =>
            {
                // just run default handler twice
                DefaultHandler(item);
                DefaultHandler(item);
            });
        }

        public void UpdateQuality()
        {
            // cycle through all the items and handle them
            foreach (var item in Items)
            {
                // if there's special handler - use it
                if (_handlers.ContainsKey(item.Name))
                {
                    _handlers[item.Name].Invoke(item);
                }
                // otherwise use default
                else
                {
                    DefaultHandler(item);
                }
                // reduce sellin day
                item.SellIn--;
            }
        }
        // handler for all non-special cases
        private void DefaultHandler(Item item)
        {
            item.Quality -= item.SellIn > 0 ? 1 : 2;
            item.Quality = item.Quality < 0 ? 0 : item.Quality;
        }

        /*
        public void UpdateQualityOld()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }*/

    }
}