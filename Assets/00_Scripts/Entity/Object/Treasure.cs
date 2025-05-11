using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//==============
//골드보석 
public class Treasure : MonoBehaviour, ICollisionEnter
{

    [SerializeField] private PlayerType gemType;

    public void EnterEvent(GameObject collider)
    {

        PlayerController player;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            
            if (player.PlayerType == gemType) // 보석획득
            {
                StageManager.Instance.AddGemCountByType(gemType);
                this.gameObject.SetActive(false);
                
            }
        }
    }

}
