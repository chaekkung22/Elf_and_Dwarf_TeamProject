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
    private float moveSpeedLimitTmp = 0; // 외부 오브젝트로 인해 최대 속도에 생기는 변화 량을 저장

    [SerializeField] private LayerMask groundLayer;

    private bool isGround;
    private bool wasGround = true;
    private bool jumpAble = true;

    public bool IsGround { get { return isGround; } }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Update()
    {
        if(GameManager.Instance.GameStart)
        {
            Rotate();
        }
    }

    protected virtual void FixedUpdate()
    {
        if(GameManager.Instance.GameStart)
        {
            Move(movementDirection);

            Debug.DrawRay(_rigidbody.position, Vector3.down * 0.6f, new Color(0, 1, 0));
            isGround = Physics2D.Raycast(_rigidbody.position, Vector3.down, 0.6f, groundLayer);

            if(wasGround == false && isGround == true)
            {
                animationHandler.Idle();
            }

            this.wasGround = isGround;
        }
    }

    protected void Move(Vector2 direction)
    {
        // 캐릭터 이동
        if (Mathf.Abs(_rigidbody.velocity.x) < maxMoveSpeed + moveSpeedLimitTmp)
        {
            _rigidbody.AddForce(new Vector2(direction.x * movePower, 0f));
        }
        else
        {
            Vector3 vel = _rigidbody.velocity;
            vel.x = Mathf.Clamp(vel.x, -1 * (maxMoveSpeed + moveSpeedLimitTmp), maxMoveSpeed + moveSpeedLimitTmp);
            _rigidbody.velocity = vel;
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
        if (isGround && jumpAble)
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

    public void ChangeMaxMoveSpeed(float value)
    {
        moveSpeedLimitTmp += value;
        Debug.Log(moveSpeedLimitTmp);
    }

    public void ChangeJumpAbleMode(bool value)
    {
        jumpAble = value;
    }
}