using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    //// Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Best Score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }


    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
