using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindObstacle : MonoBehaviour, ICollisionStay
{
    private readonly int isSpining = Animator.StringToHash("IsSpining");

    private Animator windAnimator;
    private ParticleSystem particle;

    [SerializeField] private bool IsWindOn = true;

    [SerializeField] float force = 3f;

    private void Start()
    {
        windAnimator = GetComponentInChildren<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();

        if (!IsWindOn)
            OffWind();
    }

    public void StayEvent(GameObject collider)
    {
        Vector2 direction = transform.up.normalized;

        Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
        
        rigidbody.AddForce(direction *  force, ForceMode2D.Force); // 충돌체의 속도에 계속 영향을 주기 때문에 무한 가속을 할 수도 있음.
                                                                   // 따라서 플레이어의 속도 상한을 정해둬야함.
                                                                   // 만약 변화값이 너무 적다면 Time.deltaTime을 곱해줄 예정
    }

    public void OnWind()
    {
        windAnimator.SetBool(isSpining, true);
        particle.Play();
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void OffWind()
    {
        windAnimator.SetBool(isSpining, false);
        particle.Stop();
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
