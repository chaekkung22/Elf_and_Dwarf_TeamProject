using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : InteractPedal
{
    [SerializeField] private GameObject obj;

    private WindObstacle windObstacle;

    protected override void Start()
    {
        base.Start();

        if (obj != null)
        {
            windObstacle = obj.GetComponent<WindObstacle>();
            if (windObstacle == null)
            {
                enabled = false;
            }
        }
        else
        {
            enabled = false;
        }
    }

    public override void EnterEvent(GameObject collider)
    {
        base.EnterEvent(collider);
        windObstacle.OffWind();
    }

    public override void ExitEvent(GameObject collider)
    {
        base.ExitEvent(collider);
        if (!isOn)
        {
            windObstacle.OnWind();
        }
    }
}
