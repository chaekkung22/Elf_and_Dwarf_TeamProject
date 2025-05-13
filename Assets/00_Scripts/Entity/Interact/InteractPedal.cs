using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPedal:InteractObj, ICollisionStay, ICollisionExit
{
    private Transform spriteTr;

    [SerializeField] private float speed = 5;
    [SerializeField] private float pressDistance = 0.2f; // 발판 눌림 거리
    protected Vector3 pivotPos; // 발판 초기 위치
    protected Vector3 targetPos;

    protected virtual void Start()
    {
        spriteTr = GetComponentInChildren<SpriteRenderer>().transform;
        pivotPos = spriteTr.localPosition;
        targetPos = pivotPos + (Vector3.down * pressDistance);
    }

    private void Update()
    {
        MovePedal();
    }

    public virtual void StayEvent(GameObject collider)
    {
        ChangeOnMode(true);
    }

    public virtual void ExitEvent(GameObject collider)
    {
        ChangeOnMode(false);
    }

    private void MovePedal()
    {
        Vector3 target;

        if(isOn)
            target = targetPos;
        else
            target = pivotPos;

        spriteTr.localPosition = Vector3.Lerp(spriteTr.localPosition, target, speed * Time.deltaTime);
    }
}
