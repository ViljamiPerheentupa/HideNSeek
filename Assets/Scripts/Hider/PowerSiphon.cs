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
    GameObject powerUI;
    
    void Start()
    {

        siphonDelay.Reset();
        siphonDelay.paused = true;
        promptUI = GameObject.FindGameObjectWithTag("Prompt");
        promptFill = GameObject.Find("Fill").GetComponent<Image>();
        promptUI.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOn)
        {
            return;
        }
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
