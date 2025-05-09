using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindObstacle : MonoBehaviour, ICollisionStay
{
    [SerializeField] float force = 3f;

    public void StayEvent(GameObject collider)
    {
        Vector2 direction = transform.up.normalized;

        Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
        
        rigidbody.AddForce(direction *  force, ForceMode2D.Force); // 충돌체의 속도에 계속 영향을 주기 때문에 무한 가속을 할 수도 있음.
                                                                   // 따라서 플레이어의 속도 상한을 정해둬야함.
                                                                   // 만약 변화값이 너무 적다면 Time.deltaTime을 곱해줄 예정
    }
}
