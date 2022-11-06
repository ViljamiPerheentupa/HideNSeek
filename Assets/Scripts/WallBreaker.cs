using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : MonoBehaviour
{
    public LayerMask mask;
    public string wallTag = "Wall";
    public float radius;

    private void Update()
    {
        WreckWall();
    }
    void WreckWall()
    {
        var objs = Physics.SphereCastAll(transform.position, radius, transform.forward, 1f, mask);
        foreach (RaycastHit hit in objs)
        {
            if (hit.collider.CompareTag(wallTag))
            {
                hit.collider.gameObject.GetComponent<Wall>().BreakWall(transform.position);
            }
        }
    }
}
