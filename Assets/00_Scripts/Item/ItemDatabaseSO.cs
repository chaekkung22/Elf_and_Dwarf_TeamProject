using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Scriptable Object/Item/ItemDatabase")]
public class ItemDatabaseSO : ScriptableObject
{
    [SerializeField] private List<ItemSO> itemDatabase;
    private Dictionary<string, ItemSO> itemDatabaseDictionary;

    public void Init()
    {
        itemDatabaseDictionary = new Dictionary<string, ItemSO>();

        foreach (var item in itemDatabase)
        {
            itemDatabaseDictionary.Add(item.id, item);
        }
    }

    public List<ItemSO> GetItemDatabase()
    {
        return itemDatabase;
    }

    public Dictionary<string, ItemSO> GetItemDatabaseDictionary()
    {
        return itemDatabaseDictionary;
    }
}
