using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected abstract UIState UIState { get; }

    private void Start()
    {
        Initialize();
        SetUIActive(false);
    }

    protected virtual void Initialize()
    {
        UIManager.Instance.SetUI(UIState, this);
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
