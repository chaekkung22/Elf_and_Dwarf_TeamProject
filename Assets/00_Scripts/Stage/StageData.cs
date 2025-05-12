using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDataSO_", menuName = "Scriptable Object/Stage Data")]
public class StageData : ScriptableObject
{
    [SerializeField] private int stageLevel;
    [SerializeField] private float limitedTime; // 클리어 제한 시간
    [SerializeField] private int totalGemCount; // 스테이지에 존재하는 보석 개수
    [SerializeField] private GameObject mapPrefab; // 맵 프리팹

    public int StageLevel { get { return stageLevel; } }
    public float LimitedTime { get { return limitedTime; } }
    public int TotalGemCount { get { return totalGemCount; } }
    public GameObject MapPrefab { get { return mapPrefab; } }
}
