using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private AnimationHandler animationHandler;
    private Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Update()
    {
        Rotate();
    }

    protected virtual void FixedUpdate()
    {
        Move(movementDirection);
    }

    protected void Move(Vector2 direction)
    {
        // 캐릭터 이동
        float moveSpeed = 5f;
        direction = direction * moveSpeed;
        _rigidbody.velocity = direction;
    }

    protected void Rotate()
    {
        // 캐릭터 바라보는 방향 전환
        if (Mathf.Abs(movementDirection.x) > 0.01f)
            characterRenderer.flipX = movementDirection.x < 0;
    }

    protected void Jump()
    {
        // 캐릭터 점프
        float jumpPower = 5f;
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpPower);
    }

    protected void Death()
    {
        // 캐릭터 사망
    }
}