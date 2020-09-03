using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void QuitTheGame()
    {
        Debug.Log("quit the game");
        PlayerPrefs.DeleteKey("Highscore");
        Application.Quit();
    }
}
