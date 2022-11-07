using Muc.Components.Extended;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public PowerManager powerM;

    public GameObject LeechWinUI;
    public GameObject ChumpWinUI;
    public GameObject powerUI;

    public bool gameOn;

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

    public void ChumpWin()
    {
        GameEnd();
        ChumpWinUI.SetActive(true);
    }

    void GameEnd() {
        Time.timeScale = 0;
    }

    public void GameStart() {
        Time.timeScale = 1;
        powerM.ResetPowerAmount();
        LeechWinUI.SetActive(false);
        ChumpWinUI.SetActive(false);
        powerUI.SetActive(true);
        gameOn = true;
    }

    public void ResetGame() {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
