using System.Collections;
using System.Collections.Generic;
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

public class TutorialUITypeSetter : MonoBehaviour
{
    [SerializeField] private TutorialUIType tutorialUIType;
    public TutorialUIType TutorialUIType { get { return tutorialUIType; } }
}
