using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPoint : MonoBehaviour
{
    public float powerPerTick = 5f;
    public float timePerTick = 5f;
    private float lastTick;

    
    bool draining;
    public bool hiderInRadius;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hider"))
        {
            PowerSiphon.instance.OnEnterPowerPoint();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hider"))
        {
            PowerSiphon.instance.OnExitPowerPoint();
        }
    }

}
