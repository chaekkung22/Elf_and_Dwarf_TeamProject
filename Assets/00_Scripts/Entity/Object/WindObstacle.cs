using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActiveRule
{
    public InteractObj interactObj;
    [SerializeField] private bool rule;

    public bool CheckingRule()
    {
        return interactObj.IsOn == rule;
    }
}

public class WindObstacle : MonoBehaviour, ICollisionStay
{
    private readonly int isSpining = Animator.StringToHash("IsSpining");
    [SerializeField] private List<ActiveRule> rules = new List<ActiveRule>();

    private Animator windAnimator;
    private ParticleSystem particle;

    // 이벤트로 실행할 메서드가 WindOn인 경우 ture
    [SerializeField] private bool eventIsWindOn = true; 

    [SerializeField] float force = 3f;

    private void Start()
    {
        windAnimator = GetComponentInChildren<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();

        for(int i = 0; i < rules.Count; i++)
        {
            rules[i].interactObj.OnEventOn += CheckEvent;
            rules[i].interactObj.OnEventOff += CheckEvent;
        }

        if (!eventIsWindOn)
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

    public void CheckEvent()
    {
        bool isSatisfied = true;

        for(int i = 0; i < rules.Count; i++)
        {
            if(!rules[i].CheckingRule())
                isSatisfied = false;
        }

        if(isSatisfied)
        {
            EventOn();
        }
        else
        {
            EventOff();
        }
    }

    private void EventOn()
    {
        if(eventIsWindOn)
            OnWind();
        else
            OffWind();
    }

    private void EventOff()
    {
        if(eventIsWindOn)
            OffWind();
        else
            OnWind();
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
