using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : BaseUI
{
    [SerializeField] private Button exitButton;
    protected override UIState UIState { get; } = UIState.Quest;

    protected override void Initialize()
    {
        base.Initialize();
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(() => UIManager.Instance.CloseUI());
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);



        this.gameObject.SetActive(isActive);
    }

    private void UpdateQuestSlots()
    {

    }

}