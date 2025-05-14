using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using static UnityEngine.ParticleSystem;

public enum PlayerType
{
    Fire,
    Water
}

public class PlayerController : BaseController
{
    [SerializeField] private PlayerType playerType;
    ParticleSystem particle;
    Light2D _light;

    public PlayerType PlayerType { get { return playerType; } }

    private bool isMovable = true;
    public bool IsMovable { get { return isMovable; } set { this.isMovable = value; } }

    private void Start()
    {
        _light = GetComponentInChildren<Light2D>();
        particle = GetComponentInChildren<ParticleSystem>();
        particle.textureSheetAnimation.SetSprite(0, DataManager.Instance.GetEquipedItem().image);
        StageManager.Instance.SetPlayer(playerType, this);
        isMovable = true;
    }

    private void OnEnable()
    {
        PlayerTypeChangeBtn.onClickTypeChangeButton += ChangeType;
    }

    private void OnDisable()
    {
        PlayerTypeChangeBtn.onClickTypeChangeButton -= ChangeType;
    }

    void OnMove(InputValue inputValue)
    {
        if (!isMovable) return;

        // 입력을 통한 플레이어의 이동 구현
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnJump(InputValue inputValue)
    {
        if (!isMovable) return;

        // 입력을 통한 플레이어의 점프 구현
        Jump();
    }

    private void ChangeType()
    {
        if (PlayerType == PlayerType.Fire)
        {
            playerType = PlayerType.Water;
            _light.color = new Color(150/255f, 150/255f, 1f);
        }
        else
        {
            playerType = PlayerType.Fire;
            _light.color = new Color(1f, 150 / 255f, 150 / 255f);
        }

        StartCoroutine(EffectColorChange(PlayerType));
    }

    private IEnumerator EffectColorChange(PlayerType playerType)
    {
        yield return new WaitForSeconds(0.5f);
        ParticleSystem.MainModule main = particle.main;
        if (playerType == PlayerType.Fire)
            main.startColor = new Color(1f, 0f, 0f);
        else
            main.startColor = new Color(0f, 140/255f, 1f);
    }

    private bool isICollision<T>(GameObject gameObject)
    {
        return gameObject.GetComponent<T>() != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isICollision<ICollisionEnter>(collision.gameObject))
        {
            collision.gameObject.GetComponent<ICollisionEnter>().EnterEvent(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isICollision<ICollisionExit>(collision.gameObject))
        {
            collision.gameObject.GetComponent<ICollisionExit>().ExitEvent(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isICollision<ICollisionStay>(collision.gameObject))
        {
            collision.gameObject.GetComponent<ICollisionStay>().StayEvent(gameObject);
        }
    }
}
