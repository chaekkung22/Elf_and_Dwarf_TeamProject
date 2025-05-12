using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TitleUI : BaseUI
{
    [SerializeField] private Button titlePanel;

    protected override UIState UIState { get; } = UIState.Title;

    protected override void Start()
    {
        base.Start();
        titlePanel.onClick.AddListener(() => UIManager.Instance.ChangeUI(UIState.Main));
    }

    public void OnAnyKey(InputValue value)
    {
        if(value.isPressed)
            UIManager.Instance.ChangeUI(UIState.Main);
    }
}
