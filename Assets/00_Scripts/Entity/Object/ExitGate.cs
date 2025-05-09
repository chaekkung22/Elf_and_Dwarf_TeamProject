using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGate : MonoBehaviour, ICollisionStay
{

    float spendTime = 1f;
    public bool isExitSucess = false;


    public void StayEvent(GameObject collider)
    {
        spendTime -= Time.deltaTime;

        if (spendTime <= 0f)
        {
            spendTime = 0f;

            if (IsCorrectType())
                isExitSucess = true;  //UI에서 bool값을 받아 탈출시 나오는 화면 보여줘야할듯..?
        }
    }

    bool IsCorrectType()
    {
        //문의 타입과 플레이어의 타입이 맞는지 확인하는 과정 작성
        return true;
    }

}
