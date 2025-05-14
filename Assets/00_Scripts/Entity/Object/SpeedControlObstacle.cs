using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControlObstacle : MonoBehaviour, ICollisionEnter, ICollisionExit
{
    [SerializeField] private float changeValue;

    public void EnterEvent(GameObject collider)
    {
        Debug.Log("@@");
        BaseController player;
        if(collider.TryGetComponent<BaseController>(out player))
        {
            player.ChangeMaxMoveSpeed(changeValue);
        }
    }

    public void ExitEvent(GameObject collider)
    {
        BaseController player;
        if(collider.TryGetComponent<BaseController>(out player))
        {
            player.ChangeMaxMoveSpeed(-changeValue);
        }
    }
}
