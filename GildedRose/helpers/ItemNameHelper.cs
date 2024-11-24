using GildedRoseKata.enums;

namespace GildedRoseKata.helpers;

public static class ItemNameHelper
{
    public static ItemName? GetItemName(string name)
    {
        // this is just to map the item name to the enum and simplify the code
        return name switch
        {
            "Aged Brie" => ItemName.AgedBrie,
            "Backstage passes to a TAFKAL80ETC concert" => ItemName.BackstagePasses,
            "Sulfuras, Hand of Ragnaros" => ItemName.Sulfuras,
            "Conjured Mana Cake" => ItemName.Conjured,
            _ => null
        };
    }
}