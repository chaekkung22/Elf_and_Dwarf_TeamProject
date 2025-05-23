using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGate : MonoBehaviour, ICollisionStay, ICollisionExit
{

    [SerializeField] private float spendTime = 1f;
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Sprite closedSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerType doorType;
    private bool isExitSucess = false;

    public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void StayEvent(GameObject collider)
    {
        PlayerType playerType;

        if (!CheckPlayerValid(collider, out playerType))
        {
            return;
        }

        spendTime -= Time.deltaTime;

        if (spendTime <= 0f)
        {
            spendTime = 0f;

            //IsExitSucess = true;  //UI에서 bool값을 받아 탈출시 나오는 화면 보여줘야할듯..?
            if (isExitSucess == false && StageManager.Instance.SetPlayerDoorState(playerType, true))
            {
                isExitSucess = true;
                spriteRenderer.sprite = openSprite;
            }
        }
    }

    public void ExitEvent(GameObject collider)
    {
        if (isExitSucess == true)
            return;

        PlayerType playerType;

        if (!CheckPlayerValid(collider, out playerType))
        {
            return;
        }

        StageManager.Instance.SetPlayerDoorState(playerType, false);

        spriteRenderer.sprite = closedSprite;
        spendTime = 1;
    }

    private bool CheckPlayerValid(GameObject collider, out PlayerType playerType)
    {
        PlayerController player;

        playerType = PlayerType.Fire;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            playerType = player.PlayerType;
            if (playerType != doorType) return false;
            return true;
        }

        return false;
    }
}
