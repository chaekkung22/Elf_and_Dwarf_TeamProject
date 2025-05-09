using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour, ICollisionEnter
{
    [SerializeField] float force = 5;

    public void EnterEvent(GameObject collider)
    {
        Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

        if (rigidbody != null)
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, force);  //x축으로 이동하던 속도는 유지, y에만 값을 넣어줌
    }
}
