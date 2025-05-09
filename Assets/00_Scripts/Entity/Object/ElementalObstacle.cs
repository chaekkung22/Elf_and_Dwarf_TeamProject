using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalObstacle : MonoBehaviour , ICollisionEnter
{
    [SerializeField] private PlayerType oBSTACLETYPE;
    
    public void EnterEvent(GameObject collider)
    {
        PlayerController player;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            if (player.playerType == oBSTACLETYPE)
            {
                //�÷��̾��
                //player.OnDeath();
                player.gameObject.SetActive(false);
                Debug.Log("�÷��̾��");
            }
        }

    }
}
