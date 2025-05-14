using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO_", menuName = "Scriptable Object/Quest/Quest")]
public class QuestSO : ScriptableObject
{
    [Header("Common")]
    public string id;
    public QuestType type;
    public string questName;
    public int reward;

    [Space(10)]
    [Header("Amount Quest")]
    public int targetAmount;

    [Space(10)]
    [Header("Time Attack Quest")]
    public float targetTime;
    public int targetStage;
}
