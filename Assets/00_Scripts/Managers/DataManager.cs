using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    #region Playerpref Key
    private const string PlayerInfoKey = "PlayerInfoKey";
    private const string StageInfoKey = "StageInfoKey";
    #endregion Playerpref Key

    #region Save Datas
    private PlayerInfo playerInfo;
    private StageInfo stageInfo;
    #endregion Save Datas

    #region In Game Data
    private bool isDataChanged = false;

    [SerializeField] private ItemDatabaseSO itemDatabaseSO;
    [SerializeField] private List<ItemSO> allItems;
    private Dictionary<string, ItemSO> allItemsDictionary;

    private ItemSO equipedItem;
    private Dictionary<string, ItemSO> ownedItems;
    #endregion In Game Data

    #region Actions
    private Action OnChangeOwnedItems;
    private Action OnChangeEquipedItem;
    #endregion Actions



    protected override void Initialize()
    {
        itemDatabaseSO.Init();
        allItems = itemDatabaseSO.GetItemDatabase();
        allItemsDictionary = itemDatabaseSO.GetItemDatabaseDictionary();
    }

    public void LoadDatas()
    {
        LoadPlayerInfo();
        LoadStageInfo();
    }

    private void LoadPlayerInfo()
    {
        string playerInfoJson = PlayerPrefs.GetString(PlayerInfoKey);

        if (!string.IsNullOrEmpty(playerInfoJson))
        {
            // 저장된 값 있으면 
            playerInfo = JsonUtility.FromJson<PlayerInfo>(playerInfoJson);
            equipedItem = allItemsDictionary[playerInfo.equipedItemId];

            foreach (var itemId in playerInfo.ownedItemIds)
            {
                ownedItems.Add(itemId, allItemsDictionary[itemId]);
            }
        }
        else
        {
            // 저장된 값 없으면
            playerInfo = new PlayerInfo();
        }
    }

    private void LoadStageInfo()
    {
        string stageInfoJson = PlayerPrefs.GetString(StageInfoKey);
        if (!string.IsNullOrEmpty(stageInfoJson))
        {
            // 저장된 값 있으면
            stageInfo = JsonUtility.FromJson<StageInfo>(stageInfoJson);
        }
        else
        {
            // 저장된 값 없으면
            stageInfo = new StageInfo();
        }
    }

    public void SaveDatas()
    {
        if (!isDataChanged)
        {
            return;
        }

        SetOwnedItemIdList();
        string playerInfoJson = JsonUtility.ToJson(playerInfo);
        PlayerPrefs.SetString(PlayerInfoKey, playerInfoJson);

        string stageInfoJson = JsonUtility.ToJson(stageInfo);
        PlayerPrefs.SetString(StageInfoKey, stageInfoJson);

        PlayerPrefs.Save();

        isDataChanged = false;
    }

    private void SetOwnedItemIdList()
    {
        List<string> ownedItemIdList = new List<string>();
        foreach (var pair in ownedItems)
        {
            ownedItemIdList.Add(pair.Value.id);
        }
        playerInfo.ownedItemIds = ownedItemIdList;
    }

    public void EarnGold(int _gold)
    {
        if (playerInfo.gold > int.MaxValue - _gold)
        {
            playerInfo.gold = int.MaxValue;
        }
        else
        {
            playerInfo.gold += _gold;
        }
    }

    public bool SpendGold(int _gold)
    {
        // 돈 모자라면 false
        if (playerInfo.gold < _gold)
        {
            return false;
        }
        else
        {
            playerInfo.gold -= _gold;
            return true;
        }
    }

    public bool AddItem(ItemSO item)
    {
        if (ownedItems.ContainsKey(item.name))
        {
            return false;
        }

        ownedItems.Add(item.name, item);
        OnChangeOwnedItems?.Invoke();
        return true;
    }

    public void EquipItem(ItemSO item)
    {
        equipedItem = item;
        playerInfo.equipedItemId = item.id;
        OnChangeEquipedItem?.Invoke();
    }

    public List<ItemSO> GetAllItems()
    {
        return allItems;
    }

    public ItemSO GetEquipedItem()
    {
        return allItemsDictionary[playerInfo.equipedItemId];
    }

    public Dictionary<string, ItemSO> GetOwnedItems()
    {
        return allItemsDictionary;
    }

    public StageInfo GetStageInfo()
    {
        return stageInfo;
    }

    public void AddChangeOwnedItemsEvent(Action action)
    {
        OnChangeOwnedItems += action;
    }

    public void AddChangeEquipedItemEvent(Action action)
    {
        OnChangeEquipedItem += action;
    }
}
