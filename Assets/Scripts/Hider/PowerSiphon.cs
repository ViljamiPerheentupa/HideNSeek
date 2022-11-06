using Muc.Components.Extended;
using Muc.Time;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSiphon : Singleton<PowerSiphon>
{
    public Interval siphonDelay;
    public float siphonAmount;
    void Start()
    {
        siphonDelay.Reset();
        siphonDelay.paused = true;
    }
    // Update is called once per frame
    void Update()
    {
        while (siphonDelay.UseOne())
        {
            PowerManager.instance.ChangePowerAmount(siphonAmount);
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
