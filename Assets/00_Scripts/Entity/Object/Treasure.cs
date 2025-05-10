using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//==============
//골드보석 
public class Treasure : MonoBehaviour, ICollisionEnter
{

    [SerializeField] private PlayerType gEMTYPE;
    [SerializeField] private bool isGold = false;

    public void EnterEvent(GameObject collider)
    {

        PlayerController player;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            
            if (player.PlayerType == gEMTYPE) // 보석획득
            {
                //Debug.Log("Gem");
                this.gameObject.SetActive(false);
                
            }
        }
    }

}
