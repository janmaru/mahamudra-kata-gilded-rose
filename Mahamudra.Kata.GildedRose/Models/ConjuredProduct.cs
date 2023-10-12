using Mahamudra.Kata.GildedRose.Interfaces;

namespace Mahamudra.Kata.GildedRose.Models;
public class ConjuredProduct : ProductBase
{
    public ConjuredProduct(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {
    }

    public override void PassingOfTime(int days)
    {
        for (var i = 1; i <= days; i++)
        {
            if (Quality - 2 >= 0)
                Quality -= 2;
            else
                Quality = 0;
            SellIn--;
        }
    }
}