using UnityEngine;

public interface ICollisionEnter
{
    /// <summary>
    /// 충돌시 호출될 이벤트 기능
    /// </summary>
    /// <param name="collider">충돌체</param>
    void EnterEvent(GameObject collider);
}
