using UnityEngine;

public interface ICollisionExit
{
    /// <summary>
    /// �浹 ����� ȣ��� �̺�Ʈ ���
    /// </summary>
    /// <param name="collider">�浹ü</param>
    void ExitEvent(GameObject collider);
}
