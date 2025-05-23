using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TutorialUIType
{
    Move,
    ElementalObstacle,
    Treasure,
    Button,
    JumpPad,
    Finish
}

public class TutorialUI : MonoBehaviour, ICollisionStay, ICollisionExit
{
    private Dictionary<PlayerType, bool> playerIn = new Dictionary<PlayerType, bool>
    {
        { PlayerType.Fire, false },
        { PlayerType.Water, false }
    };

   
    private TutorialUIController uiController;
    [SerializeField] private TutorialUIType tutorialUIType;
    [SerializeField] private GameObject tutorialControllerObject;
    [SerializeField] private GameObject tutorialUI;

    private void Start()
    {
        if (tutorialControllerObject != null)
        {
            uiController = tutorialControllerObject.GetComponent<TutorialUIController>();
        }
    }

    public void StayEvent(GameObject collider)
    {
        CheckFadeInOut(collider, true);
    }

    public void ExitEvent(GameObject collider)
    {
        CheckFadeInOut(collider, false);
    }

    public void CheckFadeInOut(GameObject collider ,bool check)
    {
        var player = collider.GetComponent<PlayerController>();

        if (player != null)
        {
            if (player.PlayerType == PlayerType.Fire)
                playerIn[PlayerType.Fire] = check;
            else if (player.PlayerType == PlayerType.Water)
                playerIn[PlayerType.Water] = check;
        }

        bool fireIn = playerIn[PlayerType.Fire];
        bool waterIn = playerIn[PlayerType.Water];

        if ((fireIn || waterIn))
            uiController.FadeIn(tutorialUIType);
        else if (!fireIn && !waterIn)
            uiController.FadeOut(tutorialUIType);
    }

}
