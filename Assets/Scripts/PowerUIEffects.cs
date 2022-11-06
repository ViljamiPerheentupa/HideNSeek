using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUIEffects : MonoBehaviour
{
    public PowerManager powerM;
    public Color startColor;
    public Color endColor;
    private Image powerFill;
    void Start()
    {
        powerFill = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        powerFill.color = Color.Lerp(startColor, endColor, powerM.powerAmount / powerM.powerMax);
    }
}
