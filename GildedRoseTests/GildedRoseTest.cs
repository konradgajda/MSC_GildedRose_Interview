using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.models;
using GildedRoseKata.enums;
using GildedRoseKata.interfaces;
using GildedRoseKata.itemUpdaters;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 } };
        var itemUpdater = new Dictionary<ItemName, IItemUpdater>
        {
            { ItemName.Conjured, new ConjuredUpdater() }
        };
        var app = new GildedRose(items, itemUpdater);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("Conjured Mana Cake"));
    }

    [Test]
    public void WhenItemListIsEmpty()
    {
        var items = new List<Item> { };
        var itemUpdaters = new Dictionary<ItemName, IItemUpdater>
        {
            { ItemName.Conjured, new ConjuredUpdater() }
        };
        var app = new GildedRose(items, itemUpdaters);
        app.UpdateQuality();
        Assert.That(items.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void ConjuredItemQualityDegradesTwiceAsFast()
    {
        var items = new List<Item>
        {
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };
        var itemUpdater = new Dictionary<ItemName, IItemUpdater>
        {
            { ItemName.Conjured, new ConjuredUpdater() }
        };
        var app = new GildedRose(items, itemUpdater);
        for (int i = 0; i < 6; i++)
        {
            app.UpdateQuality();
        }

        Assert.That(items[0].Quality, Is.EqualTo(0)); // Quality should drop to 0
        Assert.That(items[0].SellIn, Is.EqualTo(-3)); // SellIn should decrement each day
    }
}