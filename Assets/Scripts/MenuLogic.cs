using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    public bool gameStart;
    public bool gameEnd;
    void Update()
    {
        if (gameStart) {
            if (Input.GetButtonDown("Submit") || Input.GetButtonDown("SubmitP1")) {
                GameManager.instance.GameStart();
            }
        }
        if (gameEnd) {
            if (Input.GetButtonDown("Submit") || Input.GetButtonDown("SubmitP1")) {
                GameManager.instance.ResetGame();
            }
            if (Input.GetButtonDown("Cancel")) {
                GameManager.instance.QuitGame();
            }
        }
    }
}
