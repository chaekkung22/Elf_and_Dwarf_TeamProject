using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//==============
//골드보석 
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
            //골드획득
            if (isGold)
            {
                gold++;
                this.gameObject.SetActive(false);
            }
            else if (player.PlayerType == gEMTYPE) // 보석획득
            {
                
                gem++;
                this.gameObject.SetActive(false);
                
            }
        }
    }

}
