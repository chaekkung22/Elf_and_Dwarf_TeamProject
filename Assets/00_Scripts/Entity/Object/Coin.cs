using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollisionEnter
{
    CoinAnimationHandler coinAnimationHandler;
    private Collider2D coinCollider;

    private void Awake()
    {
        coinAnimationHandler = GetComponentInChildren<CoinAnimationHandler>();
        coinCollider = GetComponent<Collider2D>();
    }
    public void EnterEvent(GameObject collider)
    {
        PlayerController player;
        if (collider.TryGetComponent<PlayerController>(out player))
        {
            //골드획득
            //Debug.Log("GetGold");
            coinCollider.enabled = false;
            coinAnimationHandler.Pop();
            //효과음
            SoundManager.Instance.PlaySfx(SfxType.GetCoin);
        }
    }

    public void DisableCoin()
    {
        //Debug.Log("disable");
        this.gameObject.SetActive(false);
    }
}
