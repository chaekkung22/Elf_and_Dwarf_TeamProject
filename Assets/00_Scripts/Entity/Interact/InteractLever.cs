using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLever : InteractObj, ICollisionEnter
{
    [SerializeField] protected Sprite leverOnImg;
    [SerializeField] protected Sprite leverOffImg;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected void ChangeLeverSprite()
    {
        if(isOn)
            _renderer.sprite = leverOnImg;
        else
            _renderer.sprite = leverOffImg;
    }

    public void EnterEvent(GameObject collider)
    {
        ChangeOnMode(!isOn);
        ChangeLeverSprite();
    }
}
