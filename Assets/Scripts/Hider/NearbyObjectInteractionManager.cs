using Muc.Components.Extended;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NearbyObjectInteractionManager : Singleton<NearbyObjectInteractionManager>
{
    [HideInInspector]
    public List<Interactable> interactables;

    // Update is called once per frame
    void Update()
    {
        var closest = FindObjectsOfType<Interactable>().FirstOrDefault();
        var closestDist = float.PositiveInfinity;
        foreach (var interactable in interactables)
        {
            var dist = Vector3.Distance(interactable.transform.position, closest.transform.position);
            if (dist < closestDist)
            {
                closest = interactable;
                closestDist = dist;
            }

        }
        if (closest && true)
        {
            closest.Activate(null);
        } 
    }
}
