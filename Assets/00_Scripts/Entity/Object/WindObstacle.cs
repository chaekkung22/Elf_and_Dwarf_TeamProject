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
        
        rigidbody.AddForce(direction *  force, ForceMode2D.Force); // �浹ü�� �ӵ��� ��� ������ �ֱ� ������ ���� ������ �� ���� ����.
                                                                   // ���� �÷��̾��� �ӵ� ������ ���ص־���.
                                                                   // ���� ��ȭ���� �ʹ� ���ٸ� Time.deltaTime�� ������ ����
    }
}
