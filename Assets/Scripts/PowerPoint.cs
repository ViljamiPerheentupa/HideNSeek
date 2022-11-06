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
            hiderInRadius = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hider"))
        {
            hiderInRadius = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            draining = true;
        } e
        if (draining)
        {
            if(Time.time - lastTick >= timePerTick)
            {

            }
        }
    }
}
