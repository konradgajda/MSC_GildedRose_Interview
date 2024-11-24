using GildedRoseKata.interfaces;
using GildedRoseKata.models;

namespace GildedRoseKata.itemUpdaters;

public class DefaultItemUpdater : IItemUpdater
{
    public virtual void Update(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }

        item.SellIn--;

        if (item.SellIn < 0 && item.Quality > 0)
        {
            // The Quality of an item is never negative, see above
            item.Quality--;
        }
    }
}