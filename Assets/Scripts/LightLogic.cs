using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLogic : MonoBehaviour
{
    public Light spot;
    public Light point;
    float flicker = 0.01f;
    bool hiderIn = false;

    private void Update() {
        if (hiderIn) {
            flicker += Random.Range(-0.15f, 0.15f);
            flicker = Mathf.Clamp(flicker, 0, 1);
            spot.intensity = flicker;
            point.intensity = flicker;
        } else {
            spot.intensity = 1f;
            point.intensity = 1f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hider")) {
            hiderIn = true;
            flicker = 0.01f;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Hider")) {
            hiderIn = false;
            flicker = 0.01f;
        }
    }
}
