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


}
