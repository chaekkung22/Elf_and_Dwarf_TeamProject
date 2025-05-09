using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private AnimationHandler animationHandler;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    protected Vector2 lookDirection = Vector2.zero;

    protected void Move()
    {
        // 캐릭터 이동
    }

    protected void Rotate()
    {
        // 캐릭터 바라보는 방향 전환
    }

    protected void Jump()
    {
        // 캐릭터 점프
    }

    protected void Death()
    {
        // 캐릭터 사망
    }
}
