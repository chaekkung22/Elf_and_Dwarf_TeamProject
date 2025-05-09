using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((levelCollisionLayer.value & 1 << collision.gameObject.layer) != 0)
        {

        }
    }
}
