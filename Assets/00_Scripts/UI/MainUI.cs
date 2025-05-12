using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    [SerializeField] private Button selectStageBtn;
    [SerializeField] private Button exitBtn;

    protected override UIState UIState { get; } = UIState.Main;

    protected override void Start()
    {
        base.Start();
        selectStageBtn.onClick.AddListener(() => UIManager.Instance.OpenUI(UIState.SelectStage));
        exitBtn.onClick.AddListener(GameManager.Instance.ExitGame);
    }
}
