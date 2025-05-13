using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    private const string curStageLevelKey = "CurStage";

    public Action<float> OnChangeTime;
    public Action<bool> OnPauseGame;
    public Action<PlayerType, int> OnGetGem;

    private float playTime = 0.0f;
    private bool isClear = false;
    private bool isGameDone = false;
    private int starCount = 0;
    private int earnGold = 0;
    private int[] gem = new int[2];

    public float PlayTime { get { return playTime; } }
    public bool IsClear { get { return isClear; } }
    public int StarCount { get { return starCount; } }
    public int EarnGold { get { return earnGold; } }

    [HideInInspector] public bool isFireAtDoor = false;
    [HideInInspector] public bool isWaterAtDoor = false;

    private PlayerController firePlayer;
    private PlayerController waterPlayer;

    [SerializeField] private StageDataManager stageDataManager;

    protected override void Initialize()
    {
        Time.timeScale = 1f;
        gem[(int)PlayerType.Fire] = 0;
        gem[(int)PlayerType.Water] = 0;

        isClear = false;
        isGameDone = false;

        stageDataManager.CreateMap(PlayerPrefs.GetInt(curStageLevelKey));
        Camera.main.orthographicSize = stageDataManager.GetCameraSize(PlayerPrefs.GetInt(curStageLevelKey));
        Debug.Log(stageDataManager.GetLimitedTime(PlayerPrefs.GetInt(curStageLevelKey)));
        Debug.Log(stageDataManager.GetTotalGemCount(PlayerPrefs.GetInt(curStageLevelKey)));
    }

    private void Update()
    {
        if (isGameDone)
            return;

        if (Time.timeScale != 0)
        {
            playTime += Time.deltaTime;
            OnChangeTime?.Invoke(playTime);
        }
    }



    private void ClearStage()
    {
        isClear = true;
        isGameDone = true;
        starCount = 2;
        // TODO: DataManager에 Gold 추가하기
        // DataManager.Instance.EarnGold(gold);
        OnPauseGame?.Invoke(true); // Pause 버튼 끄기
        UIManager.Instance.OpenUI(UIState.StageClear);
        SetPlayerMovable(false);
    }

    public void FailStage()
    {
        isGameDone = true;
        starCount = 0;
        OnPauseGame?.Invoke(true); // Pause 버튼 끄기 
        UIManager.Instance.OpenUI(UIState.StageClear);
        SetPlayerMovable(false);
    }

    private void SetPlayerMovable(bool isMovable)
    {
        if (firePlayer.gameObject.activeSelf)
        {
            firePlayer.IsMovable = isMovable;
        }
        if (waterPlayer.gameObject.activeSelf)
        {
            waterPlayer.IsMovable = isMovable;
        }
    }

    public void AddGold(int gold)
    {
        earnGold += gold;
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

    public void SetPlayer(PlayerType playerType, PlayerController playerController)
    {
        if (playerType == PlayerType.Fire)
            firePlayer = playerController;

        if (playerType == PlayerType.Water)
            waterPlayer = playerController;
    }


    // Delegate
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
