using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//================
//플레이어데스
public class ElementalObstacle : MonoBehaviour, ICollisionEnter
{
    [SerializeField] private PlayerType obstacleType;
    [SerializeField] private bool ignoreElementalType = false;

    public void EnterEvent(GameObject collider)
    {
        PlayerController player;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            if (!ignoreElementalType ||player.PlayerType != obstacleType)
            {
                //플레이어데스
                //player.OnDeath();
                player.gameObject.SetActive(false);
                StageManager.Instance.FailStage();
                //Debug.Log("플레이어데스");
            }
        }

    }
}
