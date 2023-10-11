Gilded Rose
===
 
The "Gilded Rose" is a well-known [coding kata][1] originally conceived by [Terry Hughes][0] that is used to practice refactoring and improving the maintainability of code.

"Gilded" means being coated with a thin layer of gold. So it's something made looking more valuable than it is.

The term would humorously suggest that all the items in the store are artificially enhanced, even though the underlying code for managing those items might be overly convoluted. 

So "gilding" your code is a way to learn (kata) more about your domain while making improvements in the code.

### Overview

The goal of the original kata was to work through a piece of legacy software lacking tests and written in a peculiar manner and with very
definitive constraints (both functional and political). 

---

#### Pre-requisites

To run this code you need:

+ A version of the .NET SDK capable of supporting, at least, C# 9.0 _and_ F# 5.0 (for details, see [official docs][2]).
+ Optionally, a text-editor or IDE which is capability of editing and compiling C# and/or F#.

---

#### Repository structure

To help make things a bit more manageable, each branch in this repo represents a specific step in the overall journey.

 Projects                     | | Summary
------------------------------|-|----------------------------------------------------------------------------
 `Mahamudra.Kata.GildedRose`  | | Project (in C#) console application, i.e. the start of the kata.
 ``                           | | Project (in F#): approval tests and property-based tests.
 

The first time you work with the repository you'll likely need to run: 

` > dotnet tool restore && dotnet paket restore`.

Subsequent to that, you can use the editor or IDE of your choice. But the following CLI commands might be useful (note,
they all assume you are in the root folder of the repository... where the `GrowingGildedRose.sln` file lives):

+ Build all the projects: `> dotnet build`
+ Run the whole test suite: `> dotnet test`
+ Run just the main executable: `> dotnet run -p source/Mahamudra.Kata.GildedRose`

---

#### Problem Statement

This is taken directly from the [original kata][1].

> Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a prominent city ran by a
> friendly innkeeper named Allison. We also buy and sell only the finest goods. Unfortunately, our goods are constantly
> degrading in quality as they approach their sell by date. We have a system in place that updates our inventory for us.
> It was developed by a no-nonsense type named Leeroy, who has moved on to new adventures. Your task is to add the new
> feature to our system so that we can begin selling a new category of items. First an introduction to our system:
> 
> - All items have a SellIn value which denotes the number of days we have to sell the item
> - All items have a Quality value which denotes how valuable the item is
> - At the end of each day our system lowers both values for every item
> 
> Pretty simple, right? Well this is where it gets interesting:
> 
> - Once the sell by date has passed, Quality degrades twice as fast
> - The Quality of an item is never negative
> - "Aged Brie" actually increases in Quality the older it gets
> - The Quality of an item is never more than 50
> - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
> - "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 
>   when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
> 
> We have recently signed a supplier of conjured items. This requires an update to our system:
> 
> - "Conjured" items degrade in Quality twice as fast as normal items
> 
> Feel free to make any changes to the UpdateQuality method and add any new code as long as everything still works
> correctly. However, do not alter the Item class or Items property as those belong to the goblin in the corner who will
> insta-rage and one-shot you as he doesn't believe in shared code ownership (you can make the UpdateQuality method and
> Items property static if you like, we'll cover for you).
> 
> Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a legendary item 
> and as such its Quality is 80 and it never alters.

[0]: https://twitter.com/TerryHughes
[1]: https://github.com/NotMyself/GildedRose
[2]: https://dotnet.microsoft.com/download