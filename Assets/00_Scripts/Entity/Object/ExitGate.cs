using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGate : MonoBehaviour, ICollisionStay
{

    float spendTime = 1f;
    
    public void StayEvent(GameObject collider)
    {
        spendTime -= Time.deltaTime;
    }
}
