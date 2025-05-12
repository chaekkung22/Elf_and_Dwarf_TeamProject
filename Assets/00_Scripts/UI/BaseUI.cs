using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected abstract UIState UIState { get; }
    [SerializeField] protected bool isStartUI = false;
    public bool IsStartUI { get { return isStartUI; } }

    protected virtual void Start()
    {
        Initialize();
        SetUIActive(isStartUI);
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
