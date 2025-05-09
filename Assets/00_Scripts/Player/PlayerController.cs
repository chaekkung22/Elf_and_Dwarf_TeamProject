using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerType
{
    Fire,
    Water
}

public class PlayerController : BaseController
{
    public PlayerType playerType;

    void OnMove(InputValue inputValue)
    {
        // 입력을 통한 플레이어의 이동 구현
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnJump(InputValue inputValue)
    {
        // 입력을 통한 플레이어의 점프 구현
        Jump();
    }
}
