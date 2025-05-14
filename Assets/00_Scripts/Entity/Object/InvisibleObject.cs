using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UIElements;

public class InvisibleObject : MonoBehaviour
{
    [SerializeField] private List<ActiveRule> rules = new List<ActiveRule>();

    private Renderer _renderer;
    private Collider2D _collider;

    [SerializeField] private bool invisibleOnAwake;

    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _collider = GetComponentInChildren<Collider2D>();

        for(int i = 0; i < rules.Count; i++)
        {
            rules[i].interactObj.OnEventOn += CheckEvent;
            rules[i].interactObj.OnEventOff += CheckEvent;
        }

        ChangeInvisibleMode(invisibleOnAwake);
    }

    private void ChangeInvisibleMode(bool enabled)
    {
        if(_renderer != null)
            _renderer.enabled = enabled;
        if(_collider != null)
            _collider.enabled = enabled;
    }

    public void CheckEvent()
    {
        bool isSatisfied = true;

        for(int i = 0; i < rules.Count; i++)
        {
            if(!rules[i].CheckingRule())
                isSatisfied = false;
        }

        if(isSatisfied)
        {
            EventOn();
        }
        else
        {
            EventOff();
        }
    }

    private void EventOn()
    {
        if(invisibleOnAwake)
            ChangeInvisibleMode(false);
        else
            ChangeInvisibleMode(true);
    }

    private void EventOff()
    {
        if(invisibleOnAwake)
            ChangeInvisibleMode(true);
        else
            ChangeInvisibleMode(false);
    }
}
