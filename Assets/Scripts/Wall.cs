using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallState { Intact, Broken }
public class Wall : MonoBehaviour
{
    public WallState state = WallState.Intact;
    public GameObject IntactWall;
    public GameObject BrokenWall;
    
    public void BreakWall() {
        BrokenWall.SetActive(true);
        IntactWall.SetActive(false);
    }
}
