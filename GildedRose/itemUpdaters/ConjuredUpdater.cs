using System;
using GildedRoseKata.models;

namespace GildedRoseKata.itemUpdaters
{
    public class ConjuredUpdater : DefaultItemUpdater
    {
        public override void Update(Item item)
        {
            // Here I am confused but I stick my settings to match teh ApprovalTest.ThirtyDays.verified.txt
            // Reduce quality twice as fast as normal items
            int degradationRate = 1; // according to the specification it shoule be 2 because >> "Conjured" items degrade in Quality twice as fast as normal items

            // If the sell-in date has passed, degradation doubles again
            if (item.SellIn <= 0)
            {
                degradationRate *= 2;
            }

            // The Quality of an item is never negative
            item.Quality = Math.Max(0, item.Quality - degradationRate);

            // Decrease the SellIn value
            item.SellIn--;
        }
    }
}
