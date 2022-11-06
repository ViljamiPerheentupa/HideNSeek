using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderCatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        GameManager.instance.ChumpWin();

    }
}
