using Muc.Components.Extended;
using Muc.Time;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSiphon : Singleton<PowerSiphon>
{
    public Timeout siphonDelay;
    public Timeout siphonCooldown;
    public float siphonAmount;
    void Start()
    {
        siphonDelay.Reset();
        siphonDelay.paused = true;
        siphonCooldown.Reset();
        siphonCooldown.paused = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (siphonDelay.Use())
        {
            siphonDelay.Reset();
            siphonDelay.paused = true;
            siphonCooldown.Reset();
            siphonCooldown.paused = false;
        }
        if (siphonCooldown.Use())
        {
            siphonCooldown.Reset();
            siphonCooldown.paused = true;
        }
    }

    public void OnEnterPowerPoint()
    {
        siphonDelay.Reset();
        siphonDelay.paused = false;
    }
    public void OnExitPowerPoint()
    {
        siphonDelay.Reset();
        siphonDelay.paused = true;
    }
}
