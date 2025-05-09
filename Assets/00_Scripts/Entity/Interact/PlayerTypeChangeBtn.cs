using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTypeChangeBtn : InteractButton
{
    public delegate void OnClickTypeChangeButton();
    public static event OnClickTypeChangeButton onClickTypeChangeButton;

    public override void EnterEvent(GameObject collider)
    {
        base.EnterEvent(collider);
        onClickTypeChangeButton();
    }
}
