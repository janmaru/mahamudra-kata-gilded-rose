using Mahamudra.Kata.GildedRose.Interfaces;

namespace Mahamudra.Kata.GildedRose.Models;
public class GenericProduct : StateBase
{
    public GenericProduct(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {
    }

    public override void PassingOfTime(int days)
    {
        for (var i = 1; i <= days; i++)
        {
            if (Quality != 0)
            {
                if (SellIn < 0 && Quality - 2 >= 0)
                    Quality -= 2;
                else if (Quality > 0)
                    Quality--;
            }
            SellIn--;
        }
    }
}