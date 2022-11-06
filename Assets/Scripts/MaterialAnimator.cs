using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimator : MonoBehaviour
{
    public Material[] materials;
    public MeshRenderer mesh;
    int index;
    public float timePerFrame = 0.5f;
    float lastTick;

    private void Start()
    {
        index = 0;
        lastTick = Time.time;
        mesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if(Time.time - lastTick >= timePerFrame)
        {
            if (index + 1 < materials.Length)
            {
                lastTick = Time.time;
                index++;
                mesh.material = materials[index];
            } else
            {
                lastTick = Time.time;
                index = 0;
                mesh.material = materials[index];
            }

        }
    }
}
