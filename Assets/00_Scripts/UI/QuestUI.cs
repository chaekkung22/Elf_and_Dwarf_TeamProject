using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : BaseUI
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject questSlot;
    private List<QuestSO> inProgressQuests;
    private List<QuestSO> rewardAvailableQuests;
    private List<QuestSO> completedQuests;

    protected override UIState UIState { get; } = UIState.Quest;

    protected override void Initialize()
    {
        base.Initialize();
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(() => UIManager.Instance.CloseUI());
        Quest quest = DataManager.Instance.GetQuest();

        inProgressQuests = quest.GetInProgressQuests();
        rewardAvailableQuests = quest.GetRewardAvailableQuests();
        completedQuests = quest.GetCompletedQuests();
        quest.AddEvent(UpdateQuestSlots);
    }

    public override void SetUIActive(bool isActive)
    {
        if (isActive == false)
        {
            DataManager.Instance.GetQuest().RemoveEvent(UpdateQuestSlots);
        }
        base.SetUIActive(isActive);

        UpdateQuestSlots();

        this.gameObject.SetActive(isActive);
    }

    private void UpdateQuestSlots()
    {

    }

}