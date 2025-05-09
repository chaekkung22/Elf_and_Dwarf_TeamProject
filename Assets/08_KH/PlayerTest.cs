using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerTest : BaseController
{
    public PlayerType playerType;


    public void OnDeath()
    {
        Death();
    }

    bool isICollision<T>(GameObject gameObject)
    {
        return gameObject.GetComponent<T>() != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isICollision<ICollisionEnter>(collision.gameObject))
        {
            collision.gameObject.GetComponent<ICollisionEnter>().EnterEvent(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isICollision<ICollisionExit>(collision.gameObject))
        {
            collision.gameObject.GetComponent<ICollisionExit>().ExitEvent(gameObject);
        }
    }

}
