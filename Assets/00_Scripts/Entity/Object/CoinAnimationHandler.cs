using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimationHandler : MonoBehaviour
{
    // Animator 파라미터 이름을 미리 해시로 변환해 캐싱 (성능 최적화)
    private static readonly int IsPop = Animator.StringToHash("IsPop");

    private Animator animator;
    private Coin coin;

    private void Awake()
    {
        // 애니메이터 컴포넌트를 가져옴
        animator = GetComponent<Animator>();
        coin = GetComponentInParent<Coin>();
    }



    public void Pop()
    {
        // 팝업 애니메이션 상태 진입
        animator.SetBool(IsPop, true);
    }

    public void OnPopAnimationEnd()
    {
        //Debug.Log("PopAniEnd");
        coin.DisableCoin();
    }

}
