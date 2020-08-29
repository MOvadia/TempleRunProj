using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    public carControler m_car;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleEndMenu(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString();
    } 

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        m_car.setDeadToFalse();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
