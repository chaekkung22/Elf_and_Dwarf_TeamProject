using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private readonly int isMoving = Animator.StringToHash("");
    private readonly int isJumping = Animator.StringToHash("");

    private Animator animator;

    public void Moving()
    {
        // 움직이는 애니메이션
    }

    public void Jumping()
    {
        // 점프하는 애니메이션
    }
}
