using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    void OnMove(InputValue inputValue)
    {
        // 입력을 통한 플레이어의 이동 구현
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnJump(InputValue inputValue)
    {
        Jump();
    }
}
