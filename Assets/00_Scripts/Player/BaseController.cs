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
        // ĳ���� �̵�
    }

    protected void Rotate()
    {
        // ĳ���� �ٶ󺸴� ���� ��ȯ
    }

    protected void Jump()
    {
        // ĳ���� ����
    }

    protected void Death()
    {
        // ĳ���� ���
    }
}
