namespace Mahamudra.Kata.GildedRose.Test

open Mahamudra.Kata.GildedRose
open Mahamudra.Kata.GildedRose.Test
open FsCheck
 
type ItemGenerator private() =
  static let shrinkItem (item : Item) =
    (item.Quality, item.SellIn)
    |> Arb.shrink
    |> Seq.map (fun (quality, sellIn) ->
        Item(Name=item.Name, Quality=quality, SellIn=sellIn)
    )

  static let generateKind ctor known =
    Arb.generate<Item>
    |> Gen.where (fun item -> item.Name = known)
    |> Gen.map ctor

  static member Item =
    let generate =
      gen {
            let! name = Gen.frequency [
                (4, Gen.constant ItemName.Conjured)
                (4, Gen.constant ItemName.Dex5Vest)
                (4, Gen.constant ItemName.Backstage)
                (4, Gen.constant ItemName.Elixir)
                (2, Gen.constant ItemName.Aged)
                (1, Gen.constant ItemName.Sulfuras)]

            let! quality =
                if name = ItemName.Sulfuras
                then Gen.constant 80
                else Gen.choose (0, 50)

            let! sellIn =
                if name = ItemName.Sulfuras
                then Gen.constant 0
                else Arb.generate<int>

            return Item(Name=name, Quality=quality, SellIn=sellIn)
      }
    Arb.fromGenShrink (generate, shrinkItem)

 
  static member LegendaryItem =
    Item(Name=ItemName.Sulfuras, Quality=80, SellIn=0)
    |> LegendaryItem
    |> Gen.constant
    |> Arb.fromGen

  static member BackstageItem =
    let generate =
      generateKind BackstageItem ItemName.Backstage 

    let shrink (BackstageItem item) =
      item
      |> shrinkItem
      |> Seq.map BackstageItem

    Arb.fromGenShrink (generate, shrink)