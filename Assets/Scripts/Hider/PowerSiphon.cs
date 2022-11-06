using Muc.Components.Extended;
using Muc.Time;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSiphon : Singleton<PowerSiphon>
{
    public Interval siphonDelay;
    public float siphonAmount;

    public GameObject promptUI;
    public Image promptFill;
    public bool inRadius;
    void Start()
    {
        siphonDelay.Reset();
        siphonDelay.paused = true;
        promptUI = GameObject.FindGameObjectWithTag("Prompt");
        promptFill = GameObject.Find("Prompt").GetComponentInChildren<Image>();
        promptUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        while (siphonDelay.UseOne())
        {
            PowerManager.instance.ChangePowerAmount(siphonAmount);
            siphonDelay.Reset();
        }
        if (inRadius)
        {
            promptUI.SetActive(true);
            promptFill.fillAmount = (Time.time - siphonDelay.pauseAdjustedRefTime) / siphonDelay.delay;
            if (Input.GetButton("Submit"))
            {
                Debug.Log("siphoning");
                siphonDelay.paused = false;
            } else
            {
                siphonDelay.paused = true;
                siphonDelay.Reset();
            }
        } else
        {
            promptUI.SetActive(false);
        }
    }

    public void OnEnterPowerPoint()
    {
        siphonDelay.Reset();
        inRadius = true;
    }
    public void OnExitPowerPoint()
    {
        inRadius = false;
        siphonDelay.Reset();
        siphonDelay.paused = true;
    }
}
