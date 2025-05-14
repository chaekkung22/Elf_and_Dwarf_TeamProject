using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObj : MonoBehaviour
{
    protected bool isOn = false;
    public Action OnEventOn;
    public Action OnEventOff;

    public bool IsOn {  get { return isOn; } }

    public void ChangeOnMode(bool onoff)
    {
        isOn = onoff;
    }
}
