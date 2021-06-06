using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LighthouseData
{
    public int sceneId;
    
    public bool uniqueCollected1;
    public bool uniqueCollected2;

    public int itemsCount;
    public string[] itemNames;

    public LighthouseData(Player player)
    {
        sceneId = player.level;
        
        uniqueCollected1 = Player.UniqueCollected1;
        uniqueCollected2 = Player.UniqueCollected2;
        
        itemNames = SaveItems(player);
        itemsCount = itemNames.Length;
    }

    private string[] SaveItems(Player player)
    {
        List<string> itemsToSave = new List<string>();
        
        foreach (var item in player.playerInventory.items)
        {
            if (item == null) continue;
            itemsToSave.Add(item.name);
        }
        
        return itemsToSave.ToArray();
    }
}
