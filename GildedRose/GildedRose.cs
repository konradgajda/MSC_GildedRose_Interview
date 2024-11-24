using System;
using System.Collections.Generic;
using GildedRoseKata.enums;
using GildedRoseKata.helpers;
using GildedRoseKata.itemUpdaters;
using GildedRoseKata.models;
using GildedRoseKata.interfaces;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items, Dictionary<ItemName, IItemUpdater> itemUpdaters)
{
    private readonly IList<Item> _items = items ?? throw new ArgumentNullException(nameof(items));
    private readonly Dictionary<ItemName, IItemUpdater> _itemUpdaters = itemUpdaters ?? throw new ArgumentNullException(nameof(itemUpdaters));
    private readonly DefaultItemUpdater _defaultItemUpdater = new DefaultItemUpdater();

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            try
            {
                var itemType = ItemNameHelper.GetItemName(item.Name);

                if (itemType.HasValue && _itemUpdaters.TryGetValue(itemType.Value, out var updater))
                {
                    updater.Update(item);
                }
                else
                {
                    _defaultItemUpdater.Update(item);
                }
            }
            catch (Exception ex)
            {
                // Log detailed information for debugging
                Console.WriteLine($"Error updating item '{item.Name}' (SellIn: {item.SellIn}, Quality: {item.Quality}). Exception: {ex}");
            }
        }
    }
}
