using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public PowerManager powerM;

    public GameObject LeechWinUI;

    public void Start() {
        powerM = GetComponentInChildren<PowerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LeechWin() {
        GameEnd();
        LeechWinUI.SetActive(true);
    }

    void GameEnd() {
        Time.timeScale = 0;
    }

    public void GameStart() {
        Time.timeScale = 1;
        powerM.ResetPowerAmount();
        LeechWinUI.SetActive(false);
        //ADD Chump win UI outta here
        //ADD Reroll map generation
        //ADD Players respawning
    }
}
