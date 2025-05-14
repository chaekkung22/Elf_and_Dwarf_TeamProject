using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObstacle : ElementalObstacle
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private bool startDirIsLeft;
    private float pivotX;
    private float dir;
    private float moveTransition = 0;

    // Start is called before the first frame update
    void Start()
    {
        pivotX = transform.localPosition.x;
        if (startDirIsLeft)
            dir = -1;
        else
            dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameStart)
        {
            moveTransition += Time.deltaTime * speed;
            float moveX = (pivotX + (Mathf.PingPong(moveTransition, distance) * dir));
            transform.localPosition = new Vector3(moveX, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
