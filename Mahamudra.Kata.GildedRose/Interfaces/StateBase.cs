namespace Mahamudra.Kata.GildedRose.Interfaces;
public abstract class StateBase
{
    public abstract void PassingOfTime(int days);
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
    public StateBase(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }
}