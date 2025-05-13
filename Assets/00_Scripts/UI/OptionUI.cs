using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : BaseUI
{
    [SerializeField] private Button okButton;

    protected override UIState UIState { get; } = UIState.Stage;

    protected override void Initialize()
    {
        base.Initialize();
    }


}
