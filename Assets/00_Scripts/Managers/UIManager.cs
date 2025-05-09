using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Stack<UIState> uiStack;
    private Dictionary<UIState, BaseUI> uiDictionary;

    public GameObject PauseButton { private get; set; }

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

    public void CloseUI()
    {
        uiDictionary[uiStack.Peek()].SetUIActive(false);
        uiStack.Pop();
    }

    public void SetActivePauseButton(bool isPause)
    {
        if (PauseButton != null)
        {
            PauseButton.SetActive(isPause);
        }
    }
}
