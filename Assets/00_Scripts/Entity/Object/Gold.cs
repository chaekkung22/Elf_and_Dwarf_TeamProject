using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int player1Layer = LayerMask.NameToLayer("Player1");
        int player2Layer = LayerMask.NameToLayer("Player2");


        if ((player1Layer == collision.gameObject.layer))
        {
            Debug.Log("11111");
        }
        else if ((player2Layer == collision.gameObject.layer))
        {
            Debug.Log($"222222");
        }
    }
}

