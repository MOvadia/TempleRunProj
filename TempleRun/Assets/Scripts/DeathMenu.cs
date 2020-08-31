using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private Text m_scoreText;
    [SerializeField] private carControler m_car;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void ToggleEndMenu(int score)
    {
        gameObject.SetActive(true);
        m_scoreText.text = score.ToString();
    } 

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        m_car.IsDead = false;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
