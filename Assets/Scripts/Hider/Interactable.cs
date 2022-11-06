using Muc.Components.Extended;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

	[Tooltip("When the interactable gains focus")]
	public UnityEvent onFocus;
	[Tooltip("When the interactable loses focus")]
	public UnityEvent onUnfocus;

	[Tooltip("When the interaction is started")]
	public UnityEvent onActivate;
	[Tooltip("When the interaction is ended")]
	public UnityEvent onDeactivate;

	public bool focused;
	public bool activated;

	public void Focus()
    {
		if (!focused)
        {
			focused = true;
			if (!activated) onFocus.Invoke();
		}

	}

	public void Unfocus()
	{
		if (focused)
		{
			focused = false;
			if (!activated) onUnfocus.Invoke();
		}

	}

	public void Activate()
	{
		if (!activated)
		{
			activated = true;
			onActivate.Invoke();
			if (focused) onUnfocus.Invoke();
		}
	}
	public void Deactivate()
	{
		if (activated)
		{
			activated = false;
			onDeactivate.Invoke();
			if (focused) onFocus.Invoke();
		}
	}

	public void OnEnable()
    {
        NearbyObjectInteractionManager.instance.interactables.Add(this);
    }
    public void OnDisable()
    {
        NearbyObjectInteractionManager.instance.interactables.Remove(this);
    }
}
