using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : BaseUI
{
    protected override UIState UIState { get; } = UIState.Quest;

    protected override void Initialize()
    {
        base.Initialize();

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