using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    #region Playerpref Key
    private const string PlayerInfoKey = "PlayerInfoKey";
    private const string StageInfoKey = "StageInfoKey";
    private const string QuestInfoKey = "QuestInfoKey";
    #endregion Playerpref Key

    #region Save Datas
    private PlayerInfo playerInfo;
    private StageInfo stageInfo;
    #endregion Save Datas

    #region In Game Data
    private bool isDataChanged = false;

    [SerializeField] private ItemDatabaseSO itemDatabaseSO;
    [SerializeField] private Quest quest;
    private List<ItemSO> allItems;
    private Dictionary<string, ItemSO> allItemsDictionary;

    private ItemSO equipedItem;
    private Dictionary<string, ItemSO> ownedItems;
    private List<ItemSO> ownedItemList;
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
        ownedItems = new Dictionary<string, ItemSO>();
        ownedItemList = new List<ItemSO>();
        LoadDatas();
        PlayerPrefs.DeleteAll();
    }

    public void LoadDatas()
    {
        LoadPlayerInfo();
        LoadStageInfo();
        quest.LoadQuestInfo(QuestInfoKey);
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
            equipedItem = allItemsDictionary[playerInfo.equipedItemId];
            ownedItems.Add(equipedItem.id, equipedItem);
        }

        // 보유 아이템 리스트 생성
        foreach (var pair in ownedItems)
        {
            ownedItemList.Add(pair.Value);
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

        quest.SaveQuestInfo(QuestInfoKey);

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

    public void SetStageInfo(int level, float clearTime, int gemCount, int starCount)
    {
        // 스테이지 레벨이 플레이 가능한 레벨보다 높은 경우
        if (level > stageInfo.clearLevel + 1)
        {
            Debug.LogError("잘못된 스테이지 클리어");
            return;
        }

        // 클리어 기록이 있는 경우
        if (stageInfo.clearLevel >= level)
        {
            stageInfo.bestClearTimeList[level] = clearTime < stageInfo.bestClearTimeList[level] ? clearTime : stageInfo.bestClearTimeList[level];
            stageInfo.gemCountList[level] = gemCount > stageInfo.gemCountList[level] ? gemCount : stageInfo.gemCountList[level];
            stageInfo.starCountList[level] = starCount > stageInfo.starCountList[level] ? starCount : stageInfo.starCountList[level];
        }
        else
        {
            stageInfo.clearLevel = level;
            stageInfo.bestClearTimeList.Add(clearTime);
            stageInfo.gemCountList.Add(gemCount);
            stageInfo.starCountList.Add(starCount);
        }
        isDataChanged = true;
    }

    public int GetGold()
    {
        return playerInfo.gold;
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
        isDataChanged = true;
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
            isDataChanged = true;
            return true;
        }
    }

    public bool AddItem(ItemSO item)
    {
        if (ownedItems.ContainsKey(item.id))
        {
            return false;
        }

        ownedItems.Add(item.id, item);
        ownedItemList.Add(item);
        OnChangeOwnedItems?.Invoke();
        isDataChanged = true;
        return true;
    }

    public void EquipItem(ItemSO item)
    {
        equipedItem = item;
        playerInfo.equipedItemId = item.id;
        OnChangeEquipedItem?.Invoke();
        isDataChanged = true;
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
        return ownedItems;
    }

    public List<ItemSO> GetOwnedItemList()
    {
        return ownedItemList;
    }

    public StageInfo GetStageInfo()
    {
        return stageInfo;
    }

    // ======= Quest 관련 매서드 =======
    public Quest GetQuest()
    {
        return quest;
    }

    public int GetStarCount()
    {
        int total = 0;
        foreach (var starCnt in stageInfo.starCountList)
        {
            total += starCnt;
        }
        return total;
    }

    public int GetThreeStarStageCount()
    {
        int cnt = 0;
        foreach (var starCnt in stageInfo.starCountList)
        {
            if (starCnt == 3)
            {
                cnt++;
            }
        }

        return cnt;
    }

    public bool CheckTimeAttack(int targetStage, float targetTime)
    {

        if (stageInfo.clearLevel >= targetStage && stageInfo.bestClearTimeList[targetStage] <= targetTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // ======= end: Quest 관련 매서드 =======

    public void AddChangeOwnedItemsEvent(Action action)
    {
        OnChangeOwnedItems += action;
    }

    public void RemoveChangeOwnedItemsEvent()
    {
        OnChangeOwnedItems = null;
    }

    public void AddChangeEquipedItemEvent(Action action)
    {
        OnChangeEquipedItem += action;
    }

    public void RemoveChangeEquipedItemEvent()
    {
        OnChangeEquipedItem = null;
    }
}
