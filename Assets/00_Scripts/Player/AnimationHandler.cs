using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private readonly int isMoving = Animator.StringToHash("IsMoving");
    private readonly int isJumping = Animator.StringToHash("IsJumping");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Moving(Vector2 obj)
    {
        // 움직이는 애니메이션
        animator.SetBool(isMoving, obj.magnitude > 0.5f);
    }

    public void Jumping()
    {
        // 점프하는 애니메이션
        animator.SetBool(isJumping, true);
    }

    public void Idle() 
    {
        // 캐릭터가 점프 중이 아닐 때 점프 애니메이션 종료
        animator.SetBool(isJumping, false);
    }
}

