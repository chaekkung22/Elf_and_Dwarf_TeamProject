using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageUI : BaseUI
{
    [SerializeField] private Button selectStagePanel;
    [SerializeField] private Button stageSelectBtn;

    protected override UIState UIState { get; } = UIState.SelectStage;

    protected override void Start()
    {
        base.Start();
        selectStagePanel.onClick.AddListener(UIManager.Instance.CloseUI);
        stageSelectBtn.onClick.AddListener(() => GameManager.Instance.ChangeScene("StageScene"));
    }
}
