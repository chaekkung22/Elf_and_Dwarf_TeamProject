using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : BaseUI
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject questSlotPrefab;
    private List<QuestSlot> questSlots;
    private List<QuestSO> inProgressQuests;
    private List<QuestSO> rewardAvailableQuests;
    private List<QuestSO> completedQuests;
    private Quest quest;

    protected override UIState UIState { get; } = UIState.Quest;

    protected override void Initialize()
    {
        base.Initialize();
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(() => UIManager.Instance.CloseUI());

        quest = DataManager.Instance.GetQuest();
        questSlots = new List<QuestSlot>();

        // 퀘스트 Lists
        inProgressQuests = quest.GetInProgressQuests();
        rewardAvailableQuests = quest.GetRewardAvailableQuests();
        completedQuests = quest.GetCompletedQuests();

        // 슬롯 생성
        int totalQuestCnt = quest.GetAllQuestsCount();

        for (int i = 0; i < totalQuestCnt; i++)
        {
            questSlots.Add(Instantiate(questSlotPrefab, content).GetComponent<QuestSlot>());
        }
    }

    public override void SetUIActive(bool isActive)
    {
        if (isActive == false)
        {
            DataManager.Instance.GetQuest().RemoveEvent(UpdateQuestSlots);
        }
        base.SetUIActive(isActive);

        quest.AddEvent(UpdateQuestSlots);

        UpdateQuestSlots();

        this.gameObject.SetActive(isActive);
    }

    private void UpdateQuestSlots()
    {
        quest.CheckInProgressQuestsCleared();

        int idx = 0;

        for (int i = 0; i < rewardAvailableQuests.Count; i++)
        {
            questSlots[idx++].SetSlot(rewardAvailableQuests[i], QuestState.RewardAvailable);
        }

        for (int i = 0; i < inProgressQuests.Count; i++)
        {
            questSlots[idx++].SetSlot(inProgressQuests[i], QuestState.InProgress);
        }

        for (int i = 0; i < completedQuests.Count; i++)
        {
            questSlots[idx++].SetSlot(completedQuests[i], QuestState.Completed);
        }
    }

}