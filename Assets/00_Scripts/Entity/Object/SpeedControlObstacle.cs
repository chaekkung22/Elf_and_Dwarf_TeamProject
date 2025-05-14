using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControlObstacle : MonoBehaviour, ICollisionEnter, ICollisionExit
{
    [SerializeField] private float changeValue;
    [SerializeField] private bool isControlJump;

    public void EnterEvent(GameObject collider)
    {
        BaseController player;
        if(collider.TryGetComponent<BaseController>(out player))
        {
            player.ChangeMaxMoveSpeed(changeValue);
            if(isControlJump)
            {
                player.ChangeJumpAbleMode(false);
            }
        }
    }

    public void ExitEvent(GameObject collider)
    {
        BaseController player;
        if(collider.TryGetComponent<BaseController>(out player))
        {
            player.ChangeMaxMoveSpeed(-changeValue);
            if(isControlJump)
            {
                player.ChangeJumpAbleMode(true);
            }
        }
    }
}
