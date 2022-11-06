using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform hider;
    private float camHeight = 5f;
    void Start()
    {
        hider = GameObject.Find("Hider").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = hider.transform.position + Vector3.up * camHeight;
    }
}
