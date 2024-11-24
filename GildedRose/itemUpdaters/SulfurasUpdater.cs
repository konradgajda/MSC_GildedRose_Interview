     using GildedRoseKata.interfaces;
     using GildedRoseKata.models;

     namespace GildedRoseKata.itemUpdaters;

    public class SulfurasUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality

        }
    }