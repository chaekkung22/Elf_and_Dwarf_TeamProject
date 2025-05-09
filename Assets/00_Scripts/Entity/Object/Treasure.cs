using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour , ICollisionEnter
{
    private int gold = 0;
    private int gem = 0;
    public void EnterEvent(GameObject collider)
    {
        gold++;
        gem++;
        this.gameObject.SetActive(false);
    }

}
