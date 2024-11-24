using GildedRoseKata.models;

namespace GildedRoseKata.itemUpdaters;

public class AgedBrieUpdater : DefaultItemUpdater
{
    public override void Update(Item item)
    {

        // "Aged Brie" actually increases in Quality the older it gets
        // The Quality of an item is never more than 50
        if (item.Quality < 50)
        {
            item.Quality++;
        }

        item.SellIn--;

        if (item.SellIn < 0 && item.Quality < 50)
        {
            item.Quality++;
        }
    }
}