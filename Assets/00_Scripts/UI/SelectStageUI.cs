using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageUI : BaseUI
{
    [Header("Control UI")]
    [SerializeField] private Button selectStagePanel;
    [SerializeField] private Button stageSelectBtn;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button prevBtn;

    [Header("Stage Info UI")]
    [SerializeField] private GameObject[] starImgs;
    [SerializeField] private TextMeshProUGUI bestTimeTxt;
    [SerializeField] private TextMeshProUGUI gemCountTxt;

    protected override UIState UIState { get; } = UIState.SelectStage;

    protected override void Start()
    {
        base.Start();
        selectStagePanel.onClick.AddListener(UIManager.Instance.CloseUI);
        stageSelectBtn.onClick.AddListener(() => GameManager.Instance.ChangeScene("StageScene"));
    }

    private void OnEnable()
    {
        
    }

    private void ShowStageInfo(int stageId)
    {
        StageInfo info = DataManager.Instance.GetStageInfo();

        // 별 최대 개수 3개
        // 부족한 별 개수 만큼 오브젝트 비활성화
        for(int i = 0; i < 3 - info.starCountList[stageId]; i++)
        {
            starImgs[i].SetActive(false);
        }

        bestTimeTxt.text = info.bestClearTimeList[stageId].ToString();
        gemCountTxt.text = info.gemCountList[stageId].ToString();
    }
}
