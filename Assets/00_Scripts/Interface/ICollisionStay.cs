using UnityEngine;

public interface ICollisionStay
{
    /// <summary>
    /// �浹 ����� ȣ��� �̺�Ʈ ���
    /// </summary>
    /// <param name="collider">�浹ü</param>
    void StayEvent(GameObject collider);
}
