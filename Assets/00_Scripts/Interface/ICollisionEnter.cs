using UnityEngine;

public interface ICollisionEnter
{
    /// <summary>
    /// �浹�� ȣ��� �̺�Ʈ ���
    /// </summary>
    /// <param name="collider">�浹ü</param>
    void EnterEvent(GameObject collider);
}
