using System.Collections.Generic;
[System.Serializable]
public class QuestInfo
{
    public List<string> inProgressQuestIds = new List<string>();
    public List<string> rewardAvailableQuestIds = new List<string>();
    public List<string> completedQuestIds = new List<string>();
}
