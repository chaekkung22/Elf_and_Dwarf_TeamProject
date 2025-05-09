using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Portal : MonoBehaviour, ICollisionEnter
{
    [SerializeField] private GameObject targetPortal;
    private static float teleportCooldown = 0.1f;
    private static float lastTeleportTime = -Mathf.Infinity;


    public void EnterEvent(GameObject collider)
    {

        if (Time.time - lastTeleportTime < teleportCooldown)
            return;
        lastTeleportTime = Time.time;

        Debug.Log("11111");
        Vector3 playerPos = collider.gameObject.transform.position;
        Debug.Log($"플레이어포지션{playerPos}");
        Vector3 potalPos = targetPortal.transform.position;
        Debug.Log($"포탈포지션:{potalPos}");

        collider.gameObject.transform.position = potalPos;
    }


    //gameObject.GetComponent<T>() != null;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    int player1Layer = LayerMask.NameToLayer("Player1");
    //    int player2Layer = LayerMask.NameToLayer("Player2");


    //    if ((player1Layer == collision.gameObject.layer))
    //    {
    //        Debug.Log("11111");
    //        Vector3 playerPos = collision.gameObject.transform.position;
    //        Debug.Log($"플레이어포지션{playerPos}");
    //        Vector3 Portal2Pos = targetPortal.transform.position;
    //        Debug.Log($"포탈포지션:{Portal2Pos}");

    //        collision.gameObject.transform.position = Portal2Pos;
    //    }
    //    else if ((player2Layer == collision.gameObject.layer))
    //    {
    //        Debug.Log($"222222");
    //    }
    //}
}
