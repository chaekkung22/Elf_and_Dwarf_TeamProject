using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : InteractPedal
{
    [SerializeField] private GameObject obj;
    private static Action OnPedalOff;
    private static int playerOnPedal = 0;

    private WindObstacle windObstacle;

    [SerializeField] private bool IsWindOn = false;

    protected override void Start()
    {
        base.Start();

        if (obj != null)
        {
            windObstacle = obj.GetComponent<WindObstacle>();
            if (windObstacle == null)
            {
                enabled = false;
            }
        }
        else
        {
            enabled = false;
        }

        OnPedalOff += CheckIsOn;
    }

    public override void EnterEvent(GameObject collider)
    {
        base.EnterEvent(collider);

        if (IsWindOn)
            windObstacle.OnWind();
        else
            windObstacle.OffWind();
    }

    public override void ExitEvent(GameObject collider)
    {
        base.ExitEvent(collider);
        if (!isOn)
        {
            playerOnPedal = 0;
            OnPedalOff();
            if(playerOnPedal == 0)
            {
                if (IsWindOn)
                    windObstacle.OffWind();
                else
                    windObstacle.OnWind();
            }
        }
    }

    private void CheckIsOn()
    {
        playerOnPedal += playerCnt;
    }
}
