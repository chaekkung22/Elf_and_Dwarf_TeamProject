using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUI :BaseUI
{
    protected override UIState UIState { get; } = UIState.Stage;

    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private TextMeshProUGUI score_fireTxt;
    [SerializeField] private TextMeshProUGUI score_waterTxt;
    [SerializeField] private Button pauseButton;

    protected override void Initialize()
    {
        base.Initialize();
        pauseButton.onClick.AddListener(OnClickPauseButton);
        StageManager.Instance.AddTimeChangeEvent(UpdateTimeText);
        StageManager.Instance.AddOnPauseEvent(SetPauseButtonActive);
        StageManager.Instance.AddGetGemEvent(UpdateGemCountText);
    }

    public void UpdateTimeText(float time)
    {
        TimeSpan _time = TimeSpan.FromSeconds(time);
        timeTxt.text = $"{_time.Minutes:00}:{_time.Seconds:00}";
    }

    private void OnClickPauseButton()
    {
        StageManager.Instance.PauseGame();
        pauseButton.gameObject.SetActive(false);
    }

    private void SetPauseButtonActive(bool isPause)
    {
        pauseButton.gameObject.SetActive(!isPause);
    }

    private void UpdateGemCountText(PlayerType playerType, int count)
    {
        if(playerType == PlayerType.Fire)
        {
            score_fireTxt.text = count.ToString();
        }
        else
        {
            score_waterTxt.text = count.ToString();
        }
    }
}
