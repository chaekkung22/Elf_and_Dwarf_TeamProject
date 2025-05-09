using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour, ICollisionEnter
{
    [SerializeField] float force = 5;

    public void EnterEvent(GameObject collider)
    {
        //이 오브젝트 기준으로 위쪽. z가 회전이 되더라도 오브젝트의 기준으로 힘을 주기 위해 방향을 따옴
        Vector2 direction = transform.up.normalized;
        //Enter시에 한 번만 실행되기 때문에, 속도(velocity)에 적용해주기 위해 rigidbody를 들고 옴 
        Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();

        if (rigidbody != null)
            rigidbody.velocity = new Vector2(rigidbody.velocity.x + direction.x * force,
                rigidbody.velocity.y + direction.y * force);  // 충돌한 오브젝트가 가지고 있던 기존 속도에 힘을 더해줌.
                                                              // 만약 x값이 0(똑바로 위를 보는 상태)이면 x에는 힘이 더해지지 않음(기존 x축 속도 유지)
    }
}
