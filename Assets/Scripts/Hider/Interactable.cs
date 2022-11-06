using Muc.Components.Extended;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactable : Muc.Systems.Interaction.Interactable
{
    public void OnEnable()
    {
        NearbyObjectInteractionManager.instance.interactables.Add(this);
    }
    public void OnDisable()
    {
        NearbyObjectInteractionManager.instance.interactables.Remove(this);
    }
}
