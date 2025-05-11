using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialUI : MonoBehaviour, ICollisionStay, ICollisionExit
{
    private Dictionary<PlayerType, bool> playerIn = new Dictionary<PlayerType, bool>
    {
        { PlayerType.Fire, false },
        { PlayerType.Water, false }
    };

    public GameObject tutorialUI;

    public void StayEvent(GameObject collider)
    {
        var player = collider.GetComponent<PlayerController>();

        if (player != null)
        {
            if (player.PlayerType == PlayerType.Fire)
                playerIn[PlayerType.Fire] = true;
            else if (player.PlayerType == PlayerType.Water)
                playerIn[PlayerType.Water] = true;
        }

        bool fireIn = playerIn[PlayerType.Fire];
        bool waterIn = playerIn[PlayerType.Water];

        if (fireIn || waterIn)
            tutorialUI.SetActive(true);
    }

    public void ExitEvent(GameObject collider)
    {
        var player = collider.GetComponent<PlayerController>();

        if (player != null)
        {
            if (player.PlayerType == PlayerType.Fire)
                playerIn[PlayerType.Fire] = false;
            else if (player.PlayerType == PlayerType.Water)
                playerIn[PlayerType.Water] = false;
        }

        bool fireIn = playerIn[PlayerType.Fire];
        bool waterIn = playerIn[PlayerType.Water];

        if (!fireIn && !waterIn)
            tutorialUI.SetActive(false);
    }

}
