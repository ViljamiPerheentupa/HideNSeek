using Muc.Components.Extended;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : Singleton<PowerManager>
{
    private GameManager manager;
    private Image powerFill;
    [HideInInspector] public float powerAmount;
    GameObject powerUI;
    public float powerMax = 100f;
    void Start()
    {
        manager = gameObject.GetComponentInParent<GameManager>();
        powerFill = GameObject.FindGameObjectWithTag("PowerUI").GetComponent<Image>();
        ResetPowerAmount();
        powerUI = GameObject.Find("Power");
        powerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOn)
        {
            return;
        }
        powerFill.fillAmount = powerAmount / powerMax;
        //Debug();
    }

    public void ChangePowerAmount(float amount) {
        powerAmount += amount;
        powerAmount = Mathf.Clamp(powerAmount, 0, powerMax);
        if(powerAmount >= powerMax) {
            manager.LeechWin();
        }
    }

    public void ResetPowerAmount() {
        powerAmount = 0;
    }


    private void Debug() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            ChangePowerAmount(0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            ChangePowerAmount(-0.5f);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetPowerAmount();
        }
        print("Power: " + powerAmount);
    }
}
