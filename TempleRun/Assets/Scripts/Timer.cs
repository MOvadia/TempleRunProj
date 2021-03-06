﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text m_TimerUI;
    [SerializeField] private carControler m_car;

    private float m_timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_car.IsDead)
        {
            return;
        }
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        m_timer += Time.deltaTime;
        string minutes = ((int)m_timer / 60).ToString();
        string seconds = (m_timer % 60).ToString("f1");
        m_TimerUI.text = minutes + ":" + seconds;
    }
}
