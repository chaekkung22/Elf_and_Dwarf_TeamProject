using UnityEngine;

public interface ICollisionStay
{
    /// <summary>
    /// 충돌시 호출될 이벤트 이름
    /// </summary>
    /// <param name="collider">충돌체</param>
    void StayEvent(GameObject collider);
}
