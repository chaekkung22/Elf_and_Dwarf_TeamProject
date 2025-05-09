using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    protected UIState uiState;

    private void Awake()
    {
        Initialize();
        SetUIActive(false);
    }

    protected virtual void Initialize()
    {
        UIManager.Instance.SetUI(uiState, this);
    }

    public virtual void SetUIActive(bool isActive)
    {
        if (isActive == false)
        {
            this.gameObject.SetActive(false);
            return;
        }
    }

}
