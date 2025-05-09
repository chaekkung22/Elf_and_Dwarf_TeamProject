using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    private void Start()
    {
        UIManager.Instance.PauseButton = this.gameObject;
        pauseButton.onClick.AddListener(OnClickPauseButton);
    }

    private void OnClickPauseButton()
    {
        UIManager.Instance.OpenUI(UIState.Pause);
    }
}
