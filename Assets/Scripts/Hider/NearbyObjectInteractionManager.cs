using Muc.Components.Extended;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NearbyObjectInteractionManager : Singleton<NearbyObjectInteractionManager>
{

    public float maxInteractionDistance = 2;

    [HideInInspector]
    public List<Interactable> interactables;

    [HideInInspector]
    public Interactable previous;
    [HideInInspector]
    public Interactable previousActivated;

    // Update is called once per frame
    void Update()
    {
        var closest = interactables.FirstOrDefault();
        var closestDist = float.PositiveInfinity;
        if (closest != null)
        {
            foreach (var interactable in interactables)
            {
                var dist = Vector3.Distance(interactable.transform.position, closest.transform.position);
                if (dist < closestDist && dist <= maxInteractionDistance)
                {
                    closest = interactable;
                    closestDist = dist;
                }

            }
        }
        if (closest && Input.GetKeyDown(KeyCode.Space))
        {
            closest.Activate();
            previousActivated = closest;
        }
        else
        {
            if (previousActivated && previousActivated.activated)
            {
                previousActivated.Deactivate();
            }
        }
        if (previous != closest)
        {
            if (closest)
            {
                closest.Focus();
            }
            if (previous)
            {
                previous.Unfocus();
            }
        }
        previous = closest;
    }
}
