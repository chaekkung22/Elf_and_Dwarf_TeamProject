using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalObstacle : MonoBehaviour , ICollisionEnter
{
    public PlayerType ObstacleType;
    public PlayerType ObstacleType1;
    public void EnterEvent(GameObject collider)
    {
        Player player;
        if (collider.TryGetComponent<Player>(out player))
        {
            if (player.playerType == ObstacleType)
            {
                //�÷��̾��
                player.OnDeath();
                player.gameObject.SetActive(false);
                Debug.Log("�÷��̾��");
            }
        }

    }
}
