﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
      // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    public void QuitTheGame()
    {
        Debug.Log("quit the game");
        PlayerPrefs.DeleteKey("Highscore");
        Application.Quit();
    }
}
