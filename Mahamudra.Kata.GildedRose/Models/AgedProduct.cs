using Mahamudra.Kata.GildedRose.Interfaces;

namespace Mahamudra.Kata.GildedRose.Models;

public class AgedProduct : ProductBase
{
    public AgedProduct(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {
    }

    public override void PassingOfTime(int days)
    {
        for (var i = 1; i <= days; i++)
        {
            if (Quality < 50)
                Quality++;
            SellIn--;
        }
    }
}