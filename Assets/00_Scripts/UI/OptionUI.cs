using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : BaseUI
{
    [SerializeField] private Button okButton;

    protected override UIState UIState { get; } = UIState.Option;

    protected override void Initialize()
    {
        base.Initialize();
        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(() => UIManager.Instance.CloseUI());
    }


}
