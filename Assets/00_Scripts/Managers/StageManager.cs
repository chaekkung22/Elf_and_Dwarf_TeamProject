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

    public bool isType1AtDoor = false;
    public bool isType2AtDoor = false;

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

    public void ChangeType()
    {

    }

    public void PauseGame()
    {

    }


}
