using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private QuestDatabaseSO questDatabase;
    private QuestInfo questInfo;
    private List<QuestSO> inProgressQuests;
    private List<QuestSO> rewardAvailableQuests;
    private List<QuestSO> completedQuests;
    private Action onQuest;

    public void LoadQuestInfo(string questInfoKey)
    {
        inProgressQuests = new List<QuestSO>();
        rewardAvailableQuests = new List<QuestSO>();
        completedQuests = new List<QuestSO>();
        questDatabase.Init();

        string questInfoJson = PlayerPrefs.GetString(questInfoKey);

        if (!string.IsNullOrEmpty(questInfoJson))
        {
            // 저장된 값 있으면
            questInfo = JsonUtility.FromJson<QuestInfo>(questInfoJson);
            MakeQuestLists();
        }
        else
        {
            // 저장된 값 없으면
            questInfo = new QuestInfo();
            MakeNewQuestLists();
        }
    }

    private void MakeNewQuestLists()
    {
        foreach (var quest in questDatabase.GetQuestDatabase())
        {
            inProgressQuests.Add(quest);
        }
    }

    private void MakeQuestLists()
    {
        foreach (var questId in questInfo.inProgressQuestIds)
        {
            inProgressQuests.Add(questDatabase.GetQuestFromDatabase(questId));
        }

        foreach (var questId in questInfo.rewardAvailableQuestIds)
        {
            rewardAvailableQuests.Add(questDatabase.GetQuestFromDatabase(questId));
        }

        foreach (var questId in questInfo.completedQuestIds)
        {
            completedQuests.Add(questDatabase.GetQuestFromDatabase(questId));
        }
    }

    public void SaveQuestInfo(string questInfoKey)
    {
        SetQuestInfo();
        string questInfoJson = JsonUtility.ToJson(questInfo);
        PlayerPrefs.SetString(questInfoKey, questInfoJson);

        PlayerPrefs.Save();
    }

    private void SetQuestInfo()
    {
        questInfo.inProgressQuestIds.Clear();
        questInfo.rewardAvailableQuestIds.Clear();
        questInfo.completedQuestIds.Clear();

        foreach (var quest in inProgressQuests)
        {
            questInfo.inProgressQuestIds.Add(quest.id);
        }

        foreach (var quest in rewardAvailableQuests)
        {
            questInfo.rewardAvailableQuestIds.Add(quest.id);
        }

        foreach (var quest in completedQuests)
        {
            questInfo.completedQuestIds.Add(quest.id);
        }
    }

    public void CheckInProgressQuestsCleared()
    {
        for (int i = inProgressQuests.Count - 1; i >= 0; i--)
        {
            var quest = inProgressQuests[i];
            if (CheckQuestCleared(quest))
            {
                inProgressQuests.RemoveAt(i);
                rewardAvailableQuests.Add(quest);
            }
        }
    }

    public bool CheckQuestCleared(QuestSO quest)
    {
        switch (quest.type)
        {
            case QuestType.CollectStar:
                return DataManager.Instance.GetStarCount() >= quest.targetAmount;
            case QuestType.ThreeStarStage:
                return quest.targetAmount <= DataManager.Instance.GetThreeStarStageCount();
            case QuestType.TimeAttack:
                return DataManager.Instance.CheckTimeAttack(quest.targetStage, quest.targetTime);
            case QuestType.EarnGold:
                return DataManager.Instance.GetGold() >= quest.targetAmount;
        }
        return false;
    }

    public void GetReward(QuestSO quest)
    {
        DataManager.Instance.EarnGold(quest.reward);
        rewardAvailableQuests.Remove(quest);
        completedQuests.Add(quest);
        onQuest?.Invoke();

        DataManager.Instance.SaveDatas();
    }

    public int GetAllQuestsCount()
    {
        return questDatabase.GetQuestCount();
    }

    public List<QuestSO> GetInProgressQuests()
    {
        return inProgressQuests;
    }

    public List<QuestSO> GetRewardAvailableQuests()
    {
        return rewardAvailableQuests;
    }

    public List<QuestSO> GetCompletedQuests()
    {
        return completedQuests;
    }

    public void AddEvent(Action action)
    {
        onQuest += action;
    }

    public void RemoveEvent()
    {
        onQuest = null;
    }
}
