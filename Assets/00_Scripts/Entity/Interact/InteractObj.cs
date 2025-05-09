using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObj : MonoBehaviour
{
    protected bool isOn = false;

    public void ChangeOnMode(bool onoff)
    {
        isOn = onoff;
    }
}
