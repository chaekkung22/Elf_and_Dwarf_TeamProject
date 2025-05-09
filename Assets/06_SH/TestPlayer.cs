using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    bool isICollision<T>(GameObject gameObject)
    {
        return gameObject.GetComponent<T>() != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isICollision<ICollisionEnter>(collision.gameObject))
        {
            collision.gameObject.GetComponent<ICollisionEnter>().EnterEvent(collision.gameObject);
        }
    }
}
