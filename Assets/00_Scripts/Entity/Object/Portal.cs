using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, ICollisionEnter
{
    [SerializeField] private GameObject targetPortal;
    private static float teleportCooldown = 0.1f;
    private static Dictionary<int, float> lastTeleportTimes = new Dictionary<int, float>();
    [SerializeField] private PlayerType portalType;

    public void EnterEvent(GameObject collider)
    {
        PlayerController player;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            if (player.PlayerType == this.portalType)
            {
                //쿨타임체크
                int id = collider.GetInstanceID();
                if (!lastTeleportTimes.ContainsKey(id))
                {
                    lastTeleportTimes[id] = -Mathf.Infinity;
                }

                if (Time.time - lastTeleportTimes[id] < teleportCooldown)
                    return;

                lastTeleportTimes[id] = Time.time;

                //포탈작동
                Vector3 playerPos = collider.gameObject.transform.position;
                Vector3 potalPos = targetPortal.transform.position;

                collider.gameObject.transform.position = potalPos;
            }
        }
    }
}
