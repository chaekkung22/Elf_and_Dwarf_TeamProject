using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questNameText;
    [SerializeField] private TextMeshProUGUI questCountText;
    [SerializeField] private TextMeshProUGUI questGoldText;
    [SerializeField] private Button inProgressButton;
    [SerializeField] private Button rewardButton;
    [SerializeField] private Button completedButton;

    public void SetSlot(QuestSO quest, QuestState questState)
    {
        questNameText.text = quest.questName;
        string countText = "";
        switch (quest.type)
        {
            case QuestType.CollectStar:
                int starCnt = DataManager.Instance.GetStarCount();
                countText = MakeCollectStarText(questState, starCnt, quest.targetAmount);
                break;
            case QuestType.ThreeStarStage:
                int threeStarStageCnt = DataManager.Instance.GetThreeStarStageCount();
                countText = MakeThreeStarStageText(questState, threeStarStageCnt, quest.targetAmount);
                break;
            case QuestType.TimeAttack:
                float clearTime;
                bool isClear = false; ;
                if (DataManager.Instance.GetStageInfo().clearLevel >= quest.targetStage)
                {
                    clearTime = DataManager.Instance.GetStageInfo().bestClearTimeList[quest.targetStage];
                    isClear = true;
                }
                else
                {
                    clearTime = 99999;
                }

                TimeSpan _cleartime = TimeSpan.FromSeconds(clearTime);
                TimeSpan _targetTime = TimeSpan.FromSeconds(quest.targetTime);
                countText = MakeTimeAttackText(questState, _cleartime, _targetTime, isClear);
                break;
            case QuestType.EarnGold:
                int gold = DataManager.Instance.GetGold();
                countText = MakeEarnGoldText(questState, gold, quest.targetAmount);
                break;
        }
        questCountText.text = countText;

        questGoldText.text = $"{quest.reward} G";

        ButtonSetting(quest, questState);
    }

    private string MakeCollectStarText(QuestState questState, int starCnt, int targetAmount)
    {
        string tempText;
        if (questState == QuestState.RewardAvailable)
        {
            tempText = $"<color=blue>{starCnt} </color> / {targetAmount}";
        }
        else if (questState == QuestState.Completed)
        {
            tempText = $"<color=#bbb>{starCnt} / {targetAmount}</color>";
        }
        else
        {
            tempText = $"<color=red>{starCnt} </color> / {targetAmount}";
        }
        return tempText;
    }

    private string MakeThreeStarStageText(QuestState questState, int threeStarStageCnt, int targetAmount)
    {
        string tempText;
        if (questState == QuestState.RewardAvailable)
        {
            tempText = $"<color=blue>{threeStarStageCnt} </color> / {targetAmount}";
        }
        else if (questState == QuestState.Completed)
        {
            tempText = $"<color=#bbb>{threeStarStageCnt} / {targetAmount}</color>";
        }
        else
        {
            tempText = $"<color=red>{threeStarStageCnt} </color> / {targetAmount}";
        }
        return tempText;
    }

    private string MakeTimeAttackText(QuestState questState, TimeSpan _cleartime, TimeSpan _targetTime, bool isClear)
    {
        string tempText;

        if (questState == QuestState.RewardAvailable)
        {
            tempText = $"<color=blue>{_cleartime.Minutes:00}:{_cleartime.Seconds:00} </color> / {_targetTime.Minutes:00}:{_targetTime.Seconds:00}";
        }
        else if (questState == QuestState.Completed)
        {
            tempText = $"<color=#bbb>{_cleartime.Minutes:00}:{_cleartime.Seconds:00} / {_targetTime.Minutes:00}:{_targetTime.Seconds:00}</color>";
        }
        else
        {
            if (isClear)
            {
                tempText = $"<color=red>{_cleartime.Minutes:00}:{_cleartime.Seconds:00} </color> / {_targetTime.Minutes:00}:{_targetTime.Seconds:00}";
            }
            else
            {
                tempText = $"<color=red>--:-- </color> / {_targetTime.Minutes:00}:{_targetTime.Seconds:00}";
            }
        }
        return tempText;
    }

    private string MakeEarnGoldText(QuestState questState, int gold, int targetGold)
    {
        string tempText;
        if (questState == QuestState.RewardAvailable)
        {
            tempText = $"<color=blue>{gold}</color> / {targetGold}";
        }
        else if (questState == QuestState.Completed)
        {
            tempText = $"<color=#bbb>{gold} / {targetGold}</color>";
        }
        else
        {
            tempText = $"<color=red>{gold}</color> / {targetGold}";
        }

        return tempText;
    }

    private void ButtonSetting(QuestSO quest, QuestState questState)
    {
        ResetButtons();

        switch (questState)
        {
            case QuestState.InProgress:
                inProgressButton.gameObject.SetActive(true);
                break;
            case QuestState.RewardAvailable:
                rewardButton.gameObject.SetActive(true);
                rewardButton.onClick.AddListener(() => DataManager.Instance.GetQuest().GetReward(quest));
                break;
            case QuestState.Completed:
                completedButton.gameObject.SetActive(true);
                break;
        }
    }

    private void ResetButtons()
    {
        inProgressButton.onClick.RemoveAllListeners();
        rewardButton.onClick.RemoveAllListeners();
        completedButton.onClick.RemoveAllListeners();

        inProgressButton.gameObject.SetActive(false);
        rewardButton.gameObject.SetActive(false);
        completedButton.gameObject.SetActive(false);
    }
}
