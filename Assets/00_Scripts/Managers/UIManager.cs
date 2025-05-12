using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Stack<UIState> uiStack;
    private Dictionary<UIState, BaseUI> uiDictionary;

    protected override void Initialize()
    {
        uiStack = new Stack<UIState>();
        uiDictionary = new Dictionary<UIState, BaseUI>();
    }

    public void SetUI(UIState uiState, BaseUI ui)
    {
        if (uiDictionary == null || uiStack == null)
            Initialize();

        uiDictionary.Add(uiState, ui);
    }

    public void OpenUI(UIState uiState)
    {
        uiStack.Push(uiState);
        uiDictionary[uiState].SetUIActive(true);
    }

    /// <summary>
    /// 현재 UI 비활성화
    /// </summary>
    public void CloseUI()
    {
        uiDictionary[uiStack.Peek()].SetUIActive(false);
        uiStack.Pop();
    }

    /// <summary>
    /// 현재 UI 비활성화 후 다음 UI 활성화
    /// </summary>
    /// <param name="uiState">다음 UI</param>
    public void ChangeUI(UIState uiState)
    {
        CloseUI();
        OpenUI(uiState);
    }
}
