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
    [SerializeField] private PlayerType playerType;
    public PlayerType PlayerType { get { return playerType; } }

    private void Start()
    {
        PlayerTypeChangeBtn.onClickTypeChangeButton += ChangeType;
    }

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

    private void ChangeType()
    {
        if(PlayerType == PlayerType.Fire)
            playerType = PlayerType.Water;
        else
            playerType = PlayerType.Fire;
    }

    private bool isICollision<T>(GameObject gameObject)
    {
        return gameObject.GetComponent<T>() != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isICollision<ICollisionEnter>(collision.gameObject))
        {
            collision.gameObject.GetComponent<ICollisionEnter>().EnterEvent(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isICollision<ICollisionExit>(collision.gameObject))
        {
            collision.gameObject.GetComponent<ICollisionExit>().ExitEvent(gameObject);
        }
    }
}
