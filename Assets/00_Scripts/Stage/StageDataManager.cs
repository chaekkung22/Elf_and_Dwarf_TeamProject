using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDataManagerSO", menuName = "Scriptable Object/StageDataManager")]
public class StageDataManager : ScriptableObject
{
    [SerializeField] private List<StageData> stageDatabase;
}
