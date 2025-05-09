using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, ICollisionEnter
{
    [SerializeField] private GameObject targetPortal;
    private static float teleportCooldown = 0.1f;
    private static Dictionary<GameObject, float> lastTeleportTimes = new Dictionary<GameObject, float>();
    [SerializeField] private PlayerType pORTALTYPE;

    public void EnterEvent(GameObject collider)
    {
        PlayerController player;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            if (player.playerType == this.pORTALTYPE)
            {
                //쿨타임체크
                if (!lastTeleportTimes.ContainsKey(collider))
                {
                    lastTeleportTimes[collider] = -Mathf.Infinity;
                }

                if (Time.time - lastTeleportTimes[collider] < teleportCooldown)
                    return;

                lastTeleportTimes[collider] = Time.time;

                //포탈작동
                Vector3 playerPos = collider.gameObject.transform.position;
                Vector3 potalPos = targetPortal.transform.position;

                collider.gameObject.transform.position = potalPos;
            }

        }

    }


}
