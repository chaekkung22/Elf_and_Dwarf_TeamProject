using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageUI : BaseUI
{
    [SerializeField] private Button selectStagePanel;

    protected override UIState UIState { get; } = UIState.SelectStage;

    protected override void Start()
    {
        base.Start();
        selectStagePanel.onClick.AddListener(() => UIManager.Instance.CloseUI());
    }
}
