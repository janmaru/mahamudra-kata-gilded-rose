using Mahamudra.Kata.GildedRose.Interfaces;

namespace Mahamudra.Kata.GildedRose.Models;

public class BackstageProduct : ProductBase
{
    public BackstageProduct(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {
    }

    public override void PassingOfTime(int days)
    {
        for (var i = 1; i <= days; i++)
        {
            switch (SellIn)
            {
                case > 10:
                    if (Quality + 1 < 50)
                        Quality++;
                    else if (Quality + 1 >= 50)
                        Quality = 50;
                    break;
                case int x when x > 5 || x <= 10:
                    if (Quality + 2 < 50)
                        Quality += 2;
                    else if (Quality + 2 >= 50)
                        Quality = 50;
                    break;
                case int x when x <= 5 || x > 0:
                    if (Quality + 3 < 50)
                        Quality += 3;
                    else if (Quality + 3 >= 50)
                        Quality = 50;
                    break;
                default:
                    Quality = 0;
                    break;
            }
            SellIn--;
        }
    }
}