using Mahamudra.Kata.GildedRose.Interfaces;
using Mahamudra.Kata.GildedRose.Models;

namespace Mahamudra.Kata.GildedRose.Extensions;

public static class ProductExtensions
{
    public static ProductBase Map(this Item? item)
    { 
        ProductBase product;
        if (item!.Name!.Contains("Aged Brie"))
            product = new AgedProduct(item.Name, item.SellIn, item.Quality);
        else if (item.Name.Contains("Sulfuras"))
            product = new LegendaryProduct(item.Name, item.SellIn, item.Quality);
        else if (item.Name.Contains("Backstage"))
            product = new BackstageProduct(item.Name, item.SellIn, item.Quality);
        else if (item.Name.Contains("Conjured"))
            product = new ConjuredProduct(item.Name, item.SellIn, item.Quality);
        else
            product = new GenericProduct(item.Name, item.SellIn, item.Quality);
        return product;
    }
}