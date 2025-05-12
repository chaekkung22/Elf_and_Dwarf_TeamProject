using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageUI : BaseUI
{
    private const string curStageLevelKey = "CurStage";
    private const string bestTimeDefaultTxt = "클리어 시간 - ";
    private const string gemCountDefaultTxt = "획득한 보석 - ";

    [Header("Control UI")]
    [SerializeField] private Button selectStagePanel;
    [SerializeField] private Button stageSelectBtn;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button prevBtn;

    [Header("Stage Info UI")]
    [SerializeField] private TextMeshProUGUI stageLevelTxt;
    [SerializeField] private GameObject[] starImgs;
    [SerializeField] private TextMeshProUGUI bestTimeTxt;
    [SerializeField] private TextMeshProUGUI gemCountTxt;

    private StringBuilder stageLevelStr = new StringBuilder();
    private StringBuilder timeStr = new StringBuilder();
    private StringBuilder gemStr = new StringBuilder();

    private int curLevel = 0;

    protected override UIState UIState { get; } = UIState.SelectStage;

    protected override void Start()
    {
        base.Start();
        selectStagePanel.onClick.AddListener(UIManager.Instance.CloseUI);
        stageSelectBtn.onClick.AddListener(() => OnClickStageSelectBtn());
        nextBtn.onClick.AddListener(() => OnClickStageInfoChangeBtn(1));
        prevBtn.onClick.AddListener(() => OnClickStageInfoChangeBtn(-1));
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);

        // UI가 켜지는 시점
        if(isActive)
        {
            SetStageInfoUIValue(curLevel);
        }
    }

    private void OnClickStageSelectBtn()
    {
        PlayerPrefs.SetInt(curStageLevelKey, curLevel);
        GameManager.Instance.ChangeScene("StageScene");
    }

    /// <summary>
    /// 다음 혹은 이전 버튼 클릭 시 발생하는 이벤트
    /// </summary>
    /// <param name="value">[1 == next / -1 == prev]</param>
    private void OnClickStageInfoChangeBtn(int value)
    {
        // value값이 1또는 -1이 아닌 경우
        if(value != 1 && value != -1)
        {
            Debug.LogError("잘못된 매개 변수 사용");
            return;
        }

        // 출력하려는 스테이지 레벨이 0보다 작거나 == 범위를 벗어남
        //(최종 클리어 레벨 + 1) 보다 크면 == 해금이 안 된 스테이지
        if(curLevel + value < 0 || curLevel + value > DataManager.Instance.GetStageInfo().clearLevel + 1)
        {
            Debug.Log("범위 벗어남 혹은 미해금 스테이지 접근");
            return;
        }

        curLevel += value;
        SetStageInfoUIValue(curLevel);
    }

    /// <summary>
    /// 스테이지 정보 UI에 들어갈 값 가공
    /// </summary>
    /// <param name="stageId">출력할 스테이지 레벨[0 == 튜토리얼]</param>
    private void SetStageInfoUIValue(int stageId)
    {
        StageInfo info = DataManager.Instance.GetStageInfo();

        int starCnt;
        stageLevelStr.Clear();
        timeStr.Clear();
        gemStr.Clear();

        if(info.clearLevel >= stageId)
        {
            starCnt = info.starCountList[stageId];
            TimeSpan _time = TimeSpan.FromSeconds(info.bestClearTimeList[stageId]);
            timeStr.Append($"{_time.Minutes:00}:{_time.Seconds:00}");
            gemStr.Append(info.gemCountList[stageId].ToString());
        }
        else
        {
            starCnt = 0;
            timeStr.Append("00:00");
            gemStr.Append("0");
        }

        if(stageId == 0)
            stageLevelStr.Append("Tutorial");
        else
            stageLevelStr.Append($"Stage{stageId}");


        ShowStageInfo(stageLevelStr.ToString(), starCnt, timeStr.ToString(), gemStr.ToString());
    }
    
    /// <summary>
    /// 스테이지 정보 UI에 출력
    /// </summary>
    /// <param name="stageLevel">스테이지 레벨</param>
    /// <param name="starCnt">스테이지 클리어 등급</param>
    /// <param name="bestTime">스테이지 클리어 시간</param>
    /// <param name="gemCount">획득한 보석 개수</param>
    private void ShowStageInfo(string stageLevel, int starCnt, string bestTime,  string gemCount)
    {
        stageLevelTxt.text = stageLevel;

        // 별 최대 개수 3개
        // 부족한 별 개수 만큼 오브젝트 비활성화
        for(int i = 0; i < 3 - starCnt; i++)
        {
            starImgs[i].SetActive(false);
        }

        bestTimeTxt.text = bestTime;
        gemCountTxt.text = gemCount;
    }
}
