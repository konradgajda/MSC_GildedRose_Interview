using GildedRoseKata.models;

namespace GildedRoseKata.itemUpdaters;

public class BackstagePassUpdater : DefaultItemUpdater
{
    public override void Update(Item item)
    {
        /*
            "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
            Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
            Quality drops to 0 after the concert
        */
        if (item.Quality < 50)
        {
            item.Quality++;
            if (item.SellIn < 11 && item.Quality < 50)
            {
                item.Quality++;
            }

            if (item.SellIn < 6 && item.Quality < 50)
            {
                item.Quality++;
            }
        }

        item.SellIn--;

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }
}