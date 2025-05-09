using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private AnimationHandler animationHandler;
    private Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;

    [SerializeField] private float maxMoveSpeed = 5f;
    [SerializeField] private float movePower = 5f;
    [SerializeField] private float jumpPower = 5f;

    [SerializeField] private LayerMask groundLayer;

    private bool isGround;
    private bool wasGround = true;

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

        Debug.DrawRay(_rigidbody.position, Vector3.down * 0.6f, new Color(0, 1, 0));
        isGround = Physics2D.Raycast(_rigidbody.position, Vector3.down, 0.6f, groundLayer);

        if (wasGround == false && isGround == true)
        {
            animationHandler.Idle();
        }

        this.wasGround = isGround;
    }

    protected void Move(Vector2 direction)
    {
        // 캐릭터 이동
        if (Mathf.Abs(_rigidbody.velocity.x) < maxMoveSpeed)
        {
            _rigidbody.AddForce(new Vector2(direction.x * movePower, 0f));
        }
        animationHandler.Moving(direction);
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
        if (isGround)
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animationHandler.Jumping();
            isGround = false;
        }
    }

    protected void Death()
    {
        // 캐릭터 사망
    }
}