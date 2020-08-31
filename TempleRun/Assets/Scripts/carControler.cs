using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class carControler : MonoBehaviour
{
    [SerializeField] private float m_MovmentFactor = 0.1f;
    [SerializeField] private float m_MovmentFactorForward = 0.1f;
    [SerializeField] private GameObject m_enemyRefence;
    [SerializeField] private Text m_coinsCounterToScreen;
    [SerializeField] private DeathMenu m_deathMenu;
    
    private int m_coinsCounter;
    private Transform m_player;
    private Rigidbody m_playerRig;
    private CharacterController m_controller;
    private static bool m_isDead = false;
    private int m_numOfCollisionWithCoin = 0;
    private int m_highestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_isDead = false;
        m_player = transform;
        m_playerRig = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDead)
        {
            if(m_highestScore < m_numOfCollisionWithCoin)
            {
                m_highestScore = m_numOfCollisionWithCoin;
            }
            return;
        }
        CheckInputs();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Death();
        }
        if (collision.gameObject.tag == "coin")
        {
            m_numOfCollisionWithCoin++;
            m_coinsCounterToScreen.text = m_numOfCollisionWithCoin.ToString();
            Object.Destroy(collision.gameObject);
        }
    }

    private void Death()
    {
        m_isDead = true;
        m_deathMenu.ToggleEndMenu(m_numOfCollisionWithCoin);
    }

    private void CheckInputs()
    {
        m_player.position += m_player.forward * m_MovmentFactorForward;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_player.position += m_player.right * m_MovmentFactor;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_player.position -= m_player.right * m_MovmentFactor;
        }
    }
    public bool IsDead
    {
        get 
        {
            return m_isDead;
        }
        set
        {
            m_isDead = value;
        }
    }

    public int HighestScore
    {
        get
        {
            return m_highestScore;
        }
    }
}
