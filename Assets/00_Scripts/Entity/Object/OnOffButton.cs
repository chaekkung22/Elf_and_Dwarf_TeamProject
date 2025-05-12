using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : InteractPedal, ICollisionStay
{
    [SerializeField] private GameObject obj;

    private WindObstacle windObstacle;

    private PlayerType playerType;

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
    }

    public override void EnterEvent(GameObject collider)
    {
        //playerType = CheckPlayerType(collider);

        base.EnterEvent(collider);

        if (windObstacle != null)
        {
            windObstacle.OffWind();
        }
    }

    public void StayEvent(GameObject collider)
    {
        base.EnterEvent(collider);

        if (windObstacle != null)
        {
            windObstacle.OffWind();
        }
    }

    public override void ExitEvent(GameObject collider)
    {
        //if (playerType != CheckPlayerType(collider))
        //    return;

        base.ExitEvent(collider);

        if (windObstacle != null)
        {
            windObstacle.OnWind();
            isOn = true;
        }
    }

    //private PlayerType CheckPlayerType(GameObject collider)
    //{
    //    PlayerType currentPlayerType = PlayerType.None;

    //    PlayerController player;
    //    if (collider.TryGetComponent<PlayerController>(out player))
    //    {
    //        currentPlayerType = player.PlayerType;
    //    }

    //    return currentPlayerType;
    //}

}
