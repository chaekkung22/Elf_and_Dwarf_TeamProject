using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : InteractPedal
{
    [SerializeField] private GameObject obj;

    private WindObstacle windObstacle;

    [SerializeField] private bool IsWindOn = false;

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

    public override void StayEvent(GameObject collider)
    {
        base.StayEvent(collider);

        if (windObstacle != null)
        {
            if (IsWindOn)
                windObstacle.OnWind();
            else
                windObstacle.OffWind();


        }
    }

    public override void ExitEvent(GameObject collider)
    {
        base.ExitEvent(collider);

        if (windObstacle != null)
        {
            if (IsWindOn)
                windObstacle.OffWind();
            else
                windObstacle.OnWind();
        }
    }
}
