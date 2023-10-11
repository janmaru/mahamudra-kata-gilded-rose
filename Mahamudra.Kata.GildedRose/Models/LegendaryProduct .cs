using Mahamudra.Kata.GildedRose.Interfaces;

namespace Mahamudra.Kata.GildedRose.Models;

public class LegendaryProduct : StateBase
{
    public LegendaryProduct(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {
    }

    public override void PassingOfTime(int days)
    {
        for (var i = 1; i <= days; i++)
        {
            SellIn--;
        }
    }
}