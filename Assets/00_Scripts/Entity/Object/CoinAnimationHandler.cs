using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimationHandler : MonoBehaviour
{
    // Animator 파라미터 이름을 미리 해시로 변환해 캐싱 (성능 최적화)
    private static readonly int IsPop = Animator.StringToHash("IsPop");

    protected Animator animator;

    protected virtual void Awake()
    {
        // 애니메이터 컴포넌트를 자식에서 가져옴
        animator = GetComponentInChildren<Animator>();
    }



    public void Damage()
    {
        // 피격 애니메이션 상태 진입
        animator.SetBool(IsPop, true);
    }


}
