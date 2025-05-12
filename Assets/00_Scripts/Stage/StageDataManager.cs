using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDataManagerSO", menuName = "Scriptable Object/StageDataManager")]
public class StageDataManager : ScriptableObject
{
    [SerializeField] private List<StageData> stageDatabase;

    public void CreateMap(int level)
    {
        GameObject map = Instantiate(stageDatabase.Find((x) => x.StageLevel == level).MapPrefab);
        map.transform.position = Vector3.zero;
    }

    public float GetLimitedTime(int level)
    {
        return stageDatabase.Find((x) => x.StageLevel == level).LimitedTime;
    }

    public int GetTotalGemCount(int level)
    {
        return stageDatabase.Find((x) => x.StageLevel == level).TotalGemCount;
    }
}
