using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPoint : MonoBehaviour
{
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
