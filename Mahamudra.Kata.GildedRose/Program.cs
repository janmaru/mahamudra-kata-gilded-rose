﻿namespace Mahamudra.Kata.GildedRose; 
using Mahamudra.Kata.GildedRose.Extensions;
using Mahamudra.Kata.GildedRose.Interfaces;

using static System.Console; 

public class Program
{ 
    IList<Item>? Items;
    IList<ProductBase>? Products;
    #region private
    private void Print()
    {
        if (Products is null || !Products.Any()) return;
        foreach (var p in Products)
            System.Console.WriteLine($"Item {{ Name = {p.Name}" +
                      $", Quality = {p.Quality}" +
                      $", SellIn = {p.SellIn} }}");
        System.Console.WriteLine("Press <RETURN> to exit.");
    }
    #endregion 
    public void UpdateQuality(IList<Item>? items)
    {
        if (items is null || !items.Any()) return;

        Products = items.Select(x => x.Map()).ToList();
        for (var i = 0; i < Products.Count; i++)
            Products[i].PassingOfTime(1);
    }
    public static void Main()
    {
        WriteLine("OMGHAI!");   
        var app = new Program
        {
            Items = new List<Item>
                {
                    new (){ Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new (){ Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new (){ Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new (){ Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new ()
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                    new (){ Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                }
        }; 
        app.UpdateQuality(app.Items);
        app.Print();
        System.Console.ReadLine();
    }

    public void OriginalUpdateQuality(IList<Item>? items)
    {
        if (items is null) return;

        foreach (var t in items)
        {
            if (t.Name != "Aged Brie" && t.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (t.Quality > 0)
                {
                    if (t.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        t.Quality -= 1;
                    }
                }
            }
            else
            {
                if (t.Quality < 50)
                {
                    t.Quality += 1;

                    if (t.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (t.SellIn < 11)
                        {
                            if (t.Quality < 50)
                            {
                                t.Quality += 1;
                            }
                        }

                        if (t.SellIn < 6)
                        {
                            if (t.Quality < 50)
                            {
                                t.Quality += 1;
                            }
                        }
                    }
                }
            }

            if (t.Name != "Sulfuras, Hand of Ragnaros")
            {
                t.SellIn -= 1;
            }

            if (t.SellIn < 0)
            {
                if (t.Name != "Aged Brie")
                {
                    if (t.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (t.Quality > 0)
                        {
                            if (t.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                t.Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        t.Quality -= t.Quality;
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality += 1;
                    }
                }
            }
        }
    } 
} 