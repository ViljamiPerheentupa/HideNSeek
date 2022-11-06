using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDebrisManager : MonoBehaviour
{
    public Rigidbody[] debris;
    public float impactStrength;
    public float radius = 1f;
    public void Debris(Vector3 direction)
    {
        foreach (Rigidbody rig in debris)
        {
            rig.isKinematic = false;
            rig.AddExplosionForce(impactStrength, direction, radius);
        }
    }
}
