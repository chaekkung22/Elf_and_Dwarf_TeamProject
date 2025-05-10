using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    private float playTime = 0.0f;
    private bool isClear = false;
    private int starCount = 0;
    private int earnGold = 0;

    public float PlayTime { get { return playTime; } }
    public bool IsClear { get { return isClear; } }
    public int StarCount { get { return starCount; } }
    public int EarnGold { get { return earnGold; } }

    public bool isFireAtDoor = false;
    public bool isWaterAtDoor = false;

    protected override void Initialize()
    {

    }

    private void Update()
    {

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
    }

    public void ResumeGame()
    {
        UIManager.Instance.CloseUI();
        Time.timeScale = 1f;
    }

}
