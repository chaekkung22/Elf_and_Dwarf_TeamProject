using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    [SerializeField] private Button selectStageBtn;
    [SerializeField] private Button storeBtn;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button inventoryBtn;

    protected override UIState UIState { get; } = UIState.Main;

    protected override void Start()
    {
        base.Start();
        selectStageBtn.onClick.AddListener(() => UIManager.Instance.OpenUI(UIState.SelectStage));
        storeBtn.onClick.AddListener(() => UIManager.Instance.OpenUI(UIState.Shop));
        exitBtn.onClick.AddListener(GameManager.Instance.ExitGame);
        inventoryBtn.onClick.AddListener(() => UIManager.Instance.OpenUI(UIState.Inventory));
    }
}
