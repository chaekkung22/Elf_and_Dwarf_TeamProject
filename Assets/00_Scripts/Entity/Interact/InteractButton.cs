using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : InteractObj, ICollisionEnter
{
    [SerializeField] private Sprite buttonOnImg;
    [SerializeField] private Sprite buttonOffImg;
    private SpriteRenderer _renderer;

    [SerializeField] private float btnActiveTerm;

    private void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void EnterEvent(GameObject collider)
    {
        ChangeOnMode(true);
        _renderer.sprite = buttonOnImg;
        Invoke("ButtonOff", btnActiveTerm);
    }

    private void ButtonOff()
    {
        ChangeOnMode(false);
        _renderer.sprite = buttonOffImg;
    }
}
