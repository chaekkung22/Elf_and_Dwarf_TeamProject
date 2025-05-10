using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public Action<float> OnChangeTime;
    public Action<bool> OnPauseGame;
    public Action<PlayerType, int> OnGetGem;

    private float playTime = 0.0f;
    private bool isClear = false;
    private int starCount = 0;
    private int earnGold = 0;
    private int[] gem = new int[2];

    public float PlayTime { get { return playTime; } }
    public bool IsClear { get { return isClear; } }
    public int StarCount { get { return starCount; } }
    public int EarnGold { get { return earnGold; } }

    public bool isFireAtDoor = false;
    public bool isWaterAtDoor = false;

    protected override void Initialize()
    {
        gem[(int)PlayerType.Fire] = 0;
        gem[(int)PlayerType.Water] = 0;
    }

    private void Update()
    {
        if(Time.timeScale != 0)
        {
            playTime += Time.deltaTime;
            OnChangeTime?.Invoke(playTime);
        }
    }

    

    private void ClearStage()
    {

    }

    private void FailStage()
    {

    }

    public bool SetPlayerDoorState(PlayerType playerType, bool isPlayerAtDoor)
    {
        if (playerType == PlayerType.Fire)
        {
            isFireAtDoor = isPlayerAtDoor;
        }

        if (playerType == PlayerType.Water)
        {
            isWaterAtDoor = isPlayerAtDoor;
        }

        if (isWaterAtDoor && isFireAtDoor)
        {
            ClearStage();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PauseGame()
    {
        UIManager.Instance.OpenUI(UIState.Pause);
        Time.timeScale = 0f;
        OnPauseGame?.Invoke(true);
    }

    public void ResumeGame()
    {
        UIManager.Instance.CloseUI();
        Time.timeScale = 1f;
        OnPauseGame?.Invoke(false);
    }

    public void AddGemCountByType(PlayerType idx)
    {
        gem[(int)idx]++;
        OnGetGem(idx, gem[(int)idx]);
    }

    public void AddTimeChangeEvent(Action<float> action)
    {
        OnChangeTime += action;
    }

    public void AddOnPauseEvent(Action<bool> action)
    {
        OnPauseGame += action;
    }

    public void AddGetGemEvent(Action<PlayerType, int> action)
    {
        OnGetGem += action;
    }
}
