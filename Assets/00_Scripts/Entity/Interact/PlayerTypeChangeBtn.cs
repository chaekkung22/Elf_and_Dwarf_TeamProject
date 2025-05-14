using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTypeChangeBtn : InteractButton
{
    public static Action onClickTypeChangeButton;

    public override void EnterEvent(GameObject collider)
    {
        base.EnterEvent(collider);
        onClickTypeChangeButton?.Invoke();
    }
}
