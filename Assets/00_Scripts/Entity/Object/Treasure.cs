using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour, ICollisionEnter
{
    private int gold = 0;
    private int gem = 0;

    [SerializeField] private PlayerType gEMTYPE;
    [SerializeField] private bool isGold = false;

    public void EnterEvent(GameObject collider)
    {

        PlayerController player;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            if (isGold)
            {
                gold++;
                this.gameObject.SetActive(false);
            }
            else if (player.playerType == gEMTYPE)
            {
                //플레이어데스
                gem++;
                this.gameObject.SetActive(false);
                
            }
        }
    }

}
