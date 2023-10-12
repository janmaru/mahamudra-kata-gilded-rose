namespace Mahamudra.Kata.GildedRose.Test 

open FsCheck.Xunit
open FsCheck
open Mahamudra.Kata.GildedRose

[<Properties(Arbitrary=[|typeof<ItemGenerator>|])>]
module UpdateQualityTests =

  let [<Literal>] EmptyItems = "The collection of items must have content; it should not be empty."

  let print (item, item') =
    let dump prefix (it : Item) =
      $"{prefix}: {it.Name}, {it.SellIn} days, {it.Quality}"

    $"{dump (nameof item) item}{System.Environment.NewLine}{dump (nameof item') item'}"

  [<Property>]
  let ``after +total days, any item has 0 <= quality <= 50``
    (item : Item)
    (PositiveInt totalDays)
    =
    (item.Name <> ItemName.Sulfuras)
      ==> lazy (
        let items =
          [| Item(Name=item.Name, Quality=item.Quality, SellIn=item.SellIn) |]
        let program = Program()
        for _ in 1 .. totalDays do
          program.UpdateQuality(items)

        match Array.tryHead items with
        | None -> false |@ "Items collection should NOT be empty!"
        | Some item' ->
            (0 <= item.Quality && item.Quality <= 50)
            |@ print (item, item')
      )