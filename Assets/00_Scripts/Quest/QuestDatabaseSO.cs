using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDatabase", menuName = "Scriptable Object/Quest/QuestDatabase")]
public class QuestDatabaseSO : ScriptableObject
{
    private List<QuestSO> questDatabase;
    private Dictionary<string, QuestSO> questDatabaseDictionary;

    public void Init()
    {
        questDatabaseDictionary = new Dictionary<string, QuestSO>();

        foreach (var quest in questDatabase)
        {
            questDatabaseDictionary.Add(quest.id, quest);
        }
    }

    public QuestSO GetQuestFromDatabase(string key)
    {
        return questDatabaseDictionary[key];
    }

    public List<QuestSO> GetQuestDatabase()
    {
        return questDatabase;
    }
}
