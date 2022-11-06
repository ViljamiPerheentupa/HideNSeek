using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallState { Intact, Broken }
public class Wall : MonoBehaviour
{
    public WallState state = WallState.Intact;
    public GameObject intactWall;
    public GameObject brokenWall;
    public GameObject debris;
    
    public void BreakWall(Vector3 direction) {
        brokenWall.SetActive(true);
        intactWall.SetActive(false);
        GetComponent<Collider>().enabled = false;
        debris.SetActive(true);
        debris.GetComponent<WallDebrisManager>().Debris(direction);
    }
}
