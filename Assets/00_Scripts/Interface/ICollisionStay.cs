using UnityEngine;

public interface ICollisionStay
{
    /// <summary>
    /// 충돌 종료시 호출될 이벤트 기능
    /// </summary>
    /// <param name="collider">충돌체</param>
    void StayEvent(GameObject collider);
}
